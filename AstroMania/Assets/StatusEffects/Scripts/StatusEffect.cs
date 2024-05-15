using System;
using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{
    public float duration;
    public StatusEffectData effectData;
    public StatusEffectManager effectManager;
    public abstract void ApplyEffect();
    public virtual void RemoveEffect() { }

    private void Start()
    {
        ApplyEffect();
    }

    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            RemoveEffect();
            Destroy(this); // Status effect is removed when effect duration ends
            effectManager.RemoveEffect(effectData);
        }
    }
}

