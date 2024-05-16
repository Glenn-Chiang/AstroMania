using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHUD : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;

    [SerializeField] private Image image;
    [SerializeField] private TMP_Text nameText;

    private void Start()
    {
        weaponManager.ChangedWeapon += OnChangedWeapon;
        UpdateDisplay();
    }

    private void OnChangedWeapon(object sender, EventArgs e)
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        image.sprite = weaponManager.SelectedWeapon.Sprite;
        image.preserveAspect = true;
        nameText.text = weaponManager.SelectedWeapon.Name;
    }
}