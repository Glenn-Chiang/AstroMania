using UnityEngine;

[CreateAssetMenu(menuName = "Power/Fire-rate Boost")]
public class FireRateBoost : StatBoost
{
    protected override Stat GetStat(PlayerStats playerStats) => playerStats.fireRateBonus;
}