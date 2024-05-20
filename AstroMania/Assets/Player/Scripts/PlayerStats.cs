using UnityEngine;

public class PlayerStats : CharacterStats
{
    public readonly Stat maxEnergy;

    public PlayerStats(PlayerData data) : base(data)
    {
        maxEnergy = new(data.MaxEnergy.BaseValue);
    }
}