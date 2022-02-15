using UnityEngine;
using UnityEngine.InputSystem;

namespace SnakesNLadders.Assets.Scripts
{
    public class InputEvents : MonoBehaviour
    {
        private InputControls _inputControls;

        public delegate void StartTouchEvent(Vector2 position);
        public static event StartTouchEvent OnStartTouch;

        private void Awake()
        {
            _inputControls = new InputControls();
        }

        private void OnEnable()
        {
            _inputControls.Enable();
        }


        private void Start()
        {
            _inputControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        }


        private void StartTouch(InputAction.CallbackContext context)
        {
            OnStartTouch?.Invoke(_inputControls.Touch.TouchPosition.ReadValue<Vector2>());
        }


        private void OnDisable()
        {
            _inputControls.Disable();
        }
    }
}