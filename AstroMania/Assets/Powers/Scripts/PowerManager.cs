using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    [SerializeField] private List<PowerStack> powers;
    public IReadOnlyList<PowerStack> Powers => powers;
    [SerializeField] private PlayerController player;

    public event EventHandler<PowerStack> PowerAdded;
    public event EventHandler<Power> PowerRemoved;

    private void Start()
    {
        foreach (var powerStack in Powers)
        {
            powerStack.Power.player = player;
            powerStack.Activate();
        }

        player.PlayerDied += OnPlayerDeath;
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        foreach (var powerStack in Powers)
        {
            powerStack.Deactivate();
        }
    }

    private PowerStack GetPowerStack(Power powerData)
    {
        return powers.FirstOrDefault(powerStack => powerStack.Power == powerData);
    }

    public void AddPower(Power powerData)
    {
        // If the player already owns a lower level version of this power,
        // remove the lower level version and replace it with the next level one
        if (powerData.PrevLevel && GetPowerStack(powerData.PrevLevel) != null)
        {
            RemovePower(powerData.PrevLevel);
        }

        var powerStack = GetPowerStack(powerData);

        if (powerStack == null)
        {
            powerStack = new PowerStack(powerData, 1);
            powers.Add(powerStack);
        }
        // If this power is stackable and the player already owns it, then stack the power
        else if (powerData.Stackable)
        {
            powerStack.Stack();
        }

        powerData.player = player;
        powerData.Activate();
        PowerAdded?.Invoke(this, powerStack);
    }

    public void RemovePower(Power powerData)
    {
        var powerStack = GetPowerStack(powerData);
        powers.Remove(powerStack);
        powerStack.Deactivate();
        PowerRemoved?.Invoke(this, powerData);
    }
}

[Serializable]
public class PowerStack
{
    [field: SerializeField] public Power Power { get; private set; }
    [field: SerializeField] public int Count { get; private set; }

    public PowerStack(Power power, int initialCount)
    {
        this.Power = power;
        Count = initialCount;
    }

    public void Stack()
    {
        Count++;
    }

    public void Activate()
    {
        for (int i = 0; i < Count; i++)
        {
            Power.Activate();
        }
    }

    public void Deactivate()
    {
        for (int i = 0; i < Count; i++)
        {
            Power.Deactivate();
        }
    }
}