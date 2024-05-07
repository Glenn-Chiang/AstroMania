using UnityEngine;

public class EnergyManager : ResourceManager
{
    [SerializeField] private float maxEnergy;
    private float energy;

    public override float MaxValue => maxEnergy;
    public override float Value => energy;

    public bool ConsumeEnergy(float energyToConsume)
    {
        if (energy < energyToConsume)
        {
            return false;
        }

        energy -= energyToConsume;
        return true;
    }

    public void AddEnergy(float energyAdded)
    {
        energy += Mathf.Min(energyAdded, maxEnergy - energy);
    }
}