using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    [SerializeField] private List<MenuButton> menuButtons;
    private GameObject activeMenu;

    private void Start()
    {
        foreach (var menuButton in menuButtons)
        {
            menuButton.button.onClick.AddListener(() =>
            {
                menuButton.menu.SetActive(true);
                activeMenu = menuButton.menu;
                gameObject.SetActive(false);
            });
        }
    }

   
}

[Serializable]
public class MenuButton
{
    public Button button;
    public GameObject menu;
}