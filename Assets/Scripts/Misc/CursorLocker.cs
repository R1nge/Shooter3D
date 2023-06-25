using UnityEngine;
using VContainer.Unity;

namespace Misc
{
    public class CursorLocker : IInitializable
    {
        public void Initialize()
        {
            Lock();
        }

        public void Lock()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void Unlock()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}