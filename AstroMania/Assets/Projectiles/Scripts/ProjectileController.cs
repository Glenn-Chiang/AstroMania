using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<IDamageable>(out var damageableObject))
        {
            damageableObject.TakeDamage();
        }
        Destroy(gameObject);
    }
}
