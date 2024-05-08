using UnityEngine;

public abstract class OrbController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    protected OrbMagnet target; // Orb will move toward this target

    public void AttractTo(OrbMagnet magnet)
    {
        if (target == null)
        {
            target = magnet;
            return;
        }

        // If this magnet is closer to the orb than the current target, then switch the orb's target to this magnet
        if (GetDistance(magnet.transform) < GetDistance(target.transform))
        {
            target = magnet;
        }
    }

    private float GetDistance(Transform other)
    {
        return Vector2.Distance(transform.position, other.position);
    }

    private void Update()
    {
        if (target == null) return;

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponentInChildren<OrbMagnet>() != null)
        {
            EvokeEffect();
            Destroy(gameObject);
        }   
    }

    protected abstract void EvokeEffect();
}