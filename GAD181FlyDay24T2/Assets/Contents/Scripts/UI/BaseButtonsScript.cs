using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{


    public class BaseButtonsScript : MonoBehaviour
    {

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

        #endregion
        #region Credits Button

        #endregion
        #region EXit Button

        #endregion
    }
}