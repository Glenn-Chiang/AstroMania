using UnityEngine;

[CreateAssetMenu(menuName = "Power/Lifesteal")]
public class LifeSteal : Power
{
    [SerializeField] private float stealProportion; // Proportion of the enemy's health to steal
    public override void Activate()
    {
        EnemyAI.OnEnemyDeath += EnemyDeathEventHandler;
    }

    public override void Deactivate()
    {
        EnemyAI.OnEnemyDeath -= EnemyDeathEventHandler;
    }

    private void EnemyDeathEventHandler(object sender, EnemyDeathEventArgs e)
    {
        player.HealthManager.Heal(e.enemyData.MaxHealth.Value * stealProportion);
    }
}