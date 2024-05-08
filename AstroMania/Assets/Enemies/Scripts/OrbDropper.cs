using UnityEngine;

public class OrbDropper : MonoBehaviour
{
    [SerializeField] private OrbController orb;

    public void DropOrbs(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(orb, GetRandomPosition(), Quaternion.identity);
        }
    }

    private Vector2 GetRandomPosition()
    {
        float randomXOffset = Random.Range(-0.5f, 0.5f);
        float randomYOffset = Random.Range(-0.5f, 0.5f);
        return new Vector2(transform.position.x + randomXOffset, transform.position.y + randomYOffset);
    }
}