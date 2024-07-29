using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// Transports luggage around like a real conveyor belt!
    /// </summary>

    public class ConveyorBeltEmulation : MonoBehaviour
    {

        public float conveyorSpeed = 1f;

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Luggage"))
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = new Vector3(conveyorSpeed, rb.velocity.y, rb.velocity.z);
                }
            }
        }
    }
}