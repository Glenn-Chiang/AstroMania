using UnityEngine;

public class XpOrb : OrbController
{
    [SerializeField] private float xpAmount = 1f;
    protected override void EvokeEffect()
    {
        var xpManager = target.GetComponentInParent<XPManager>();
        if (xpManager != null)
        {
            xpManager.AddXp(xpAmount);
        }
    }
}