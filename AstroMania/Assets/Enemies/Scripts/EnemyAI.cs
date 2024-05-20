using System;
using UnityEngine;

public class EnemyAI : Character
{
    [SerializeField] private EnemyData enemyData;
    public override CharacterData CharacterData => enemyData;

    public EnemyStats EnemyStats { get; private set; }
    public override CharacterStats Stats => EnemyStats;

    [SerializeField] private Movement movement;
    [SerializeField] private Roaming roaming;
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private HealthManager healthManager;

    private float attackTimer;
    [SerializeField] private float minDistance = 5f; // Enemy will not try to get closer than this distance to player

    public static event EventHandler<EnemyDeathEventArgs> OnEnemyDeath;

    private enum State
    {
        Idle, Aggro
    }

    private State state = State.Idle;

    private GameObject target;
    private Vector2 TargetPos => target.GetComponent<Rigidbody2D>().position;

    protected override void InitializeStats()
    {
        EnemyStats = new(enemyData);
    }

    private void Start()
    {
        healthManager.Died += HandleDeath;
        weaponManager.SelectRandomWeapon();
    }


    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                
                break;
            case State.Aggro:
                movement.LookAt(TargetPos);
               
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0)
                {
                    weaponManager.FireWeapon();
                    attackTimer = enemyData.AttackInterval;
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Idle:
                roaming.Roam();
                break;
            case State.Aggro:
                if (Vector2.Distance(transform.position, TargetPos) > minDistance)
                {
                    movement.MoveTowards(TargetPos);
                }
               
                break;
        }
    }

    public void StartAggro(GameObject target)
    {
        state = State.Aggro;
        this.target = target;
    }

    public void StopAggro()
    {
        state = State.Idle;
        target = null;   
    }
    private void HandleDeath(object sender, EventArgs e)
    {
        OnEnemyDeath?.Invoke(this, new EnemyDeathEventArgs(enemyData));
        Destroy(gameObject);
    }
}

public class EnemyDeathEventArgs : EventArgs
{
    public readonly EnemyData enemyData;
    public EnemyDeathEventArgs(EnemyData enemyData)
    {
        this.enemyData = enemyData;
    }
}