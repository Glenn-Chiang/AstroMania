using UnityEngine;

public interface ICharacter
{
    CharacterData CharacterData { get; }
    CharacterStats Stats { get; }
}