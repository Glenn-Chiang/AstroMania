using UnityEngine;

[CreateAssetMenu(menuName = "Power/Renewable Energy")]
public class RenewableEnergy : Power
{
    [SerializeField] private float proportion; // Proportion of your max energy to regain
    public override void Activate()
    {
        EnemyAI.OnEnemyDeath += EnemyDeathEventHandler;
    }

    private void EnemyDeathEventHandler(object sender, EnemyDeathEventArgs e)
    {
        player.EnergyManager.AddEnergy(player.Stats.maxEnergy.Value * proportion);
    }
}