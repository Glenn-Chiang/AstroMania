using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private List<WeightedElement<GameObject>> entities;

    [SerializeField] private int spawnCount;

    private void Awake()
    {
        SpawnRandomEntities(spawnCount);
    }

    public void SpawnRandomEntities(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnRandomEntity();
        }
    }

    public void SpawnEntity(GameObject entity)
    {
        var spawnPosition = GetSpawnPosition();
        Instantiate(entity, spawnPosition, Quaternion.identity);
    }


    public void SpawnRandomEntity()
    {
        var spawnPosition = GetSpawnPosition();
        var entity = RandomUtils.WeightedRandomSelect(entities);
        Instantiate(entity, spawnPosition, Quaternion.identity);
    }

    protected abstract Vector2 GetSpawnPosition();
}