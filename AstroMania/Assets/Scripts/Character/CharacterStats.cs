public class CharacterStats
{
    public readonly Stat maxHealth;
    public readonly Stat moveSpeed;
    public readonly Stat damageBonus;
    public readonly Stat fireRateBonus;

    public CharacterStats(CharacterData data)
    {
        maxHealth = new Stat(data.MaxHealth.Levels);
        moveSpeed = new Stat(data.MoveSpeed.Levels);
        damageBonus = new Stat(data.DamageBonus.Levels);
        fireRateBonus = new Stat(data.FireRateBonus.Levels);
    }

    public virtual void Upgrade()
    {
        maxHealth.Upgrade();
        moveSpeed.Upgrade();
        damageBonus.Upgrade();
        fireRateBonus.Upgrade();
    }
}