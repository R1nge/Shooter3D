using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameFlow
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private InputActionAsset playerInput;

        private void OnEnable() => playerInput.Enable();

        private void OnDisable() => playerInput.Disable();

        private InputAction GetAction(string mapName, string actionName)
        {
            var map = playerInput.FindActionMap(mapName);
            var action = map.FindAction(actionName);
            return action;
        }

        public bool IsPressed(string mapName, string actionName)
        {
            return GetAction(mapName, actionName).IsPressed();
        }

        public T GetValue<T>(string mapName, string actionName) where T : struct
        {
            return GetAction(mapName, actionName).ReadValue<T>();
        }

        public void Subscribe(string mapName, string actionName, Action<InputAction.CallbackContext> action)
        {
            GetAction(mapName, actionName).performed += action;
        }

        public void UnSubscribe(string mapName, string actionName, Action<InputAction.CallbackContext> action)
        {
            GetAction(mapName, actionName).performed -= action;
        }
    }
}