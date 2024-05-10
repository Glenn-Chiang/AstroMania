public class CharacterStats
{
    public readonly Stat maxHealth;
    public readonly Stat moveSpeed;
    public readonly Stat damageBonus;
    public readonly Stat fireRateBonus;

    public CharacterStats(CharacterData data)
    {
        maxHealth = new Stat(data.MaxHealth.Value);
        moveSpeed = new Stat(data.MoveSpeed.Value);
        damageBonus = new Stat(data.DamageBonus.Value);
        fireRateBonus = new Stat(data.FireRateBonus.Value);
    }
}