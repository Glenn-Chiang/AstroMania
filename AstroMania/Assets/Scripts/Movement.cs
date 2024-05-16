using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    private float MoveSpeed => GetComponent<ICharacter>().Stats.moveSpeed.Value;
    protected Vector2 moveDir;

    public void LookAt(Vector3 lookPos)
    {
        var lookDir = lookPos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void SetMoveDir(Vector2 moveDir)
    {
        this.moveDir = moveDir.normalized;
    }

    public void Move(Vector2 moveDir)
    {
        rb.MovePosition(rb.position + MoveSpeed * Time.deltaTime * moveDir.normalized);
    }
    public void MoveTowards(Vector2 destination)
    {
        LookAt(destination);
        Move(destination - rb.position);
    }
}