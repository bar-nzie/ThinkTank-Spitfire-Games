using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sean
{
    [CreateAssetMenu(menuName = "InputReader")]
    public class InputReader : ScriptableObject, gameInput.IGameplayActions, gameInput.IUIActions
    {
        private gameInput _gameInput;

        private void OnEnable()
        {
            if (_gameInput == null)
            {
                _gameInput = new gameInput();

                _gameInput.Gameplay.SetCallbacks(this);
                _gameInput.UI.SetCallbacks(this);

                SetGameplay();
            }

        }

        public void SetGameplay()
        {
            _gameInput.Gameplay.Enable();
            _gameInput.Gameplay.Disable();
        }
        public void SetUI()
        {
            _gameInput.Gameplay.Disable();
            _gameInput.Gameplay.Enable();
        }

        public event Action MovementLeftEvent;
        public event Action MovementLeftCancelledEvent;

        public event Action MovementRightEvent;
        public event Action MovementRightCancelledEvent;

        public event Action MovementUpEvent;
        public event Action MovementUpCancelledEvent;

        public event Action MovementDownEvent;
        public event Action MovementDownCancelledEvent;

        public event Action ShootEvent;
        public event Action ShootCancelledEvent;

        public event Action PlayEvent;

        public void OnMovementLeft(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                MovementLeftEvent?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                MovementLeftCancelledEvent?.Invoke();
            }

        }

        public void OnMovementRight(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                MovementRightEvent?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                MovementRightCancelledEvent?.Invoke();
            }

        }

        public void OnMovementUp(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                MovementUpEvent?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                MovementUpCancelledEvent?.Invoke();
            }

        }

        public void OnMovementDown(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                MovementDownEvent?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                MovementDownCancelledEvent?.Invoke();
            }

        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ShootEvent?.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                ShootCancelledEvent?.Invoke();
            }

        }

        public void OnPlay(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PlayEvent?.Invoke();
                SetGameplay();
            }
        }

    }

}
