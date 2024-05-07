using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = PlayerController.Instance;
    }

    private void Update()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");
        player.Movement.SetMoveDir(moveX, moveY);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Movement.Dash();
        }

        var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.Aiming.Aim(cursorPos);

        if (Input.GetButtonDown("Fire1"))
        {
            player.EquippedWeapon.Fire();
        }
    }
}