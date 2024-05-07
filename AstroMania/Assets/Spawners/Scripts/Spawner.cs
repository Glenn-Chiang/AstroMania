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

    public void SpawnRandomEntity()
    {
        var spawnPosition = GetSpawnPosition();
        var entity = RandomUtils.WeightedRandomSelect(entities);
        Instantiate(entity, spawnPosition, RandomRotation());
    }

    private Quaternion RandomRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    protected abstract Vector2 GetSpawnPosition();
}