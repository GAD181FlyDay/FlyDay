
using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// Moves the platform within three positions.
    /// </summary>

    public class SideToSideMovingPlatform : MonoBehaviour
    {
        #region Variables.
        public Transform posA;
        public Transform posB;
        public float speed = 0.5f;

        private bool movingToB = true;
        #endregion

        private void Start()
        {
            transform.position = posA.position; 
        }

        private void Update()
        {
            MovePlatform();
        }

        #region Private Functions.
        private void MovePlatform()
        {
            if (movingToB)
            {
                transform.position = Vector3.MoveTowards(transform.position, posB.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, posB.position) < 0.1f)
                {
                    movingToB = false; // Switch direction
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, posA.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, posA.position) < 0.1f)
                {
                    movingToB = true; // Switch direction
                }
            }
        }
        #endregion
    }

}