using System;
using UnityEngine;

public class Freeze : StatusEffect
{
    private CharacterStats stats;
    private int moveSpeedMultiplierIndex;
    private int fireRateBonusMultiplierIndex;

    public override void ApplyEffect()
    {
        stats = GetComponent<Character>().Stats;
        moveSpeedMultiplierIndex = stats.moveSpeed.ApplyMultiplier(0);
        fireRateBonusMultiplierIndex = stats.fireRateBonus.ApplyMultiplier(0);
    }

    public override void RemoveEffect()
    {
        stats.moveSpeed.RemoveMultiplier(moveSpeedMultiplierIndex);
        stats.fireRateBonus.RemoveMultiplier(fireRateBonusMultiplierIndex);
    }
}

