using System;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public Vector2 Origin => transform.position;
    private PlayerController Player => PlayerController.Instance;

    public float Width => GetComponent<BoxCollider2D>().size.x;

    public static event EventHandler<Sector> EnteredSector;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Player == null) return;
        if (collider.gameObject == Player.gameObject)
        {
            EnteredSector?.Invoke(this, this);
        }   
    }
}