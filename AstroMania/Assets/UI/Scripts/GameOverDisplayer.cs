using System;
using UnityEngine;

public class GameOverDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;

    private void Start()
    {
        Player.Instance.PlayerDied += OnPlayerDeath;
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        gameOverDisplay.SetActive(true);
    }
}