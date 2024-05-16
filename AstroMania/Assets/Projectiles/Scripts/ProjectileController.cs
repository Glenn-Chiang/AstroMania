using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public List<StatusEffectApplier> effectAppliers;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        HitTarget(collision.collider.gameObject);
        Destroy(gameObject);
    }

    protected void HitTarget(GameObject target)
    {
        if (target.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage);
        }
        
        if (target.TryGetComponent<StatusEffectManager>(out var effectManager))
        {
            foreach (var effectApplier in effectAppliers)
            {
                effectApplier.Apply(effectManager);
            }
        }
    }
}
