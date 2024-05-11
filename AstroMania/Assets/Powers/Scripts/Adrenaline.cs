using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Power/Adrenaline")]
public class Adrenaline : Power
{
    [SerializeField] private float multiplier; // Multiply stats by this multiplier when adrenaline is active
    [SerializeField] private float healthThreshold; // Proportion of max health at which the adrenaline effect will activate

    public override void Activate()
    {
        var adrenalineEffect = player.AddComponent<AdrenalineEffect>();
        adrenalineEffect.player = player;
        adrenalineEffect.healthThreshold = healthThreshold;
        adrenalineEffect.multiplier = multiplier;
    }

    public override void Deactivate()
    {
       Destroy(player.GetComponent<AdrenalineEffect>());
    }

  
}