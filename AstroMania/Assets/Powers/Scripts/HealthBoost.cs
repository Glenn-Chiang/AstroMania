using UnityEngine;

[CreateAssetMenu(menuName = "Power/Health Boost")]
public class HealthBoost : StatBoost
{
    protected override Stat GetStat(PlayerStats playerStats) => playerStats.maxHealth;
}