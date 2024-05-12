using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public List<StatusEffectApplier<StatusEffect>> effectAppliers;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage);
        }
        
        if (collision.collider.TryGetComponent<ICharacter>(out var character))
        {
            ApplyEffects(collision.collider.gameObject);
        }

        Destroy(gameObject);
    }

    private void ApplyEffects(GameObject target)
    {
        foreach (var effectApplier in effectAppliers)
        {
            effectApplier.Apply(target);
        }
    }
}
