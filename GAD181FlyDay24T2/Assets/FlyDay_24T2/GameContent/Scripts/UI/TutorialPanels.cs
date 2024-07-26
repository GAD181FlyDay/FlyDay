using UnityEngine;

public class TutorialPanels : MonoBehaviour
{
    /// <summary>
    /// Attach this script to your tutorial panels!
    /// At the start of the minigame it pauses time.
    /// Once the player presses the button, The time is resumed and
    /// the panel is turned off!
    /// </summary>

    #region Variables
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject[] textsThatAreHidden;
    #endregion


    private void Update()
    {
        OnSpaceTurnOffThePanel();
    }

    #region Private Functions.
    private void OnSpaceTurnOffThePanel()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            tutorialPanel.SetActive(false);

            for (int i = 0; i < textsThatAreHidden.Length; i++) 
            {
                textsThatAreHidden[i].SetActive(true);
            }
        }
    }

    private void OnEnable()
    {
        tutorialPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
    #endregion

}
