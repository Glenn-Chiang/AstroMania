using System;
using UnityEngine;

public class Freeze : StatusEffect
{
    public override void ApplyEffect()
    {
        var stats = GetComponent<ICharacter>().Stats;
        stats.moveSpeed.ApplyMultiplier(0);
        stats.fireRateBonus.ApplyMultiplier(0);
        
    }
}

[Serializable]
public class FreezeArgs : StatusEffectArgs
{
    public FreezeArgs(float duration) : base(duration)
    {
    }

    public override void AddToTarget(StatusEffectManager effectManager)
    {
        effectManager.AddFreeze(this);
    }
}