using System;
using UnityEngine;

public class XPManager : ResourceManager
{
    private readonly float xpPerLevel = 20;
    private float totalXp = 0;
    public int Level => (int)(totalXp / xpPerLevel);
    public float CurrentLevelXp => totalXp % xpPerLevel; // XP earned at current level

    public override float MaxValue => xpPerLevel;
    public override float Value { get => CurrentLevelXp; protected set {  } }

    public event EventHandler<LevelUpEventArgs> LevelledUp;

    public void AddXp(float xpReward)
    {
        if (CurrentLevelXp + xpReward >= xpPerLevel)
        {
            totalXp += xpReward;
            LevelUp();
        } else
        {
            totalXp += xpReward;
        }
    }

    private void LevelUp()
    {
        Debug.Log("Level up");
        LevelledUp?.Invoke(this, new LevelUpEventArgs(Level));
    }
}

public class LevelUpEventArgs
{
    public readonly int level;
    public LevelUpEventArgs(int _level)
    {
        level = _level;
    }
}
