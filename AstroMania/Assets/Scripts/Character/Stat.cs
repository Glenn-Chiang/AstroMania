using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Stat
{
    [field: SerializeField] public float BaseValue { get; private set; }
    private readonly List<float> multipliers = new();
    public float Value => multipliers.Aggregate(BaseValue, (current, multiplier) => current * multiplier);

    public Stat(float baseValue)
    {
        Debug.Log(baseValue);
        BaseValue = baseValue;
    }
    
    public int ApplyMultiplier(float multiplier)
    {
        multipliers.Add(multiplier);
        return multipliers.Count - 1; // Return the index of the multiplier that was added, allowing it to be subsequently removed by index
    }

    public void RemoveMultiplier(int index)
    {
        multipliers[index] = 1; // We don't actually remove the multiplier from the list because doing so would change the indices of the other multipliers
    }
}