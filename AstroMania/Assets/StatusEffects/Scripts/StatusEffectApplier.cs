using UnityEngine;

public abstract class StatusEffectApplier<T> : ScriptableObject where T : StatusEffect
{
    [SerializeField] private float duration;
    [SerializeField] private float probability; 

    public virtual T Apply(GameObject target)
    {
        // Random chance to apply the effect or not
        if (!RandomUtils.WeightedRandomBoolean(probability))
        {
            return null;
        }
        
        var effect = target.AddComponent<T>();
        effect.duration = duration;
        return effect;
    }
}