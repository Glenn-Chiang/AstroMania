using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private StageManager StageManager => StageManager.Instance;
 
    [SerializeField] private Spawner spawner;
    private float SpawnInterval => StageManager.CurrentStage.EnemySpawnInterval;
    
    private void Start()
    {
        StageManager.StageChanged += OnStageChanged;
        InvokeRepeating(nameof(Spawn), SpawnInterval, SpawnInterval);   
    }

    private void OnStageChanged(object sender, StageData stage)
    {
        spawner.entityPool = stage.EnemyPool;
    }

    private void Spawn()
    {
        spawner.SpawnRandomEntity();
    }
}