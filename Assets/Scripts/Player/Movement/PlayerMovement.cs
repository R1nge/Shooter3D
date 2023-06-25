﻿using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using PlayerInput = GameFlow.PlayerInput;

namespace Player.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float walkingSpeed = 7.5f;
        [SerializeField] private float jumpHeight;
        [SerializeField] private float gravity;
        private Vector2 _move;
        private Vector3 _moveDirection = Vector3.zero;
        private CharacterController _characterController;
        private PlayerInput _playerInput;

        private const string PLAYER_MAP = "Player";
        private const string JUMP = "Jump";
        private const string MOVE = "Move";

        [Inject]
        private void Construct(PlayerInput playerInput)
        {
            _playerInput = playerInput;
        }
        //TODO: quake like movement

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            GetInput();
            Move();
        }

        private void GetInput()
        {
            _move = _playerInput.GetValue<Vector2>(PLAYER_MAP, MOVE) * walkingSpeed;
        }

        private void Move()
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float movementDirectionY = _moveDirection.y;
            _moveDirection = forward * _move.y + right * _move.x;

            if (_characterController.isGrounded && _playerInput.IsPressed(PLAYER_MAP, JUMP))
            {
                _moveDirection.y = jumpHeight;
            }
            else
            {
                _moveDirection.y = movementDirectionY;
            }

            if (!_characterController.isGrounded)
            {
                _moveDirection.y -= gravity * Time.deltaTime;
            }

            _characterController.Move(_moveDirection * Time.deltaTime);
        }
    }
}