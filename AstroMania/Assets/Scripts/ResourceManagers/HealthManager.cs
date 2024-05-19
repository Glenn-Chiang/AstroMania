using System;
using UnityEngine;

public class HealthManager : ResourceManager, IDamageable
{
    private ICharacter character;
    public float MaxHealth
    {
        get
        {
            if (character == null || character.Stats == null) return 0;
            return character.Stats.maxHealth.Value;
        }
    }
    private float health;

    public override float MaxValue => MaxHealth;
    public override float Value { get => health; protected set { health = value; } }

    float IDamageable.HitPoints => health;

    public event EventHandler HealthChanged;
    public event EventHandler Died;

    public float damageMultiplier = 1;

    private void Start()
    {
        character = GetComponent<ICharacter>();
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

        HealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Heal(float _health)
    {
        health += Math.Min(_health, MaxHealth - health); // prevent overhealing
        HealthChanged?.Invoke(this, EventArgs.Empty);
    }

    private void Die()
    {
        Died?.Invoke(this, EventArgs.Empty);
    }

    void IDamageable.OnDestroyed() => Die();
}
