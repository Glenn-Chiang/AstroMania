using UnityEngine;

public class EnergyManager : ResourceManager
{
    [SerializeField] private PlayerController player;

    private float MaxEnergy => player.Stats.maxEnergy.Value;
    private float energy;

    public override float MaxValue => MaxEnergy;
    public override float Value => energy;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        energy = MaxEnergy;
    }

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
        energy += Mathf.Min(energyAdded, MaxEnergy - energy);
    }
}