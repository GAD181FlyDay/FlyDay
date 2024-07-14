using UnityEngine;

namespace JustifyableShoplifting
{
    /// <summary>
    /// Handles players reaching checkpoints in scene logic.
    /// </summary>

    public class Checkpoint : MonoBehaviour
    {
        #region Variables.
        public int checkpointIndex;
        public LayerMask playerLayer;

        public delegate void CheckpointReached(int index);
        public static event CheckpointReached OnCheckpointReached;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            // if the collided with object is on the player layer...
            if (((1 << other.gameObject.layer) & playerLayer) != 0)
            {
                Debug.Log($"Player reached checkpoint {checkpointIndex}");
                OnCheckpointReached?.Invoke(checkpointIndex);
            }
        }
    }
}