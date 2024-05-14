using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Damage over Time")]
public class DamageOverTimeData : StatusEffectData
{
    public float damagePerTick;
    public float interval;

    protected override StatusEffect ApplyEffect(StatusEffectManager target)
    {
        var effect = target.gameObject.AddComponent<DamageOverTime>();
        effect.damagePerTick = damagePerTick;
        effect.interval = interval;
        return effect;
    }
}