using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private StageManager StageManager => StageManager.Instance;
    private EntityPool currentPool;

    [SerializeField] private Spawner spawner;
    [SerializeField] private float spawnInterval; // How often to spawn next batch of enemies
    [SerializeField] private int batchSize; // How many enemies to spawn each interval
    
    private void Start()
    {
        currentPool = StageManager.CurrentStage.EnemyPool;
        StageManager.StageChanged += OnStageChanged;
        InvokeRepeating(nameof(SpawnBatch), spawnInterval, spawnInterval);   
    }

    private void OnStageChanged(object sender, StageData stage)
    {
        currentPool = StageManager.CurrentStage.EnemyPool;
    }

    private void SpawnBatch()
    {
        spawner.SpawnRandomEntities(batchSize);
    }
}