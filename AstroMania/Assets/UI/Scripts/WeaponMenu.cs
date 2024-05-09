using System.Collections.Generic;
using UnityEngine;

public class WeaponMenu : MonoBehaviour
{
    [SerializeField] private List<WeaponData> weapons; // All weapons in the game
    [SerializeField] private WeaponManager weaponManager;
    private List<WeaponData> InstalledWeapons => weaponManager.Weapons;

    [SerializeField] private List<MenuSlot> menuSlots;
    [SerializeField] private DisplayController displayController;

    private void OnEnable()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            var weapon = weapons[i];
            var slot = menuSlots[i];

            slot.NameText.text = weapon.Name;
            slot.Image.sprite = weapon.Sprite;

            if (InstalledWeapons.Contains(weapon))
            {
                slot.Button.gameObject.SetActive(false);
            }
            else
            {
                slot.Button.gameObject.SetActive(true);
                slot.Button.onClick.AddListener(() => OnClickInstall(slot, weapon));
            }
        }
    }

    private void OnClickInstall(MenuSlot slot, WeaponData weapon)
    {
        weaponManager.AddWeapon(weapon);
        gameObject.SetActive(false);
        displayController.Close();
    }
}