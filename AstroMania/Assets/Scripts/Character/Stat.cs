using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    [field: SerializeField] public List<float> Levels { get; private set; }
    private int currentLevel = 0;
    public float Value => Levels[currentLevel];

    public Stat(List<float> levels)
    {
        Levels = levels;
    }
    
    public void Upgrade()
    {
        if (currentLevel == Levels.Count - 1) return; // Maxed out
        currentLevel++;
    }
}