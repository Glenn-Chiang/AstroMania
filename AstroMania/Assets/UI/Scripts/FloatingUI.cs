using UnityEngine;

public class FloatingUI : MonoBehaviour
{
    [SerializeField] private Transform attachedEntity; // Gameobject which this floating UI element is attached to
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        transform.position = attachedEntity.position + offset;
        transform.rotation = Camera.main.transform.rotation;
    }
}