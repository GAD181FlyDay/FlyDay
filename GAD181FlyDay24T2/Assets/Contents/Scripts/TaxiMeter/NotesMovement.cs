using UnityEngine;

namespace TaxiMeter
{
    /// <summary>
    /// This script is responsible for the notes' movement.
    /// </summary>

    public class NotesMovement : MonoBehaviour
    {
        #region Variables
        public float speed = 5f; // Speed at which the note falls
        [SerializeField] private float bottomScreenOutboundReachedPosition = -5.5f; // make this a const once I'm sure of the screen outbound.
        #endregion

        private void Update()
        {
            NotesMovementLogic();
        }

        #region Private Functions
        private void NotesMovementLogic()
        {
            // Move the note downwards.
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            // Check if the note has exited the screen
            if (transform.position.y < bottomScreenOutboundReachedPosition)
            {
                Destroy(gameObject);
            }
        }
        #endregion
    }
}