using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Respnsible for having the pause menu be available accross all scenes.
    /// </summary>

    #region Variables.
    public static PauseMenu Instance;
    public bool isPanelActive;
    public GameObject optionsPanel;
    #endregion

    private void Awake()
    // Makes sure there is only one instance of this menu accross all scenes.
    // Makes sure this instance doesn't gget destroyed accross scenes.
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        OnInputTogglePanel();
    }

    #region OptionsToggler
    /// <summary>
    /// Toggles the opposite state of current active state.
    /// e.g. if the options panel is currently active then set as inactive and
    /// the opposite is true.
    /// </summary>
    public void ToggleOptionsPanel()
    {
        // Depending on the options panel's active state the time pauses or unpauses.
        isPanelActive = !optionsPanel.activeSelf; 
        optionsPanel.SetActive(isPanelActive);
        Time.timeScale = isPanelActive ? 0 : 1;

        if (isPanelActive)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    #endregion

    #region Inputs Detector.
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

