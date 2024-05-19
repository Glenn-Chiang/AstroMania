using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerController player;

    [SerializeField] private MenuDisplayer pauseMenuDisplayer;
    [SerializeField] private MenuDisplayer powerListDisplayer;

    private bool isGameOver = false;

    private void Start()
    {
        player = PlayerController.Instance;
        player.PlayerDied += HandleGameOver;
    }

    private void HandleGameOver(object sender, EventArgs e)
    {
        isGameOver = true;
    }

    private void Update()
    {
        // Disable all  key inputs if game over
        if (isGameOver) return;

        // Toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuDisplayer.Toggle();
        }

        // If pause menu is open, disable all other key inputs
        if (pauseMenuDisplayer.IsActive) return;

        // Toggle power list
        if (Input.GetKeyDown(KeyCode.F))
        {
            powerListDisplayer.Toggle();
        }

        // If any menu is open, disable action key inputs
        if (MenuDisplayManager.Instance.NumMenusShown > 0)
        {
            return;
        }

        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");
        player.Movement.SetMoveDir(new Vector2(moveX, moveY));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Movement.Dash();
        }
        
        // Aiming
        var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.Movement.LookAt(cursorPos);

        // Firing 
        if (Input.GetButtonDown("Fire1"))
        {
            player.WeaponManager.FireWeapon();
        }

        // Switching weapons
        if (GetNumberInput(out int number))
        {
            player.WeaponManager.SelectWeapon(number - 1);
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            player.WeaponManager.SelectNextWeapon();
        }
        if (Input.mouseScrollDelta.y  < 0)
        {
            player.WeaponManager.SelectPrevWeapon();
        }
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