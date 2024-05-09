using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour, ICharacter
{
    [SerializeField] private EnemyData enemyData;
    CharacterData ICharacter.CharacterData => enemyData;
    public CharacterStats Stats => new(enemyData);

    [SerializeField] private Movement movement;
    [SerializeField] private Roaming roaming;
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private HealthManager healthManager;

    private float attackTimer;
    [SerializeField] private float minDistance = 5f; // Enemy will not try to get closer than this distance to player

    public static event EventHandler<EnemyDeathEventArgs> OnEnemyDeath;

    [SerializeField] private DeathEffect deathEffect;

    private enum State
    {
        Idle, Aggro
    }

    private State state = State.Idle;

    private GameObject target;
    private Vector2 TargetPos => target.GetComponent<Rigidbody2D>().position;

    private void Start()
    {
        healthManager.OnDeath += HandleDeath;
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
        Destroy(gameObject);
        deathEffect.Effect();
        OnEnemyDeath?.Invoke(this, new EnemyDeathEventArgs(enemyData));
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