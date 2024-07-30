using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainGameScene.Players
{


    public class Scripts_PlayerMainGameScenePositionsManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] PauseMenu pauseMenu;
        [SerializeField] private PlayerSaveData playersData;
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
                playersData.playerOnePos = transform.position;
                playersData.playerTwoPos = transform.position;
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