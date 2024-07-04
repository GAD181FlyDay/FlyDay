using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private float minOrthographicSize = 5f;
        [SerializeField] private float maxOrthographicSize = 10f;
        [SerializeField] private float zoomSpeed = 2f;
        [SerializeField] private float cameraHeight = -65f;
        [SerializeField] private float cameraSmoothSpeed = 0.125f;

        [SerializeField] private Camera cam;
        #endregion

        private void LateUpdate()
        {
            // If the first or Second players are not assigned then don't execute the following code.
            if (player1 == null || player2 == null)
                return;

            // Get the player positions and divid by two. That's the mid point in which the camera will follow.
            Vector3 midpoint = (player1.position + player2.position) / 2f;

            // Smooth movement left and right, the camera's height is adjusted so that it isn't only showing the players' feet.
            Vector3 smoothPosition = Vector3.Lerp(transform.position, new Vector3(midpoint.x, midpoint.y * cameraHeight, transform.position.z), cameraSmoothSpeed);

            // Continuously updates position of the camera.
            transform.position = smoothPosition;
        }
    }
}