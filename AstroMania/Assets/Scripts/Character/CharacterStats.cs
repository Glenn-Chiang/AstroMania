public class CharacterStats
{
    public readonly Stat maxHealth;
    public readonly Stat moveSpeed;

    public CharacterStats(CharacterData data)
    {
        maxHealth = new Stat(data.MaxHealth);
        moveSpeed = new Stat(data.MoveSpeed);
    }
}