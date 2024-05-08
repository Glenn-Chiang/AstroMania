public class PlayerStats : CharacterStats
{
    public readonly Stat maxEnergy;

    public PlayerStats(PlayerCharacterData data) : base(data)
    {
        maxEnergy = new(data.MaxEnergy);
    }
}