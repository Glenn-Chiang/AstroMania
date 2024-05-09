using System;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    [SerializeField] private XPManager xpManager;
    [SerializeField] private GameObject levelUpMenu;

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
        levelUpMenu.SetActive(true);
    }

    public void Close()
    {
        levelUpMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}