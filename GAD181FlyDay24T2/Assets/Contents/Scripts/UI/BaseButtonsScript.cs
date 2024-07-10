using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
        [SerializeField] private GameObject optionsPanel;
        [SerializeField] private GameObject creditsPanel;
        [SerializeField] private GameObject lastSelectedButton;

        #endregion


        #region Play Button 
        /// <summary>
        /// This function is assigned to the play button, 
        /// it directs the player to the start of the game.
        /// </summary>
        public void StartTheGame()
        {
            // Loads the game scene.
            SceneManager.LoadScene("MainGameScene");
        }

        #endregion

        #region options Button
        /// <summary>
        /// Turns on the options panel.
        /// </summary>
        public void TurnOnOptionPanel()
        {
            optionsPanel.SetActive(true);
        }

        /// <summary>
        /// Turns off the options panel.
        /// </summary>
        public void TurnOffOptionPanel()
        {
            optionsPanel.SetActive(false);
            EventSystem.current.SetSelectedGameObject(lastSelectedButton);
        }
        #endregion

        #region Credits Button

        /// <summary> 
        /// turns on the credits panel
        /// </summary>
        public void TurnOnCreditsPanel()
        {
            creditsPanel.SetActive(true);
        }

        ///<summary>
        /// Turns off the credits panel
        /// </summary>
        public void TurnOffCreditsPanel()
        {
            creditsPanel.SetActive(false);
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