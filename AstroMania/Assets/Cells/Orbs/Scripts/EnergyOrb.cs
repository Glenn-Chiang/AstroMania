using UnityEngine;

public class EnergyOrb : OrbController
{
    [SerializeField] private float energyAmount = 1f;
    protected override void EvokeEffect()
    {
        var energyManager = target.GetComponentInParent<EnergyManager>();
        if (energyManager != null)
        {
            energyManager.AddEnergy(energyAmount);
        }
    }
}