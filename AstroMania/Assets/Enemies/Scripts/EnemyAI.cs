using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Roaming roaming;
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private HealthManager healthManager;

    [SerializeField] private float attackInterval = 1f;
    private float attackTimer;

    private float minDistance = 5f; // Enemy will not try to get closer than this distance to player

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

    private void HandleDeath(object sender, EventArgs e)
    {
        Destroy(gameObject);
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
                    attackTimer = attackInterval;
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
}
