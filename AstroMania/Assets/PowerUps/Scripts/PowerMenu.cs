using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PowerMenu : MonoBehaviour
{
    [SerializeField] private PowerManager powerManager;
    [SerializeField] private List<Power> allPowers;
    [SerializeField] private int offerCount; // Number of powers to offer
    [SerializeField] private List<Power> offeredPowers;

    [SerializeField] private List<MenuSlot> slots;
    [SerializeField] private DisplayController displayController;

    private void Start()
    {
        var availablePowers = GetAvailablePowers();
        offeredPowers = RandomUtils.SelectNRandom(availablePowers, offerCount);
        DisplayPowers();
    }

    private List<Power> GetAvailablePowers()
    {
        // Exclude non-stackable powers that the player already owns
        return allPowers.Except(allPowers.Where(power => !power.Stackable && powerManager.HasPower(power))).ToList();
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
            slot.DescriptionText.text = power.Description;

            slot.Button.onClick.AddListener(() => OnClickPower(power));
        }
    }

    private void OnClickPower(Power power)
    {
        powerManager.AddPower(power);
        gameObject.SetActive(false);
        displayController.Close();

    }

}