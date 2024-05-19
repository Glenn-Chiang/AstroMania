using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnergyManager : ResourceManager
{
    [SerializeField] private PlayerController player;

    private float MaxEnergy
    {
        get
        {
            if (player == null || player.Stats == null) return 0;
            return player.Stats.maxHealth.Value;
        }
    }
    private float energy;

    public override float MaxValue => MaxEnergy;
    public override float Value { get => energy; protected set { energy = value; } }

    public float consumptionMultiplier = 1f;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        energy = MaxEnergy;
    }

    public bool ConsumeEnergy(float energyToConsume)
    {
        energyToConsume *= consumptionMultiplier;

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