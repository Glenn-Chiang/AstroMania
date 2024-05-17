using UnityEngine;

public class SafeZone : MonoBehaviour
{
    [SerializeField] private float activeDuration;

    private void Awake()
    {
        Invoke(nameof(Expire), activeDuration);
    }

    private void Expire()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
