using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] protected Rigidbody2D rb;
    private float MoveSpeed
    {
        get
        {
            if (character.Stats == null) return 0;
            return character.Stats.moveSpeed.Value;
        }
    }
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