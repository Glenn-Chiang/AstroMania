using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PowerMenu : MonoBehaviour
{
    [SerializeField] private PowerManager powerManager;
    [SerializeField] private int offerCount; // Number of powers to offer
    
    [SerializeField] private List<Power> allPowers;
    private List<Power> availablePowers;
    private List<Power> offeredPowers;

    [SerializeField] private List<MenuSlot> slots;
    [SerializeField] private DisplayController displayController;

    private void Awake()
    {
        // Initially, only level 0 powers are available
        availablePowers = allPowers.Where(power => power.Level == 0).ToList();
        
    }

    private void OnEnable()
    {        
        offeredPowers = RandomUtils.SelectNRandom(availablePowers, offerCount);
        DisplayPowers();
    }

    // Randomly select a number of powers from list of all powers
    private void DisplayPowers()
    {
        for (int i = 0; i < offeredPowers.Count; i++)
        {
            var power = offeredPowers[i];
            var slot = slots[i];

            slot.NameText.text = power.Name;
            slot.Image.sprite = power.Sprite;
            slot.Image.preserveAspect = true;
            slot.DescriptionText.text = power.Description;
            
            slot.Button.onClick.RemoveAllListeners(); // Remove previous listeners
            slot.Button.onClick.AddListener(() => OnClickPower(power));
        }
    }

    private void GivePower(Power power)
    {
        powerManager.AddPower(power);

        // If the power is not stackable, it will not be offered again
        if (!power.Stackable)
        {
            availablePowers.Remove(power);
        }

        // If the power has a next level, add it to the pool of available powers
        if (power.NextLevel != null)
        {
            availablePowers.Add(power.NextLevel);
        }
    }

    private void OnClickPower(Power power)
    {
        GivePower(power);
        gameObject.SetActive(false);
        displayController.Close();
    }

}