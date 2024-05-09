public class CharacterStats
{
    public readonly Stat maxHealth;
    public readonly Stat moveSpeed;

    public CharacterStats(CharacterData data)
    {
        maxHealth = new Stat(data.MaxHealth.Levels);
        moveSpeed = new Stat(data.MoveSpeed.Levels);
    }

    public virtual void Upgrade()
    {
        maxHealth.Upgrade();
        moveSpeed.Upgrade();
    }
}