using UnityEngine;

public class SectorSpawner : Spawner
{
    private Sector Sector => transform.parent.GetComponent<Sector>();
    [SerializeField] private float MinX => Sector.Origin.x - Sector.Width / 2;
    [SerializeField] private float MaxX => Sector.Origin.x + Sector.Width / 2;
    [SerializeField] private float MinY => Sector.Origin.y - Sector.Width / 2;
    [SerializeField] private float MaxY => Sector.Origin.y + Sector.Width / 2;

    protected override Vector2 GetSpawnPosition()
    {
        float xPos = Random.Range(MinX, MaxX);
        float yPos = Random.Range(MinY, MaxY);
        return new Vector2(xPos, yPos);
    }
}