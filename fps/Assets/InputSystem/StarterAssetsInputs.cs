using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        public void OnMove(InputValue value)
        {
            // MoveInput(value.Get<Vector2>());
            Debug.Log("OnMove");
        }

        public void OnLook(InputValue value)
        {
            // if (cursorInputForLook)
            // {
            // LookInput(value.Get<Vector2>());
            // }
            Debug.Log("OnLook");
        }

        public void OnJump(InputValue value)
        {
            // JumpInput(value.isPressed);
            Debug.Log("OnJump");
        }

        public void OnSprint(InputValue value)
        {
            // SprintInput(value.isPressed);
            Debug.Log("OnSprint");
        }
#endif


        public void MoveInput(InputAction.CallbackContext context)
        {
            move = context.ReadValue<Vector2>();
        }

        public void LookInput(InputAction.CallbackContext context)
        {
            look = context.ReadValue<Vector2>();
        }

        public void JumpInput(InputAction.CallbackContext context)
        {
            if (context.performed)
                jump = true;
        }

        public void SprintInput(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                sprint = true;
                Debug.Log("true");
            }
            else if (context.canceled)
            {
                sprint = false;
                Debug.Log("false");
            }
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

}