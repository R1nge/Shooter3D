using Cinemachine;
using GameFlow;
using UnityEngine;
using VContainer;

namespace Player.Movement
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private float lookSpeed = 2f;
        [SerializeField] private float lookXLimit = 90f;
        [SerializeField] private CinemachineVirtualCamera playerCamera;
        private float _rotationX;
        private PlayerInput _playerInput;

        private const string MAP_NAME = "Player";
        private const string ACTION_NAME = "Look";

        [Inject]
        private void Construct(PlayerInput playerInput)
        {
            _playerInput = playerInput;
        }

        private void Update() => Rotate();

        private void Rotate()
        {
            _rotationX += -_playerInput.GetValue<Vector2>(MAP_NAME, ACTION_NAME).y * lookSpeed;
            _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            transform.rotation *=
                Quaternion.Euler(0, _playerInput.GetValue<Vector2>(MAP_NAME, ACTION_NAME).x * lookSpeed, 0);
        }
    }
}