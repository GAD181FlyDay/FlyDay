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

        public bool isInMatchArea = false;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MatchArea"))
            {
                isInMatchArea = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("MatchArea"))
            {
                isInMatchArea = false;
            }
        }
    }
}