using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private XPManager xpManager;
    [SerializeField] private TMP_Text levelText;

    private void Start()
    {
        xpManager.LevelledUp += UpdateDisplay;
    }

    private void UpdateDisplay(object sender, LevelUpEventArgs e)
    {
        levelText.text = $"LVL {e.level}";
    }
}