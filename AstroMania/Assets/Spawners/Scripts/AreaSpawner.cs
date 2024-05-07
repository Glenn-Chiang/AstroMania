using UnityEngine;

public class AreaSpawner : Spawner
{
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float MinY;
    [SerializeField] private float MaxY;

    protected override Vector2 GetSpawnPosition()
    {
        float xPos = Random.Range(minX, maxX);
        float yPos = Random.Range(MinY, MaxY);
        return new Vector2(xPos, yPos);
    }
}