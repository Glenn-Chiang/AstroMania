using UnityEngine;


[CreateAssetMenu(fileName = "Player Character", menuName = "Player Character")]
public class PlayerData : CharacterData
{
    [field: SerializeField] public Stat MaxEnergy { get; private set; }
}