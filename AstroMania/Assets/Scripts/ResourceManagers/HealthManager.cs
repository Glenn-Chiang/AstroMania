using System;
using UnityEngine;

public class HealthManager : ResourceManager, IDamageable
{
    [SerializeField] private ICharacter character;

    private float MaxHealth => character.Stats.maxHealth.Value;
    private float health;

    public override float MaxValue => MaxHealth;
    public override float Value { get => health; protected set { health = value; } }

    float IDamageable.HitPoints => health;

    public event EventHandler OnDeath;

    private void Start()
    {
        character = GetComponent<ICharacter>();
        health = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage < health)
        {
            health -= damage;
        }
        else
        {
            health = 0;
            Die();
        }
    }

    public void Heal(float _health)
    {
        health += Math.Min(_health, MaxHealth - health); // prevent overhealing
    }

    private void Die()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);
    }
    void IDamageable.OnDestroyed() => Die();
}