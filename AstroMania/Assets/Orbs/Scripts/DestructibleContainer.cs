using UnityEngine;

public class DestructibleContainer : DestructibleObject
{
    [SerializeField] private GameObject obj; // When the container is destroyed, this object will be spawned
    [SerializeField] private int count;

    public override void OnDestroyed()
    {
        base.OnDestroyed();
        ReleaseObject();
    }

    public void ReleaseObject()
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(obj, GetRandomPosition(), Quaternion.identity);
        }
    }

    private Vector2 GetRandomPosition()
    {
        float randomXOffset = Random.Range(-0.5f, 0.5f);
        float randomYOffset = Random.Range(-0.5f, 0.5f);
        return new Vector2(transform.position.x + randomXOffset, transform.position.y + randomYOffset);
    }
}