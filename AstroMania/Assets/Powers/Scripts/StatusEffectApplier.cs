using UnityEngine;

public abstract class StatusEffectApplier<T> : Power, IStatusEffectApplier where T : StatusEffectArgs
{
    [SerializeField] private T effectArgs;
    [SerializeField] private float probability;

    public override void Activate()
    {
        player.WeaponManager.effectAppliers.Add(this);
    }

    public void Apply(StatusEffectManager target)
    {
        // Random chance to apply the effect or not
        if (RandomUtils.WeightedRandomBoolean(probability))
        {
            effectArgs.AddToTarget(target);
        }
    }

    void IStatusEffectApplier.Apply(StatusEffectManager target) => Apply(target);
}

public interface IStatusEffectApplier
{
    void Apply(StatusEffectManager target);
}