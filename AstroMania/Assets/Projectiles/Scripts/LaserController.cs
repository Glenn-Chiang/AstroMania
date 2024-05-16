using UnityEngine;

public class LaserController : ProjectileController
{
    protected override void OnCollisionEnter2D(Collision2D collision){}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        HitTarget(collider.gameObject);
    }
}