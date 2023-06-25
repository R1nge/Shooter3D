using Cinemachine;
using Interact;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using PlayerInput = GameFlow.PlayerInput;

namespace Player.Interact
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private float rayDistance;
        [SerializeField] private LayerMask ignore;
        [SerializeField] private CinemachineVirtualCamera playerCamera;
        private PlayerInput _playerInput;

        private const string PLAYER_MAP = "Player";
        private const string INTERACT = "Interact";

        [Inject]
        private void Construct(PlayerInput playerInput)
        {
            _playerInput = playerInput;
        }

        private void Awake()
        {
            _playerInput.Subscribe(PLAYER_MAP, INTERACT, Raycast);
        }

        private void Raycast(InputAction.CallbackContext context)
        {
            var camera = playerCamera.transform;
            var ray = new Ray(camera.position, camera.forward);
            if (Physics.Raycast(
                    ray: ray,
                    hitInfo: out var hit,
                    maxDistance: rayDistance,
                    layerMask: ~ignore))
            {
                if (hit.transform.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }

        private void OnDestroy()
        {
            _playerInput.UnSubscribe(PLAYER_MAP, INTERACT, Raycast);
        }
    }
}