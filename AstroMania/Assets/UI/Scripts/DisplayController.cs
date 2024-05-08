using System;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    [SerializeField] private XPManager xpManager;
    [SerializeField] private GameObject weaponMenu;

    private void Start()
    {
        xpManager.OnLevelUp += HandleLevelUp;
    }

    private void HandleLevelUp(object sender, LevelUpEventArgs e)
    {
        ShowMenu();
    }

    public void ShowMenu()
    {
        Time.timeScale = 0f;
        weaponMenu.SetActive(true);
    }

    public void Close()
    {
        weaponMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}