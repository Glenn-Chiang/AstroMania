using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    public void Effect()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}