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

    private enum State
    {
        Idle, Aggro
    }

    private State state = State.Idle;

    private GameObject target;

    private void Start()
    {
        healthManager.OnDeath += HandleDeath;
    }


    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                roaming.Roam();
                break;
            case State.Aggro:
                TrackTarget();

                if (Vector2.Distance(transform.position, target.transform.position) > minDistance)
                {
                    movement.MoveTowards(target.transform.position);
                }

                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0)
                {
                    weaponManager.FireWeapon();
                    attackTimer = enemyData.AttackInterval;
                }

                break;
        }
    }

    private void TrackTarget()
    {
        movement.LookAt(target.transform.position);
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