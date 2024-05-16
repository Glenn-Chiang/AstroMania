using System;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    [SerializeField] private XPManager xpManager;
    [SerializeField] private GameObject levelUpMenu;

    public bool MenuIsActive { get; private set; }

    private void Start()
    {
        xpManager.OnLevelUp += HandleLevelUp;
    }

    private void HandleLevelUp(object sender, LevelUpEventArgs e)
    {
        DisplayMenu();
    }

    public void DisplayMenu()
    {
        Time.timeScale = 0f;
        levelUpMenu.SetActive(true);
        MenuIsActive = true;
    }

    public void Close()
    {
        levelUpMenu.SetActive(false);
        Time.timeScale = 1f;
        MenuIsActive = false;
    }
}