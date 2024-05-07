using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    private Vector2 moveDir;

    public void SetMoveDir(float x, float y)
    {
        moveDir = new Vector2(x, y).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.deltaTime);
    }
}
