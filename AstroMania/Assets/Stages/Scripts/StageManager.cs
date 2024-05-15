using System;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private List<StageData> stages;
    [SerializeField] private float stageChangeInterval;
    public event EventHandler<StageData> StageChanged;

    private int currentStageIndex = 0;
    private StageData CurrentStage => stages[currentStageIndex];

    private void Awake()
    {
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