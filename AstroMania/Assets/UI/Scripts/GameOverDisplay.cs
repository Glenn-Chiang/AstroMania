using System;
using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;

    private void Start()
    {
        PlayerController.Instance.PlayerDied += OnPlayerDeath;
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        gameOverDisplay.SetActive(true);
    }
}