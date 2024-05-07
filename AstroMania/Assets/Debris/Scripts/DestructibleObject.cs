using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour, IDamageable
{
    [SerializeField] private float hitPoints;
    public float HitPoints => hitPoints;

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            OnDestroyed();
        }
    }

    public void OnDestroyed()
    {
        Destroy(gameObject);
    }
}
