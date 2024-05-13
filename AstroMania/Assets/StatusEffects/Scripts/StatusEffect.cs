using System;
using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{
    public float duration;

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
            Destroy(this); // Status effect is removed when effect duration ends
        }
    }

    private void OnDestroy()
    {
        RemoveEffect();
    }
}

[Serializable]
public abstract class StatusEffectArgs
{
    public float duration;
    public abstract void AddToTarget(StatusEffectManager effectManager);
    public StatusEffectArgs(float duration)
    {
        this.duration = duration;
    }
    
}