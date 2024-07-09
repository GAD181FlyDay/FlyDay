using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TaxiMeter
{

    public class TaxiMeterBaseLogic : MonoBehaviour
    {
        #region Variables
        private float meterNumber = 0.00f; // Initial meter value.
        public TMP_Text meterText; 
        #endregion

        void Start()
        {
            UpdateMeterText();
        }

        #region Public Functions
        public void AdjustMeter(float amount)
        {
            ///<summary>
            /// This function will be used by other scripts to impact the
            /// meter beased on matched or unmatched notes.
            /// </summary>
            meterNumber += amount; // Adjust the meter value
            UpdateMeterText(); // Update the UI text
        }
        #endregion

        #region Private Functions
        void UpdateMeterText()
        {
            ///<summary>
            /// This Function changes the text of the meter in
            /// the beginning of the minigame.
            /// </summary>
            meterText.text = ("Meter: " + meterNumber); // Update the meter display
        }
        #endregion
    }
}