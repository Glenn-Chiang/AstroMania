using System;
using UnityEngine;

public class AdrenalineEffect : MonoBehaviour
{
    public Player player;
    public float healthThreshold;
    public float multiplier;

    private bool effectIsActive = false;

    private void Start()
    {
        player.HealthManager.HealthChanged += HandleHealthChange;
    }

    private void OnDestroy()
    {
        player.HealthManager.HealthChanged -= HandleHealthChange;
    }

    private void HandleHealthChange(object sender, EventArgs e)
    {
        var health = player.HealthManager.Value;

        if (!effectIsActive && health < healthThreshold * player.HealthManager.MaxHealth)
        {
            player.PlayerStats.damageBonus.ApplyMultiplier(multiplier);
            player.PlayerStats.fireRateBonus.ApplyMultiplier(multiplier);
            player.PlayerStats.moveSpeed.ApplyMultiplier(multiplier);
            effectIsActive = true;
        }
        
        if (effectIsActive && health >= healthThreshold * player.HealthManager.MaxHealth)
        {
            player.PlayerStats.damageBonus.ApplyMultiplier(1 / multiplier);
            player.PlayerStats.fireRateBonus.ApplyMultiplier(1 / multiplier);
            player.PlayerStats.moveSpeed.ApplyMultiplier(1 / multiplier);
            effectIsActive = false;
        }
        
    }
}