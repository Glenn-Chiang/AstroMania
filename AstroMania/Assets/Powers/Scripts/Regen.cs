using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Power/Regen")]
public class Regen : Power
{
    [SerializeField] private float regenRate;

    public override void Activate()
    {
        var regenEffect = player.AddComponent<RegenEffect>();
        regenEffect.regenRate = regenRate;
        regenEffect.healthManager = player.HealthManager;
    }

    public override void Deactivate()
    {
        Destroy(player.GetComponent<RegenEffect>());
    }
}