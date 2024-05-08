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

    public virtual void OnDestroyed()
    {
        Destroy(gameObject);
    }
}
