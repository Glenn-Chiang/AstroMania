using System.Collections;
using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 0.75f;
    private bool isDashing = false;
    private bool canDash = true;

    public void Dash()
    {
        if (canDash)
        {
            StartCoroutine(DashRoutine());
        }
    }

    private IEnumerator DashRoutine()
    {
        isDashing = true;
        canDash = false;
        rb.velocity = moveDir * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public override void Move()
    {
        if (!isDashing)
        {
            base.Move();
        }
    }
}