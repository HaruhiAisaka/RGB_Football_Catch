using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public PlayerMovement playerMovement;

    PlayerControls controls;
    Vector2 movementVector;
    
    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Movement.performed += ctx =>
            UpdateMovement(ctx.ReadValue<float>());
        controls.Player.Movement.canceled += ctx  => UpdateMovement(0f);
    }

    void UpdateMovement(float direction)
    {
        playerMovement.UpdateInputDirection(direction);
    }

    // void UpdateRun(bool value)
    // {
    //     playerMovement.SetRun(value);
    // }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
}
