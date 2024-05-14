using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    public readonly List<StatusEffectData> effects = new();

    public void AddEffect(StatusEffectData statusEffect, float duration)
    {
        // Avoid stacking the same effect
        if (!effects.Contains(statusEffect))
        {
            statusEffect.ApplyEffect(this, duration);
            effects.Add(statusEffect);
        }
    }
}