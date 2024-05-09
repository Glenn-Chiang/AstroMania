using UnityEngine;

public abstract class ResourceManager : MonoBehaviour
{
    public abstract float MaxValue { get; }
    public abstract float Value { get; protected set; }
    public void Replenish()
    {
        Value = MaxValue;
    }
}