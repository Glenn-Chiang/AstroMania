using UnityEngine;

public abstract class Power : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    
    public PlayerController player;
   
    public abstract void Activate();
}