using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private List<EntityPool> enemyPools;
    private int currentPoolIndex = 0;
    private EntityPool CurrentPool => enemyPools[currentPoolIndex];

    [SerializeField] private Spawner spawner;
    [SerializeField] private float spawnInterval; // How often to spawn next batch of enemies
    [SerializeField] private int batchSize; // How many enemies to spawn each interval

    [SerializeField] private float poolChangeInterval; // How often to advance to next pool of enemies

    private void Awake()
    {
        spawner.entityPool = CurrentPool;
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBatch), spawnInterval, spawnInterval);
        InvokeRepeating(nameof(NextPool), poolChangeInterval, poolChangeInterval);
    }

    private void SpawnBatch()
    {
        spawner.SpawnRandomEntities(batchSize);
    }

    private void NextPool()
    {
        Debug.Log("next pool");
        if (currentPoolIndex < enemyPools.Count - 1)
        {
            currentPoolIndex++;
        } else
        {
            CancelInvoke(nameof(NextPool));
        }
    }
}