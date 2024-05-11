using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    [SerializeField] private List<Power> powers;
    [SerializeField] private PlayerController player;

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
            powers.Remove(power.PrevLevel);
            power.PrevLevel.Deactivate();
        }

        powers.Add(power);
        power.player = player;
        power.Activate();
    }
}