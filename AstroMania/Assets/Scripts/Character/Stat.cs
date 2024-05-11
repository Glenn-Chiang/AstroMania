using System;
using UnityEngine;

[Serializable]
public class Stat
{
    [field: SerializeField] public float Value { get; private set; }

    public Stat(float baseValue)
    {
        Value = baseValue;
    }
    
    public void ApplyMultiplier(float multiplier)
    {
        Value *= multiplier;
    }
}