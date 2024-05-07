using System;
using UnityEngine;

public class HealthManager : ResourceManager, IDamageable
{
    [SerializeField] private float maxHealth;
    private float health;

    public override float MaxValue => maxHealth;
    public override float Value => health;


    float IDamageable.HitPoints => health;

    public event EventHandler OnDeath;

    private void Start()
    {
        health = maxHealth;
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
        health += Math.Min(_health, maxHealth - health); // prevent overhealing
    }

    public void HealToFull()
    {
        health = maxHealth;
    }

    private void Die()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);
    }
    void IDamageable.OnDestroyed() => Die();
}