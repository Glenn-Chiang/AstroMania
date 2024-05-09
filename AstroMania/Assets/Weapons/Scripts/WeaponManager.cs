using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private ICharacter character;
    private Stat DamageBonus => character.Stats.damageBonus;
    private Stat FireRateBonus => character.Stats.fireRateBonus;

    [SerializeField] Transform weaponSlot;

    [SerializeField] private List<WeaponData> weapons; // Weapon prefabs
    public List<WeaponData> Weapons => weapons;

    private int selectedIndex = 0;
    public WeaponData SelectedWeapon => weapons[selectedIndex];
    private WeaponController equippedWeapon;

    [SerializeField] private EnergyManager energyManager;

    private void Start()
    {
        character = GetComponent<ICharacter>();
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

    public void AddWeapon(WeaponData weapon)
    {
        if (!weapons.Contains(weapon))
        {
            weapons.Add(weapon);
        }
    }

    private void EquipWeapon()
    {
        equippedWeapon = Instantiate(SelectedWeapon.Controller, weaponSlot);
        equippedWeapon.damageBonus = DamageBonus;
        equippedWeapon.fireRateBonus = FireRateBonus;
    }
}