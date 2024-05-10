using UnityEngine;

[CreateAssetMenu(menuName = "Power/Damage Boost")]
public class DamageBoost : StatBoost
{
    protected override Stat GetStat(PlayerStats playerStats) => playerStats.damageBonus;
}