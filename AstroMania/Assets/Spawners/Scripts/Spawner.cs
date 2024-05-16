using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public EntityPool entityPool;

    [SerializeField] private int initialSpawnCount;

    private void Awake()
    {
        SpawnRandomEntities(initialSpawnCount);
    }

    public void SpawnRandomEntities(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnRandomEntity();
        }
    }

    public void SpawnRandomEntity()
    {
        var spawnPosition = GetSpawnPosition();
        var entity = RandomUtils.WeightedSelectRandom(entityPool.Entities);
        Instantiate(entity, spawnPosition, RandomRotation());
    }

    private Quaternion RandomRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    protected abstract Vector2 GetSpawnPosition();
}