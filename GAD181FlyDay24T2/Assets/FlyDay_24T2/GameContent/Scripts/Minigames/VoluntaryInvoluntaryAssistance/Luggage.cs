using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// Adds a label to each luggage bag prefab.
    /// Tracks stacks.
    /// </summary>

    public class Luggage : MonoBehaviour
    {
        #region Variables.
        public string luggageType;
        public bool isOnPlate;
        public int stackCount;
        public PlayerRespawnLogic playerRespawnLogic;
        #endregion

        private void Start()
        {
            stackCount = 1;
        }

        #region Public Functions.
        public void AddLuggage()
        {
            stackCount++;
        }

        public bool CanStackLuggage()
        {
            return isOnPlate ? stackCount < 3 : stackCount < 2;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == playerRespawnLogic.outboundObject )
            {
                this.gameObject.SetActive(false);
            }
        }
        #endregion
    }
}