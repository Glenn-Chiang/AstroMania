using UnityEngine;

public abstract class CharacterData : EntityData
{
    [field: SerializeField] public Stat MaxHealth { get; private set; }
    [field: SerializeField] public Stat MoveSpeed { get; private set; }
    [field: SerializeField] public Stat DamageBonus { get; private set; }
    [field: SerializeField] public Stat FireRateBonus { get; private set; }
}