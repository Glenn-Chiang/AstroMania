using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, ICharacter
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] private PlayerCharacterData characterData;
    CharacterData  ICharacter.CharacterData => characterData;
    public PlayerStats Stats { get; private set; }
    CharacterStats ICharacter.Stats => Stats;

    [field: SerializeField] public PlayerMovement Movement { get; private set; }
    [field: SerializeField] public WeaponManager WeaponManager { get; private set; }
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private EnergyManager energyManager;
    [SerializeField] private XPManager xpManager;

    public event EventHandler OnGameOver;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        Stats = new(characterData);
    }

    private void Start()
    {
        xpManager.OnLevelUp += HandleLevelUp;
        healthManager.OnDeath += HandleDeath;

        EnemyAI.OnEnemyDeath += HandleEnemyDeath;   
    }

    private void HandleLevelUp(object sender, LevelUpEventArgs e)
    {
        Stats.Upgrade();
        healthManager.Replenish();
        energyManager.Replenish();
    }

    private void HandleDeath(object sender, EventArgs e)
    {
        Debug.Log("Player died");
        Destroy(gameObject);
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

    private void HandleEnemyDeath(object sender, EnemyDeathEventArgs e)
    {
        var enemyData = e.enemyData;
        xpManager.AddXp(enemyData.XpReward);
    }
}