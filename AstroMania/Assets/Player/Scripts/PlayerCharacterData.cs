using UnityEngine;


[CreateAssetMenu(fileName = "Player Character", menuName = "Player Character")]
public class PlayerCharacterData : CharacterData
{
    [field: SerializeField] public float MaxEnergy { get; private set; }
}