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
        player.Movement.SetMoveDir(new Vector2(moveX, moveY));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Movement.Dash();
        }
        
        var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.Movement.LookAt(cursorPos);

        if (Input.GetButtonDown("Fire1"))
        {
            player.WeaponManager.FireWeapon();
        }

        if (GetNumberInput(out int number))
        {
            player.WeaponManager.SelectWeapon(number - 1);
        }
    }

    private void FixedUpdate()
    {
    }

    private bool GetNumberInput(out int number)
    {
        KeyCode[] numberKeys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
        for (int i = 0; i < numberKeys.Length; i++)
        {
            if (Input.GetKeyDown(numberKeys[i]))
            {
                number = i + 1;
                return true;
            }
        }
        number = -1;
        return false;
    }
}