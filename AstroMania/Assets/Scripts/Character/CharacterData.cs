using UnityEngine;

public abstract class CharacterData : EntityData
{
    [field: SerializeField] public float MaxHealth { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
}