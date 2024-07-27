using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dana
{
    public class Scripts_Minigame_LuggagePacking : Scripts_Generic_InteractionBase
    {
        #region Variables
        [SerializeField] private GameObject taxiMeterWall; // The wall that hides taxi meter minigame.

        #endregion

        private void Start()
        {
            taxiMeterWall.SetActive(true);
        }

        public override void Interact()
        {
            taxiMeterWall.SetActive(false);
            this.gameObject.SetActive(false); // Make this stand disappear.
                                              //SceneManager.LoadScene("PackingSuitcase");
        }
    }
}