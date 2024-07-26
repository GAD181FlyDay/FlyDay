using UnityEngine;

namespace TaxiMeter
{
    /// <summary>
    /// This script is responsible for the notes' movement.
    /// </summary>

    public class NotesMovement : MonoBehaviour
    {
        #region Variables
        public float noteSpeed = 2.0f; 

        public TaxiMeterBaseLogic taxiMeterBaseLogicInstance;
        #endregion

        private void Update()
        {
            NotesMovementLogic();
        }

        #region Private Functions
        private void NotesMovementLogic()
        {
            // Move the note downward.
            transform.Translate(Vector3.down * noteSpeed * Time.deltaTime);

            // Deactivate note if it goes off-screen.
            if (transform.position.y < -10)
            {

                gameObject.SetActive(false);
                taxiMeterBaseLogicInstance.UpdateMeter(false);

            }
        }
        #endregion
    }
}