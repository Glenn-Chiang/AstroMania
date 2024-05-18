using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageDisplay : MonoBehaviour
{
    [SerializeField] private StageManager stageManager;
    [SerializeField] private TMP_Text stageText;
    [SerializeField] private Image stageIcon;

    private void Start()
    {
        stageManager.StageChanged += OnStageChanged;
        PlayerController.Instance.PlayerDied += OnPlayerDeath;
        UpdateDisplay();
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        enabled = false;
    }

    private void OnStageChanged(object sender, StageData stage)
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        stageText.text = stageManager.CurrentStage.Name;
        //stageIcon.sprite = stageManager.CurrentStage.Icon;
    }
}