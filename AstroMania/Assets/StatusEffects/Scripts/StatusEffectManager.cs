using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    public T AddEffect<T>(StatusEffectArgs effectArgs) where T : StatusEffect
    {
        // Don't add the status effect is the entity already has this status effect
        if (gameObject.GetComponent<T>() != null)
        {
            return null;
        }

        var effect = gameObject.AddComponent<T>();
        effect.duration = effectArgs.duration;
        return effect;
    }

    public void AddDamageOverTime(DamageOverTimeArgs effectArgs)
    {
        var effect = AddEffect<DamageOverTime>(effectArgs);
        if (effect != null)
        {
            effect.damage = effectArgs.damage;
            effect.interval = effectArgs.interval;
        }
    }

    public void AddFreeze(FreezeArgs effectArgs)
    {
        AddEffect<Freeze>(effectArgs);
    }
}