public class PlayerStats : CharacterStats
{
    public readonly Stat maxEnergy;

    public PlayerStats(PlayerCharacterData data) : base(data)
    {
        maxEnergy = new(data.MaxEnergy.Levels);
    }

    public override void Upgrade()
    {
        base.Upgrade();
        maxEnergy.Upgrade();
    }
}