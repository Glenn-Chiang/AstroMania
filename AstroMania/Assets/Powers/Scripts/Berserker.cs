using UnityEngine;

[CreateAssetMenu(menuName = "Power/Berserker")]
public class Berserker : Power
{
    [SerializeField] private float outgoingDamageMultiplier;
    [SerializeField] private float incomingDamageMultiplier;
    public override void Activate()
    {
        player.Stats.damageBonus.ApplyMultiplier(outgoingDamageMultiplier);
        player.HealthManager.damageMultiplier = incomingDamageMultiplier;
    }
}