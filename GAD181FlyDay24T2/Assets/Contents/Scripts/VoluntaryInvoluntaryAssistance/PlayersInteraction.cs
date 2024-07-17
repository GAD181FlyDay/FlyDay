using System.Collections.Generic;
using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// Luggage interractions (Dropping and picking up.)
    /// </summary>

    public class PlayersInteraction : MonoBehaviour
    {
        #region Variables
        public Players player;
        public Transform holdPoint;
        public KeyCode interactionKey;
        public KeyCode dropKey;

        private List<GameObject> heldLuggage = new List<GameObject>();
        #endregion

        private void Start()
        {
            switch (player)
            {
                case Players.one:
                    interactionKey = KeyCode.E;
                    dropKey = KeyCode.Q;
                    break;
                case Players.two:
                    interactionKey = KeyCode.RightShift;
                    dropKey = KeyCode.RightControl;
                    break;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(interactionKey))
            {
                if (heldLuggage.Count == 0)
                {
                    Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f);
                    foreach (var collider in colliders)
                    {
                        if (collider.CompareTag("Luggage"))
                        {
                            PickUpLuggage(collider.gameObject);
                            break;
                        }
                    }
                }
            }

            if (Input.GetKeyDown(dropKey))
            {
                DropLuggage();
            }
        }

        #region Public Functions
        public void PickUpLuggage(GameObject luggage)
        {
            heldLuggage.Add(luggage);
            luggage.transform.SetParent(holdPoint);
            luggage.transform.localPosition = Vector3.up * heldLuggage.Count;
            luggage.transform.localRotation = Quaternion.identity;

            Rigidbody rb = luggage.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true; 
            }
        }

        public bool CanPickUpLuggage()
        {
            if (heldLuggage.Count == 0)
                return true;

            Luggage lastLuggage = heldLuggage[heldLuggage.Count - 1].GetComponent<Luggage>();

            if (lastLuggage.isOnPlate)
            {
                return heldLuggage.Count < 3;
            }
            else
            {
                return heldLuggage.Count < 2;
            }
        }

        public List<GameObject> GetHeldLuggage()
        {
            return heldLuggage;
        }

        public void RemoveLuggage(GameObject luggage)
        {
            heldLuggage.Remove(luggage);
        }
        #endregion

        #region Private Functions
        private void DropLuggage()
        {
            foreach (var luggage in heldLuggage)
            {
                luggage.transform.SetParent(null);

                Rigidbody rb = luggage.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false; 
                }
            }
            heldLuggage.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Luggage"))
            {
                Luggage luggage = other.GetComponent<Luggage>();

                if (heldLuggage.Count > 0)
                {
                    Luggage lastLuggage = heldLuggage[heldLuggage.Count - 1].GetComponent<Luggage>();

                    if (lastLuggage.CanStackLuggage())
                    {
                        luggage.isOnPlate = lastLuggage.isOnPlate;
                        luggage.transform.SetParent(holdPoint);
                        // luggage.transform.localPosition = new Vector3(0, heldLuggage.Count * 0.5f, 0);
                        // luggage.transform.localRotation = Quaternion.identity;

                        Rigidbody rb = luggage.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            rb.isKinematic = true; 
                        }

                        lastLuggage.AddLuggage();
                        heldLuggage.Add(other.gameObject);
                    }
                }
            }
        }
        #endregion
    }
}