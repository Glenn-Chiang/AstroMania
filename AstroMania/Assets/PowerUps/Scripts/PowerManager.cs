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
        powers.Add(power);
        power.player = player;
        power.Activate();
    }
}