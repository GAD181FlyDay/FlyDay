using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    /// <summary>
    /// Responsible for having the pause menu be available accross all scenes.
    /// </summary>

    public class PauseMenu : MonoBehaviour
    {
        #region Variables
        public static PauseMenu Instance;
        public bool isPanelActive;
        public GameObject optionsPanel;
        public GameObject mainMenuFirstSelected;
        public GameObject optionsPanelFirstSelected;

        private EventSystem eventSystem;
        #endregion

        private void Start()
        {
            if (mainMenuFirstSelected != null)
            {
                eventSystem.SetSelectedGameObject(mainMenuFirstSelected);
            }
            else if (optionsPanelFirstSelected != null)
            {
                eventSystem.SetSelectedGameObject(optionsPanelFirstSelected);
            }
        }

        private void Awake()
        {
            // Makes sure there is only one instance of this Event System (and menu) accross all scenes.
            // Makes sure this instance doesn't get destroyed accross scenes.
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            eventSystem = EventSystem.current;
        }

        private void Update()
        {
            OnInputTogglePanel();
            // Debug.Log( eventSystem.currentSelectedGameObject + " is currently selected");
        }

        #region OptionsToggler
        /// <summary>
        /// Toggles the opposite state of current active state.
        /// e.g. if the options panel is currently active then set as inactive and
        /// the opposite is true.
        /// </summary>
        public void ToggleOptionsPanel()
        {
            isPanelActive = !optionsPanel.activeSelf;
            optionsPanel.SetActive(isPanelActive);
            Time.timeScale = isPanelActive ? 0 : 1;

            if (isPanelActive)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                // Debug.Log("Options panel turned on. Event system button should change now");
                eventSystem.SetSelectedGameObject(optionsPanelFirstSelected);
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                if (mainMenuFirstSelected != null)
                {
                    // Debug.Log("Options panel off, Event system button should be play (if available)");
                    eventSystem.SetSelectedGameObject(mainMenuFirstSelected);
                }
                else
                {
                    eventSystem.SetSelectedGameObject(optionsPanelFirstSelected);
                }
            }
        }
        #endregion

        #region Inputs Detector
        /// <summary>
        /// Actions to take when key input is detected.
        /// </summary>
        private void OnInputTogglePanel()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleOptionsPanel();
            }
        }
        #endregion
    }
}