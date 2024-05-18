using System;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private GameObject explosion;

    private void Start()
    {
        healthManager.Died += OnDeath;
    }

    private void OnDeath(object sender, EventArgs e)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}