using TMPro;
using UnityEngine;

namespace TaxiMeter
{
    /// <summary>
    /// Handles the taxi meter logic in terms of updating
    /// the number text on the meter.
    /// </summary>
    
    public class TaxiMeterBaseLogic : MonoBehaviour
    {
        #region Variable

        public static TaxiMeterBaseLogic taxiMeterBaseLogic;

        public float meterValue = 0.00f;
        private float _correctMatchIncrease = 0.25f;
        [SerializeField] private TMP_Text meterText;
        private float _incorrectMatchIncrease = 1.5f;

        #endregion

        private void Start()
        {
            meterText.text = meterValue + " $";
        }
        private void Awake()
        {
            if (taxiMeterBaseLogic == null)
            {
                taxiMeterBaseLogic = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #region Public Functions.
        public void UpdateMeter(bool isCorrectMatch)
        {
            ///<summary>
            /// Updates the meter on screen depending on
            /// whether the match is correct or incorrect.
            /// </summary>

            MakeSureTheMeterDoesntExceed100();

            if (isCorrectMatch)
            {
                meterValue += _correctMatchIncrease;
            }
            else
            {
                meterValue += _incorrectMatchIncrease;
            }
            meterText.text = meterValue + " $";
            // Debug.Log("Meter Value: " + meterValue);
        }

        public void MakeSureTheMeterDoesntExceed100()
        {
            /// <summary>
            /// This is to be edited, I need the meter 
            /// to not exceed 100 because the players 
            /// only have 100 lucky coins.
            /// </summary>
             
            if (meterValue > 100f)
            {
                meterValue = 100f;
                meterText.text = 100 + " $";
                return;
            }
        }
        #endregion
    }
}