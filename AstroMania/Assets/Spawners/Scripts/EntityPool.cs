using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Entity Pool")]
public class EntityPool : ScriptableObject
{
    [field: SerializeField] public string Label;
    [field: SerializeField] public List<WeightedElement<GameObject>> Entities { get; private set; }
}