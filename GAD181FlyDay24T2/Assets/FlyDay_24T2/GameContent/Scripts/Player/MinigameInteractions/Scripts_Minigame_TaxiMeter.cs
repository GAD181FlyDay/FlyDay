using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dana
{

    public class Scripts_Minigame_TaxiMeter : Scripts_InteractionBaseToOverride
    {
        #region Variables.
        #endregion

        public override void Interact()
        {
            SceneManager.LoadScene("TaxiMeter");
        }
    }
}