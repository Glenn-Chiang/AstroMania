using UnityEngine;

public class OrbMagnet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<OrbController>(out var orb))
        {
            orb.AttractTo(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}