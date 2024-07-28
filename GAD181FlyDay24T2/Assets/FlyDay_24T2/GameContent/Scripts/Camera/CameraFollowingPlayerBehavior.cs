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
        [SerializeField] private float cameraSmoothSpeed = 1.5f;
        [SerializeField] private Camera cam;

        private Vector3 previousMidpoint;
        #endregion

        private void Start()
        {
            // I initialised the midpoint calculation in the beginning for better calculation accuraccyw
            if (player1 != null && player2 != null)
            {
                previousMidpoint = (player1.position + player2.position) / 2f;
            }
        }

        private void LateUpdate()
        {
            // If the first or second player is not assigned, don't execute the following code.
            if (player1 == null || player2 == null)
                return;

            // Get the player positions and divide by two. That's the midpoint the camera will follow.
            Vector3 currentMidpoint = (player1.position + player2.position) / 2f;

            // Smooth the midpoint transition
            Vector3 smoothedMidpoint = Vector3.Lerp(previousMidpoint, currentMidpoint, cameraSmoothSpeed);
            previousMidpoint = smoothedMidpoint;

            // Smooth movement left and right. Keep the camera at a fixed height above the midpoint.
            Vector3 smoothPosition = new Vector3(smoothedMidpoint.x, cameraHeight, transform.position.z);

            // Continuously update the position of the camera.
            transform.position = smoothPosition;
        }
    }
}
