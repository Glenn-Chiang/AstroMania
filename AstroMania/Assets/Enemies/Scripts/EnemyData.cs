using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyData : EntityData
{
    [field: SerializeField] public float XpReward { get; private set; }
}