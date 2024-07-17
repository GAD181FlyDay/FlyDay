using UnityEditor.EditorTools;
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

        #region Private Functions.
        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayersInteraction _player = other.GetComponent<PlayersInteraction>();
                if (_player == null)
                {
                    Debug.LogError("PlayerInteraction component not found on _player");
                    return;
                }

                if (Input.GetKeyDown(_player.interactionKey))
                {
                    if (_player.CanPickUpLuggage())
                    {
                        string tag = GetTagName(luggageType);
                        GameObject newLuggage = LuggagePooling.luggagePoolingInstance.SpawnLuggageFromPool(tag, _player.transform.position, Quaternion.identity);
                        if (newLuggage == null)
                        {
                            Debug.LogError("Couldn't spawn luggage from the pool: " + tag);
                            return;
                        }

                        Luggage luggage = newLuggage.GetComponent<Luggage>();
                        if (luggage == null)
                        {
                            Debug.LogError("Luggage component not found on spawned luggage");
                            return;
                        }

                        luggage.luggageType = luggageType;
                        _player.PickUpLuggage(newLuggage);
                    }
                }
            }
        }

        string GetTagName(string type)
        {
            switch (type.ToLower())
            {
                case "black":
                    return "BlackLuggageBag";
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