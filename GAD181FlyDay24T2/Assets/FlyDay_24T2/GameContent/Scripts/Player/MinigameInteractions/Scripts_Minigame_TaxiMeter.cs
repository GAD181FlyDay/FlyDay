using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dana
{


    public class Scripts_Minigame_TaxiMeter : Scripts_InteractionBaseToOverride
    {
        #region Variables.

        public Vector3 p1Position;
        public Vector3 p2Position;
        [SerializeField] private GameObject tempWall;
        [SerializeField] private PlayerSaveData playerSaveData;
        #endregion
        public override void Interact()
        {
            tempWall.SetActive(false);
            playerSaveData.playerOnePos = p1Position;
            playerSaveData.playerTwoPos = p2Position;
            SceneManager.LoadScene("TaxiMeter");
        }
    }
}