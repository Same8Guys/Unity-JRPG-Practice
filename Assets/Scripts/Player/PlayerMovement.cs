using System.Diagnostics;
namespace Player
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerMovement : MonoBehaviour
    {
        public float speed;
        private DefaultPlayerActions _defaultPlayerActions;
        private InputAction _moveAction;
        public Animator _animator;
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

        private void FixedUpdate()
        {
            Vector2 moveDir = _moveAction.ReadValue<Vector2>();
            updateAnimation(moveDir);
            _rigidbody.MovePosition(moveDir * speed + _rigidbody.position);
        }

        private void OnMenu(InputAction.CallbackContext context)
        {
        }

        private void updateAnimation(Vector2 moveDir)
        {
            if (moveDir == Vector2.up)
            {
                _animator.SetInteger("Direction", (int)Directions.NORTH);
                _animator.SetBool("IsMoving", true);
            }
            else if (moveDir == Vector2.down)
            {
                _animator.SetInteger("Direction", (int)Directions.SOUTH);
                _animator.SetBool("IsMoving", true);
            }
            else if (moveDir.x > 0)
            {
                _animator.SetInteger("Direction", (int)Directions.EAST);
                _animator.SetBool("IsMoving", true);
            }
            else if (moveDir.x < 0)
            {
                _animator.SetInteger("Direction", (int)Directions.WEST);
                _animator.SetBool("IsMoving", true);
            }
            else
            {
                _animator.SetBool("IsMoving", false);
                return;
            }
        }
    }

    enum Directions
    {
        SOUTH,
        NORTH,
        WEST,
        EAST
    }
}