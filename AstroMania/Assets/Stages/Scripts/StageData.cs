using UnityEngine;

[CreateAssetMenu(menuName = "Stage")]
public class StageData : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }

    [field: SerializeField] public EntityPool EnemyPool { get; private set; }
    [field: SerializeField] public float EnemySpawnInterval { get; private set; }
}