using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// Teleports the player to the position of your choice!
    /// </summary>

    public class TeleportLogic : MonoBehaviour
    {
        public Transform linkedTeleporter;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && linkedTeleporter != null)
            {
                other.transform.position = linkedTeleporter.position;
            }
        }
    }
}