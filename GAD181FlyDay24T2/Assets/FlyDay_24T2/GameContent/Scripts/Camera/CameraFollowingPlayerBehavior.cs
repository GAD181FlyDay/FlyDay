
using UnityEngine;

namespace CameraBehavior
{
    /// <summary>
    /// Follows the players left and right.
    /// This script does not restrict their movement!
    /// </summary>

    public class CameraFollowingPlayerBehavior : MonoBehaviour
    {
        #region Variables
        public Transform player1;
        public Transform player2;
        [SerializeField] private float cameraHeight = 10f; // Adjust the height to a positive value
        [SerializeField] private float cameraSmoothSpeed = 0.125f;
        [SerializeField] private Camera cam;
        #endregion

        private void LateUpdate()
        {
            // If the first or second player is not assigned, don't execute the following code.
            if (player1 == null || player2 == null)
                return;

            // Get the player positions and divide by two. That's the midpoint the camera will follow.
            Vector3 midpoint = (player1.position + player2.position) / 2f;

            // Smooth movement left and right. Keep the camera at a fixed height above the midpoint.
            Vector3 smoothPosition = Vector3.Lerp(transform.position, new Vector3(midpoint.x, cameraHeight, transform.position.z), cameraSmoothSpeed);

            // Continuously update the position of the camera.
            transform.position = smoothPosition;
        }
    }
}