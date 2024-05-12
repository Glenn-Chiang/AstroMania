public class FreezeEffect : StatusEffect
{
    public override void ApplyEffect()
    {
        var stats = GetComponent<ICharacter>().Stats;
        stats.moveSpeed.ApplyMultiplier(0);
        stats.fireRateBonus.ApplyMultiplier(0);
        
    }
}