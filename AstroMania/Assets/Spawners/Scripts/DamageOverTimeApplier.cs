using UnityEngine;

public class DamageOverTimeApplier : StatusEffectApplier<DamageOverTimeEffect>
{
    [SerializeField] private float damage; // Amount of damage to apply each interval
    [SerializeField] private float interval; // How often the damage is applied

    public override DamageOverTimeEffect Apply(GameObject target)
    {
        var effect = base.Apply(target);
        if (effect == null) return null;

        effect.damage = damage;
        effect.interval = interval;
        return effect;
    }
}