using System;
using UnityEngine;

public class DamageOverTime : StatusEffect
{
    public HealthManager healthManager;
    public float damagePerTick;
    public float interval;

    public override void ApplyEffect()
    {
        healthManager = GetComponent<HealthManager>();
        InvokeRepeating(nameof(ApplyDamage), interval, interval);
    }

    private void ApplyDamage()
    {
        healthManager.TakeDamage(damagePerTick);
    }
}