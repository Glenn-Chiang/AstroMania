using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private Spawner spawner;

    [SerializeField] private float spawnInterval;
    [SerializeField] private int batchSize; // How many enemies to spawn each interval
    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnBatch();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnBatch()
    {
        spawner.SpawnRandomEntities(batchSize);
    }
}