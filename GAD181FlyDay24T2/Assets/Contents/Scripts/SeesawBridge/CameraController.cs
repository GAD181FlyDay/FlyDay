using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeesawBridge
{
    /// <summary>
    /// This script is for Seesaw bridge's camera, it moves forward and backwards.
    /// </summary>

    public class CameraController : MonoBehaviour
    {
        #region Variables
        public Transform player1;
        public Transform player2;
        public float cameraSmoothSpeed = 0.125f;
        private float fixedXPosition;
        private float fixedYPosition;
        #endregion

        void Start()
        {
            fixedXPosition = transform.position.x;
            fixedYPosition = transform.position.y;
        }

        void LateUpdate()
        {
            if (player1 == null || player2 == null)
                return;

            Vector3 midpoint = CalculatedMidpoint();
            AdjustCameraPosition(midpoint);
        }

        #region Private Functions
        private Vector3 CalculatedMidpoint()
        {
            return (player1.position + player2.position) / 2f;
        }

        private void AdjustCameraPosition(Vector3 midpoint)
        {
            Vector3 targetPosition = new Vector3(fixedXPosition, fixedYPosition, midpoint.z - 0.8f);
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, cameraSmoothSpeed);
            transform.position = smoothPosition;
        }
        #endregion
    }
}