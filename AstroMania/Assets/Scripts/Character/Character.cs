using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public abstract CharacterData CharacterData { get; }
    public abstract CharacterStats Stats { get; }

    protected abstract void InitializeStats();

    protected virtual void Awake()
    {
        InitializeStats();
    }
}