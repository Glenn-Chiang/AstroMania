using System;
using UnityEngine;

public class MenuDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    public bool IsActive => menu.activeInHierarchy;

    public void Show()
    {
        menu.SetActive(true);
        MenuDisplayManager.Instance.OnMenuShown();
    }

    public void Hide()
    {
        menu.SetActive(false);
        MenuDisplayManager.Instance.OnMenuHidden();
    }

    public void Toggle()
    {
        if (menu.activeInHierarchy)
        {
            Hide();
        } else
        {
            Show();
        }
    }
}