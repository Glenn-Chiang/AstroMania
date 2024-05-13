using System;
using UnityEngine;

public class AdrenalineEffect : MonoBehaviour
{
    public PlayerController player;
    public float healthThreshold;
    public float multiplier;

    private bool effectIsActive = false;

    private void Start()
    {
        player.HealthManager.OnHealthChange += HandleHealthChange;
    }

    private void OnDestroy()
    {
        player.HealthManager.OnHealthChange -= HandleHealthChange;
    }

    private void HandleHealthChange(object sender, EventArgs e)
    {
        var health = player.HealthManager.Value;

        if (!effectIsActive && health < healthThreshold * player.HealthManager.MaxHealth)
        {
            player.Stats.damageBonus.ApplyMultiplier(multiplier);
            player.Stats.fireRateBonus.ApplyMultiplier(multiplier);
            player.Stats.moveSpeed.ApplyMultiplier(multiplier);
            effectIsActive = true;
        }
        
        if (effectIsActive && health >= healthThreshold * player.HealthManager.MaxHealth)
        {
            player.Stats.damageBonus.ApplyMultiplier(1 / multiplier);
            player.Stats.fireRateBonus.ApplyMultiplier(1 / multiplier);
            player.Stats.moveSpeed.ApplyMultiplier(1 / multiplier);
            effectIsActive = false;
        }
        
    }
}