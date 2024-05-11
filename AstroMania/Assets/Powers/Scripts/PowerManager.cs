using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    [SerializeField] private List<Power> powers;
    [SerializeField] private PlayerController player;

    private void Start()
    {
        foreach (var power in powers)
        {
            power.player = player;
            power.Activate();
        }
    }

    public bool HasPower(Power power)
    {
        return powers.Contains(power);
    }

    public void AddPower(Power power)
    {
        // If the player already owns a lower level version of this power,
        // remove the lower level version and replace it with the next level one
        if (power.PrevLevel && powers.Contains(power.PrevLevel))
        {
            RemovePower(power.PrevLevel);
        }

        powers.Add(power);
        power.player = player;
        power.Activate();
    }

    public void RemovePower(Power power)
    {
        powers.Remove(power);
        power.Deactivate();
    }
}