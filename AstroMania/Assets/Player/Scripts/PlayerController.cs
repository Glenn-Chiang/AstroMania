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
    [field: SerializeField] public HealthManager HealthManager { get; private set; }
    [field: SerializeField] public EnergyManager EnergyManager { get; private set; }
    [SerializeField] private XPManager xpManager;

    public event EventHandler PlayerDied;

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
        HealthManager.OnDeath += HandleDeath;

        EnemyAI.OnEnemyDeath += HandleEnemyDeath;   
    }

    private void HandleLevelUp(object sender, LevelUpEventArgs e)
    {
        HealthManager.Replenish(0.5f);
        EnergyManager.Replenish(0.5f);
    }

    private void HandleDeath(object sender, EventArgs e)
    {
        Debug.Log("Player died");
        Destroy(gameObject);
        PlayerDied?.Invoke(this, EventArgs.Empty);
    }

    private void HandleEnemyDeath(object sender, EnemyDeathEventArgs e)
    {
        var enemyData = e.enemyData;
        xpManager.AddXp(enemyData.XpReward);
    }
}