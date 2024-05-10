using Unity.VisualScripting;
using UnityEngine;

public class RocketController : ProjectileController
{
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float blastRadius;
    [SerializeField] private float blastForce;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        Vector2 blastOrigin = transform.position;
        
        Instantiate(explosionEffect, blastOrigin, transform.rotation);

        var hitObjects = Physics2D.OverlapCircleAll(blastOrigin, blastRadius);
        
        foreach ( var hitObject in hitObjects )
        {
            if (hitObject.TryGetComponent<Rigidbody2D>(out var rb))
            {
                var blastDir = rb.position - blastOrigin;
                var blastDistance = blastDir.magnitude;
                blastDir /= blastDistance;
                var forceVector = Mathf.Lerp(0, blastForce, (1 - blastDistance)) * blastDir;
                rb.AddForce(forceVector, ForceMode2D.Impulse);
            }

            if (hitObject.TryGetComponent<IDamageable>(out var damageableObject))
            {
                damageableObject.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }
}