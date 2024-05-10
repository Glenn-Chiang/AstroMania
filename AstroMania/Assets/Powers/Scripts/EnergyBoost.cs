using UnityEngine;

[CreateAssetMenu(menuName = "Power/Energy Boost")]
public class EnergyBoost : StatBoost
{
    protected override Stat GetStat(PlayerStats playerStats) => playerStats.maxEnergy;
}