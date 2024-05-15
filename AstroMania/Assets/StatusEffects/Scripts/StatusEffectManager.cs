using System;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    public readonly List<StatusEffectData> effects = new();
    public event EventHandler<StatusEffectData> EffectAdded;
    public event EventHandler<StatusEffectData> EffectRemoved;

    public void AddEffect(StatusEffectData statusEffect, float duration)
    {
        // Avoid stacking the same effect
        if (!effects.Contains(statusEffect))
        {
            statusEffect.ApplyEffect(this, duration);
            effects.Add(statusEffect);
            EffectAdded?.Invoke(this, statusEffect);
        }
    }

    public void RemoveEffect(StatusEffectData statusEffect)
    {
        effects.Remove(statusEffect);
        EffectRemoved?.Invoke(this, statusEffect);
    }
}