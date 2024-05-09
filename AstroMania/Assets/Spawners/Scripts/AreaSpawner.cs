using UnityEngine;

public class AreaSpawner : Spawner
{
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    protected override Vector2 GetSpawnPosition()
    {
        float xPos = Random.Range(minX, maxX);
        float yPos = Random.Range(minY, maxY);
        return new Vector2(xPos, yPos);
    }
}