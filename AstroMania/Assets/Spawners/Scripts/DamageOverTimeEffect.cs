using UnityEngine;

public class DamageOverTimeEffect : StatusEffect
{
    public HealthManager healthManager;
    public float damage; // Amount of damage to apply each interval
    public float interval; // How often the damage is applied

    public override void ApplyEffect()
    {
        healthManager = GetComponent<HealthManager>();
        InvokeRepeating(nameof(ApplyDamage), interval, interval);
    }

    private void ApplyDamage()
    {
        healthManager.TakeDamage(damage);
    }
 

}