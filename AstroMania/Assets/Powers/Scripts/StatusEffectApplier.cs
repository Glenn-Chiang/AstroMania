using UnityEngine;

[CreateAssetMenu(menuName = "Power/Status Effect Applier")]
public class StatusEffectApplier : Power
{
    [SerializeField] private float probability;
    [SerializeField] private float duration;
    [SerializeField] private StatusEffectData statusEffect;

    public override void Activate()
    {
        player.WeaponManager.effectAppliers.Add(this);
    }

    public void Apply(StatusEffectManager target)
    {
        // Random chance to apply the effect or not
        if (RandomUtils.WeightedRandomBoolean(probability))
        {
            statusEffect.ApplyEffect(target, duration);
        }
    }
}

