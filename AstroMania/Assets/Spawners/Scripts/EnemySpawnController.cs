using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private StageManager stageManager;
    private EntityPool currentPool;

    [SerializeField] private Spawner spawner;
    [SerializeField] private float spawnInterval; // How often to spawn next batch of enemies
    [SerializeField] private int batchSize; // How many enemies to spawn each interval
    
    private void Start()
    {
        stageManager.StageChanged += OnStageChanged;
        InvokeRepeating(nameof(SpawnBatch), spawnInterval, spawnInterval);   
    }

    private void OnStageChanged(object sender, StageData stage)
    {
        currentPool = stage.EnemyPool;
    }

    private void SpawnBatch()
    {
        spawner.SpawnRandomEntities(batchSize);
    }
}