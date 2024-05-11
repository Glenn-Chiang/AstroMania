using UnityEngine;

public class RegenEffect : MonoBehaviour
{
    public HealthManager healthManager;
    public float regenRate; // Proportion of health healed per interval
    private float interval = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(Regenerate), interval, interval);
    }

    private void Regenerate()
    {
        if (healthManager.Value < healthManager.MaxValue)
        {
            healthManager.Heal(regenRate * healthManager.MaxValue);
        }
    }
}