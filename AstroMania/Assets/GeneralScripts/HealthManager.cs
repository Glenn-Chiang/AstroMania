using System;
using UnityEngine;

public class HealthManager : MonoBehaviour, IDamageable
{
    private float maxHealth;
    private float health;

    float IDamageable.HitPoints => health;

    public event EventHandler OnDeath;

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