using UnityEngine;
using UnityEngine.SceneManagement;
using UI;

namespace MainGameScene.Players
{
    /// <summary>
    /// Might get rid of this script or change the name
    /// </summary>

    public class Scripts_PlayerMainGameScenePositionsManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] PauseMenu pauseMenu;
        //[SerializeField] private PlayerPositionsStorage playersPositions;
        #endregion

        void Start()
        {
            pauseMenu = GetComponent<PauseMenu>();
        }

        void Update()
        {
            CurrentSceneChecker();
        }

        private void CurrentSceneChecker()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "MainGameScene")
            {
                //playersPositions.playerOnePos = transform.position;
                //playersPositions.playerTwoPos = transform.position;
                if (pauseMenu != null)
                {
                    if (pauseMenu.isPanelActive)
                    {
                        Debug.Log("Players can't move.");
                    }
                    else
                    {
                        Time.timeScale = 1.0f;
                    }
                }

            }
        }
    }
}