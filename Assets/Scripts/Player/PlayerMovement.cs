using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerMovement : MonoBehaviour
    {
        public float speed;
        private DefaultPlayerActions _defaultPlayerActions;
        private InputAction _moveAction;
        private Animator animator;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _defaultPlayerActions = new DefaultPlayerActions();
        }

        private void OnEnable()
        {
            _moveAction = _defaultPlayerActions.Player.Move;
            _moveAction.Enable();

            _defaultPlayerActions.Player.Menu.performed += OnMenu;
            _defaultPlayerActions.Player.Menu.Enable();
        }

        private void OnDisable()
        {
            _moveAction.Disable();
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Vector2 moveDir = _moveAction.ReadValue<Vector2>();
            
            _rigidbody.MovePosition(moveDir * speed + _rigidbody.position );
        }

        private void OnMenu(InputAction.CallbackContext context)
        {
        }
    }
}
