using System;
using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    private float elapsedTime;

    private void Start()
    {
        Player.Instance.PlayerDied += OnPlayerDeath;
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        enabled = false;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format($"{minutes:00}:{seconds:00}");
    }
}