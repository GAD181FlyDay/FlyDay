using UnityEngine;

namespace TaxiMeter
{
    /// <summary>
    /// This stores notes/ types of notes.
    /// </summary>
    public class Notes : MonoBehaviour
    {
        #region Variables
        public string noteType; // Type of the note.
                                // This script is to be attached to different notes to define their type!
        #endregion

        private void OnEnable()
        {
            // I'll add restart game logic here to reset notes or somethin.
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

    }
}