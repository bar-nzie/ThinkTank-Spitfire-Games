using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuSubcription : MonoBehaviour
{
    public Vector2 MoveInput {  get; private set; } = Vector2.zero;

    public bool ActionButton {  get; private set; } = false;

    InputMap _Input = null;

    private void OnEnable()
    {
        _Input = new InputMap();

        _Input.Menu.Enable();

        _Input.Menu.StickMovement.performed += SetMovement;
        _Input.Menu.StickMovement.canceled += SetMovement;

        _Input.Menu.Actionbutton.started += SetMovement;
        _Input.Menu.Actionbutton.canceled += SetMovement;


    }

    private void OnDisable()
    {
        _Input.Menu.Disable();

        _Input.Menu.StickMovement.performed -= SetMovement;
        _Input.Menu.StickMovement.canceled -= SetMovement;

        _Input.Menu.Actionbutton.started -= SetMovement;
        _Input.Menu.Actionbutton.canceled -= SetMovement;
    }

    void SetMovement(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector2>();
    }

    void SetAction(InputAction.CallbackContext ctx)
    {
        ActionButton = ctx.started;
    }

}
