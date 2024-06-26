using UnityEngine;

public abstract class Power : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, TextArea(2,5)] public string Description { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public bool Stackable { get; private set; }
    [field: SerializeField] public Power NextLevel { get; private set; }
    [field: SerializeField] public Power PrevLevel { get; private set; }
   
    public abstract void Activate();
    public virtual void Deactivate() { }

    [HideInInspector] public Player player;
}