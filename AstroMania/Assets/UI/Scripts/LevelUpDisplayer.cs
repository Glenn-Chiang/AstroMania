using System;
using UnityEngine;

public class LevelUpDisplayer : MonoBehaviour
{
    [SerializeField] private XPManager xpManager;
    [SerializeField] private MenuDisplayer menuDisplayer;

    public bool MenuIsActive { get; private set; }

    private void Start()
    {
        xpManager.LevelledUp += HandleLevelUp;
    }

    private void HandleLevelUp(object sender, LevelUpEventArgs e)
    {
        menuDisplayer.Show();
    }
}