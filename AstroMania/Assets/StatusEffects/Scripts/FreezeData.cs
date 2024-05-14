using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect/Freeze")]
public class FreezeData : StatusEffectData
{
    protected override StatusEffect ApplyEffect(StatusEffectManager target)
    {
        var effect = target.gameObject.AddComponent<Freeze>();
        return effect;
    }
}