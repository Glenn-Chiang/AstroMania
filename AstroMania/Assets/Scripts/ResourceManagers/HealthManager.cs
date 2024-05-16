using System;
using UnityEngine;

public class HealthManager : ResourceManager, IDamageable
{
    public float MaxHealth => GetComponent<ICharacter>().Stats.maxHealth.Value;
    private float health;

    public override float MaxValue => MaxHealth;
    public override float Value { get => health; protected set { health = value; } }

    float IDamageable.HitPoints => health;

    public event EventHandler OnHealthChange;
    public event EventHandler OnDeath;

    public float damageMultiplier = 1;

    private void Start()
    {
        health = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        damage *= damageMultiplier;

        if (damage < health)
        {
            health -= damage;
        }
        else
        {
            health = 0;
            Die();
        }

        OnHealthChange?.Invoke(this, EventArgs.Empty);
    }

    public void Heal(float _health)
    {
        health += Math.Min(_health, MaxHealth - health); // prevent overhealing
        OnHealthChange?.Invoke(this, EventArgs.Empty);
    }

    private void Die()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);
        Destroy(this);
    }
    void IDamageable.OnDestroyed() => Die();
}
