using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    protected Vector2 moveDir;

    public void SetMoveDir(float x, float y)
    {
        moveDir = new Vector2(x, y).normalized;
    }

    public void Move()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * moveDir);

    }

    protected virtual void FixedUpdate()
    {
        Move();
    }
}
