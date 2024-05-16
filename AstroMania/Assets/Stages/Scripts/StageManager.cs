using System;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    [SerializeField] private List<StageData> stages;
    [SerializeField] private float stageChangeInterval;
    public event EventHandler<StageData> StageChanged;

    private int currentStageIndex = 0;
    public StageData CurrentStage => stages[currentStageIndex];

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        InvokeRepeating(nameof(AdvanceStage), stageChangeInterval, stageChangeInterval);
    }

    private void AdvanceStage()
    {
        if (currentStageIndex < stages.Count - 1)
        {
            currentStageIndex++;
            StageChanged?.Invoke(this, CurrentStage);
        } else
        {
            CancelInvoke(nameof(AdvanceStage));
        }
    }
}