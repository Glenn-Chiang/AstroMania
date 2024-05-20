using System;
using UnityEngine;

public class Player : Character
{
    public static Player Instance { get; private set; }

    [SerializeField] private PlayerData playerData;
    public override CharacterData CharacterData => playerData;

    public PlayerStats PlayerStats { get; private set; }
    public override CharacterStats Stats => PlayerStats;

    [field: SerializeField] public PlayerMovement Movement { get; private set; }
    [field: SerializeField] public WeaponManager WeaponManager { get; private set; }
    [field: SerializeField] public HealthManager HealthManager { get; private set; }
    [field: SerializeField] public EnergyManager EnergyManager { get; private set; }
    [SerializeField] private XPManager xpManager;

    public event EventHandler PlayerDied;

    protected override void InitializeStats()
    {
        PlayerStats = new PlayerStats(playerData);
    }

    protected override void Awake()
    {
        base.Awake();

        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        xpManager.LevelledUp += HandleLevelUp;
        HealthManager.Died += HandleDeath;

        EnemyAI.OnEnemyDeath += HandleEnemyDeath;   
    }

    private void HandleLevelUp(object sender, LevelUpEventArgs e)
    {
        HealthManager.Replenish(0.5f);
        EnergyManager.Replenish(0.5f);
    }

    private void HandleDeath(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
        PlayerDied?.Invoke(this, EventArgs.Empty);
    }

    private void HandleEnemyDeath(object sender, EnemyDeathEventArgs e)
    {
        var enemyData = e.enemyData;
        xpManager.AddXp(enemyData.XpReward);
    }

    private void OnDestroy()
    {
        EnemyAI.OnEnemyDeath -= HandleEnemyDeath;
    }
}