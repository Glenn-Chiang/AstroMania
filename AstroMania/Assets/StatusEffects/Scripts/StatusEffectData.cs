using UnityEngine;

public abstract class StatusEffectData : ScriptableObject 
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, TextArea(2,3)] public string Description { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }

    public void ApplyEffect(StatusEffectManager target, float duration)
    {
        var effect = ApplyEffect(target);
        effect.effectData = this;
        effect.effectManager = target;
        effect.duration = duration;
    }

    protected abstract StatusEffect ApplyEffect(StatusEffectManager target);
}

