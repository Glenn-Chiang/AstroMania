using UnityEngine;

public abstract class StatBoost : Power
{
    [SerializeField] private float multiplier;
    protected abstract Stat GetStat(PlayerStats playerStats);
    public override void Activate()
    {
        var stat = GetStat(player.PlayerStats);
        stat.ApplyMultiplier(multiplier);
    }
}