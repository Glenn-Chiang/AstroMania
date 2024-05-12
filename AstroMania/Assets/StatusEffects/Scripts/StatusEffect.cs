using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{
    public float duration;
    public abstract void ApplyEffect();

    private void Start()
    {
        ApplyEffect();
    }

    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            Destroy(this); // Status effect is removed when effect duration ends
        }
    }
}