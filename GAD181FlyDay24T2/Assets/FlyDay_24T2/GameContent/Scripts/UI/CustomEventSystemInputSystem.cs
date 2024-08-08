using UnityEngine;
using UnityEngine.EventSystems;

namespace DanasEventSystem
{
    /// <summary>
    /// This script is to override a Unity script so that
    /// when you click outside  a button, the buttons remain
    /// navigatable through keys.
    /// </summary>

    public class CustomEventSystemInputSystem : StandaloneInputModule
    {
        public override void Process()
        {
            base.Process(); 

            // Prevents deselection on background click.
            if (eventSystem.currentSelectedGameObject == null)
            {
                if (lastSelectedGameObject != null)
                {
                    eventSystem.SetSelectedGameObject(lastSelectedGameObject);
                }
            }
        }

        private GameObject lastSelectedGameObject;

        public override void UpdateModule()
        {
            base.UpdateModule();
            if (eventSystem.currentSelectedGameObject != null)
            {
                lastSelectedGameObject = eventSystem.currentSelectedGameObject;
            }
        }
    }
}