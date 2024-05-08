using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyData : CharacterData
{
    [field: SerializeField] public float XpReward { get; private set; }
    [field: SerializeField] public float AttackInterval { get; private set; }
}