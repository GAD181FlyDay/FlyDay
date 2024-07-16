using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// Assign to luggage bags, 
    /// Creates a luggage bag prefab for the players to pick-up.
    /// </summary>

    public class LuggageBoxes : MonoBehaviour
    {
        #region Variables.
        public string luggageType; // "black", "red", "green"
        #endregion

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && Input.GetKeyDown(other.GetComponent<PlayersInteraction>().interactionKey))
            {
                PlayersInteraction player = other.GetComponent<PlayersInteraction>();
                if (player.CanPickUpLuggage())
                {
                    GameObject newLuggage = Instantiate(Resources.Load("LuggagePrefab"), player.transform.position, Quaternion.identity) as GameObject;
                    Luggage luggage = newLuggage.GetComponent<Luggage>();
                    luggage.luggageType = luggageType;
                    player.PickUpLuggage(newLuggage);
                }
            }
        }
    }
}