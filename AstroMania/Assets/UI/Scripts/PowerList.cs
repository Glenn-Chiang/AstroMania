using System.Collections.Generic;
using UnityEngine;

public class PowerList : MonoBehaviour
{
    [SerializeField] private PowerManager powerManager;
    [SerializeField] private Transform listContent;
    [SerializeField] private ItemSlot itemSlotPrefab;

    private Dictionary<Power, ItemSlot> displayedPowers = new();

    private void Start()
    {
        foreach (var powerStack in powerManager.Powers)
        {
            DisplayPower(powerStack);
        }

        powerManager.PowerAdded += OnPowerAdded;
        powerManager.PowerRemoved += OnPowerRemoved;
    }

    private void OnPowerAdded(object sender, PowerStack powerStack)
    {
        DisplayPower(powerStack);
    }

    private void OnPowerRemoved(object sender, Power power)
    {
        var slot = displayedPowers[power];
        Destroy(slot.gameObject);
        displayedPowers.Remove(power);
    }

    private void DisplayPower(PowerStack powerStack)
    {
        var power = powerStack.Power;
        if (!displayedPowers.ContainsKey(power))
        {
            var slot = Instantiate(itemSlotPrefab, listContent);
            slot.NameText.text = power.Name;
            slot.Image.sprite = power.Sprite;
            slot.Image.preserveAspect = true;
            slot.DescriptionText.text = power.Description;
            displayedPowers.Add(power, slot);
        }
        // If this power is already displayed and it is stackable, update the displayed stack count
        if (power.Stackable)
        {
            var slot = displayedPowers[power];
            slot.NameText.text = $"{power.Name} (x{powerStack.Count})";   
        }
    }
}