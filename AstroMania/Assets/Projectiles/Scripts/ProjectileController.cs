using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public List<StatusEffectApplier> effectAppliers;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage);
        }
        
        if (collision.collider.TryGetComponent<StatusEffectManager>(out var target))
        {
            foreach (var effectApplier in effectAppliers)
            {
                effectApplier.Apply(target);
            }
        }

        Destroy(gameObject);
    }

}
