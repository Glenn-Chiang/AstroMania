using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    [field: SerializeField] public PlayerMovement Movement { get; private set; }
    [field: SerializeField] public WeaponManager WeaponManager { get; private set; }
    
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private XPManager xpManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        EnemyAI.OnEnemyDeath += HandleEnemyDeath;       
    }

    private void HandleEnemyDeath(object sender, EnemyDeathEventArgs e)
    {
        var enemyData = e.enemyData;
        xpManager.AddXp(enemyData.XpReward);
    }
}