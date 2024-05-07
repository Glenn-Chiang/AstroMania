using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    protected Vector2 moveDir;

    public void LookAt(Vector3 lookPos)
    {
        var lookDir = (lookPos - transform.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void SetMoveDir(Vector2 moveDir)
    {
        this.moveDir = moveDir.normalized;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public virtual void Move()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * moveDir);
    }
    public void MoveTowards(Vector2 destination)
    {
        LookAt(destination);
        SetMoveDir(destination - rb.position);
    }
}