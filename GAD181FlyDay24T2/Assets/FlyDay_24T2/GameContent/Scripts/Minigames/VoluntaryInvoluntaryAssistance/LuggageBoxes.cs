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
        public string luggageType; // "blue", "red", "green"
        #endregion

        #region Public Functions.
        public void TrySpawnLuggage(PlayersInteraction player)
        {
            if (player.CanPickUpLuggage())
            {
                string tag = GetTagName(luggageType);
                GameObject newLuggage = LuggagePooling.luggagePoolingInstance.SpawnLuggageFromPool(tag, player.transform.position, Quaternion.identity);
                if (newLuggage == null)
                {
                    // Debug.LogError("Couldn't spawn luggage from the pool: " + tag);
                    return;
                }

                Luggage luggage = newLuggage.GetComponent<Luggage>();
                if (luggage == null)
                {
                    // Debug.LogError("Luggage component not found on spawned luggage");
                    return;
                }

                luggage.luggageType = luggageType;
                player.PickUpLuggage(newLuggage);
            }
            else
            {
                // Debug.Log("Player cannot pick up more luggage.");
            }
        }
        
        #endregion

        #region Private Functions.
        private string GetTagName(string type)
        {
            switch (type.ToLower())
            {
                case "blue":
                    return "BlueLuggageBag";
                case "red":
                    return "RedLuggageBag";
                case "green":
                    return "GreenLuggageBag";
                default:
                    Debug.LogError("Unknown luggage type: " + type);
                    return null;
            }
        }
        #endregion
    }
}
