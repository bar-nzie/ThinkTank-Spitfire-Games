using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplaySubcription : MonoBehaviour
{
    public Vector2 MoveInput {  get; private set; } = Vector2.zero;

    public bool ActionButton {  get; private set; } = false;

    InputMap _Input = null;

    private void OnEnable()
    {
        _Input = new InputMap();

        _Input.Gameplay.Enable();

        _Input.Gameplay.Movement.performed += SetMovement;
        _Input.Gameplay.Movement.canceled += SetMovement;

        _Input.Gameplay.Actionbutton.started += SetAction;
        _Input.Gameplay.Actionbutton.canceled += SetAction;


    }

    private void OnDisable()
    {
        _Input.Gameplay.Disable();

        _Input.Gameplay.Movement.performed -= SetMovement;
        _Input.Gameplay.Movement.canceled -= SetMovement;

        _Input.Gameplay.Actionbutton.started -= SetAction;
        _Input.Gameplay.Actionbutton.canceled -= SetAction;
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
