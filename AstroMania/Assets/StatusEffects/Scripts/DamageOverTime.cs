using System;
using UnityEngine;

public class DamageOverTime : StatusEffect
{
    public HealthManager healthManager;
    public float damage; // Amount of damage to apply each interval
    public float interval; // How often the damage is applied

    public override void ApplyEffect()
    {
        healthManager = GetComponent<HealthManager>();
        InvokeRepeating(nameof(ApplyDamage), interval, interval);
    }

    private void ApplyDamage()
    {
        healthManager.TakeDamage(damage);
    }
}

[Serializable]
public class DamageOverTimeArgs : StatusEffectArgs
{
    public float damage;
    public float interval;
    public DamageOverTimeArgs(float duration, float damage, float interval) : base(duration)
    {
        this.damage = damage;
        this.interval = interval;
    }

    public override void AddToTarget(StatusEffectManager effectManager)
    {
        effectManager.AddDamageOverTime(this);
    }
}