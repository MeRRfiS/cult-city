using CultCity.Scripts.Player;
using UnityEngine;

namespace CultCity.Scripts.Inputs
{
    [RequireComponent(typeof(Movement), typeof(Act))]
    public class PlayerInput : Input
    {
        private Vector2 _movementInput;
		private PlayerInputAction _input;
        private Movement _movement;
        private Act _act;

        private void BlockInput() => _input.Disable();
        private void UnblockInput() => _input.Enable();

        private void Awake()
        {
            _input = new();

            _input.Player.Movement.performed += x => _movementInput = x.ReadValue<Vector2>();
            _input.Player.Movement.canceled += x => _movementInput = Vector2.zero;

            _input.Player.Act.performed += x => ApplyAct();

            _input.Enable();

            _gameManager.OnStorageOpen += BlockInput;
            _gameManager.OnStorageClose += UnblockInput;
        }

        private void Start()
        {
            _movement = GetComponent<Movement>();
            _act = GetComponent<Act>();
        }

        private void FixedUpdate()
        {
            ApplyMovement();
        }

        private void ApplyMovement()
        {
            _movement.Move(_movementInput);
        }

        private void ApplyAct()
        {
            _act.ActFithObject();
        }

        private void OnDestroy()
        {
            _input.Disable();

            _gameManager.OnStorageOpen -= BlockInput;
            _gameManager.OnStorageClose -= UnblockInput;
        }
    } 
}
