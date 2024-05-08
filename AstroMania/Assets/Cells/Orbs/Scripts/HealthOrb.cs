using UnityEngine;

public class HealthOrb : OrbController
{
    [SerializeField] private float healAmount = 1f;
    protected override void EvokeEffect()
    {
        var healthManager = target.GetComponentInParent<HealthManager>();
        if (healthManager != null)
        {
            healthManager.Heal(healAmount);
        }
    }
}