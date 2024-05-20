using UnityEngine;

public class CharacterStats
{
    public readonly Stat maxHealth;
    public readonly Stat moveSpeed;
    public readonly Stat damageBonus;
    public readonly Stat fireRateBonus;

    public CharacterStats(CharacterData data)
    {
        maxHealth = new Stat(data.MaxHealth.BaseValue);
        moveSpeed = new Stat(data.MoveSpeed.BaseValue);
        damageBonus = new Stat(data.DamageBonus.BaseValue);
        fireRateBonus = new Stat(data.FireRateBonus.BaseValue);
    }
}