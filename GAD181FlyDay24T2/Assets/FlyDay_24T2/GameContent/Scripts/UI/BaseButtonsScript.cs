using UnityEngine.SceneManagement;

namespace UnityEngine.EventSystems
{
    /// <summary>
    /// This is the base UI script. 
    /// If you wish to tweak the ways any of these fucntions work/ what they would display on click, create a child script!
    /// </summary>

    public class BaseButtonsScript : MonoBehaviour
    {
        #region Variables.
        [SerializeField] private GameObject creditsPanel;
        [SerializeField] private EventSystem eventSystem;
        [SerializeField] private GameObject playButtonFirstSelected;
        [SerializeField] private GameObject creditsFirstSelected;
        #endregion


        #region Play Button 
        /// <summary>
        /// This function is assigned to the play button, 
        /// it directs the player to the start of the game.
        /// </summary>
        public void StartTheGame()
        {
            SceneManager.LoadScene("MainGameScene");
        }
        #endregion

        #region Credits Button
        /// <summary> 
        /// turns on the credits panel
        /// </summary>
        public void TurnOnCreditsPanel()
        {
            creditsPanel.SetActive(true);
            eventSystem.SetSelectedGameObject(creditsFirstSelected);
        }

        ///<summary>
        /// Turns off the credits panel
        /// </summary>
        public void TurnOffCreditsPanel()
        {
            creditsPanel.SetActive(false);
            eventSystem.SetSelectedGameObject(playButtonFirstSelected);
        }
        #endregion

        #region Exit Button
        /// <summary>
        /// Exits the application.
        /// </summary>
        public void ExitApplication()
        {
            Application.Quit();
        }
        #endregion
    }
}