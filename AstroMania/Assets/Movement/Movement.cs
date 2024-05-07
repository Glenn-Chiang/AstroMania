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
    protected virtual void FixedUpdate()
    {
        MoveTo(moveDir);
    }

    public void LookAt(Vector3 lookPos)
    {
        var lookDir = (lookPos - transform.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void MoveTo(Vector2 moveDir)
    {
        rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * moveDir);
    }
    public void MoveTowards(Vector2 destination)
    {
        LookAt(destination);
        //transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
        rb.MovePosition(Vector2.MoveTowards(rb.position, destination, moveSpeed * Time.deltaTime));
    }
}
