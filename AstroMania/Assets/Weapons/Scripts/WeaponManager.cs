using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponSlot;
    [SerializeField] private List<WeaponData> weapons; // Weapon prefabs
    public List<WeaponData> Weapons => weapons;

    private int selectedIndex = 0;
    public WeaponData SelectedWeapon => weapons[selectedIndex];
    private WeaponController equippedWeapon;

    [SerializeField] private EnergyManager energyManager;
    public readonly List<StatusEffectApplier> effectAppliers = new();

    private ICharacter character;
    public Stat DamageBonus => character.Stats.damageBonus;
    public Stat FireRateBonus => character.Stats.fireRateBonus;

    public event EventHandler ChangedWeapon;

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
    private void EquipWeapon()
    {
        equippedWeapon = Instantiate(SelectedWeapon.Controller, weaponSlot);   
    }

    public void SelectWeapon(int index)
    {
        if (index < 0 || index >= weapons.Count) return; // Invalid index
        if (index == selectedIndex) return; // Already selected

        if (equippedWeapon != null)
        {
            Destroy(equippedWeapon.gameObject); // Remove currently selected weapon
        }
        
        selectedIndex = index;
        EquipWeapon();

        ChangedWeapon?.Invoke(this, EventArgs.Empty);
    }

    public void SelectNextWeapon()
    {
        if (weapons.Count <= 2) return;

        if (selectedIndex < weapons.Count - 1)
        {
            SelectWeapon(selectedIndex + 1);
            return;
        }
        if (selectedIndex == weapons.Count - 1)
        {
            SelectWeapon(0);
            return;
        }        
    }

    public void SelectPrevWeapon()
    {
        if (weapons.Count <= 2) return;

        if (selectedIndex > 0)
        {
            SelectWeapon(selectedIndex - 1);
            return;
        }
        if (selectedIndex == 0)
        {
            SelectWeapon(weapons.Count - 1);
            return;
        }
    }

    public void SelectRandomWeapon()
    {
        SelectWeapon(UnityEngine.Random.Range(0, weapons.Count));
    }

    public void AddWeapon(WeaponData weapon)
    {
        if (!weapons.Contains(weapon))
        {
            weapons.Add(weapon);
        }
    }

}