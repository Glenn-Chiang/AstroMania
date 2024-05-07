using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponSlot;

    [SerializeField] private List<WeaponData> weapons; // Weapon prefabs
    private int selectedIndex = 0;
    public WeaponData SelectedWeapon => weapons[selectedIndex];
    private WeaponController equippedWeapon;

    [SerializeField] private EnergyManager energyManager;

    private void Awake()
    {
        EquipWeapon();
    }

    public void FireWeapon()
    {
        if (equippedWeapon != null && (energyManager == null || energyManager.ConsumeEnergy(SelectedWeapon.EnergyCost)))
        {
            equippedWeapon.HandleFire();
        }
    }

    public void SelectWeapon(int index)
    {
        if (index < 0 || index >= weapons.Count) return;
        if (index == selectedIndex) return;

        Destroy(equippedWeapon.gameObject);
        selectedIndex = index;
        EquipWeapon();
    }

    private void EquipWeapon()
    {
        equippedWeapon = Instantiate(SelectedWeapon.Controller, weaponSlot);
    }
}