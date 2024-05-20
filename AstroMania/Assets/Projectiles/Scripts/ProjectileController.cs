using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public List<StatusEffectApplier> effectAppliers;

    private void Start()
    {
        Invoke(nameof(SelfDestruct), 10); // Porjectile will destroy itself if it does not collide with anything after 10 seconds
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        HitTarget(collision.collider.gameObject);
        SelfDestruct();
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
    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
