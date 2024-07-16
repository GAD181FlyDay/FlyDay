using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{

    /// <summary>
    /// Moves the luggage bags along the conveyor if they have the luggage tag.
    /// </summary>

    public class ConveyorBeltLogic : MonoBehaviour
    {
        #region Variables.
        public float speed = 2f;
        #endregion

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Luggage"))
            {
                other.transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
    }
}