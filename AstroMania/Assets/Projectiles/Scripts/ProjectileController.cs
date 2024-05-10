using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float damage;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<IDamageable>(out var damageableObject))
        {
            damageableObject.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
