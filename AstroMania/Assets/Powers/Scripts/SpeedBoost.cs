using UnityEngine;

[CreateAssetMenu(menuName = "Power/Speed Boost")]
public class SpeedBoost : StatBoost
{
    protected override Stat GetStat(PlayerStats playerStats) => playerStats.moveSpeed;
}