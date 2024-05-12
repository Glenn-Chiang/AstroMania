using UnityEngine;

[CreateAssetMenu(menuName = "Power/Energy Efficiency")]
public class EnergyEfficiency : Power
{
    [SerializeField] private float multiplier;

    public override void Activate()
    {
        player.EnergyManager.consumptionMultiplier *= multiplier;
    }

    public override void Deactivate()
    {
        player.EnergyManager.consumptionMultiplier /= multiplier;
    }
}