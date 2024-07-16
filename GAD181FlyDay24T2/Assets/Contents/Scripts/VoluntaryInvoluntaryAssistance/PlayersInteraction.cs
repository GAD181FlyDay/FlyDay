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
        private List<GameObject> heldLuggage = new List<GameObject>();
        public KeyCode interactionKey;
        #endregion

        private void Start()
        {
            switch (player)
            {
                case Players.one:
                    interactionKey = KeyCode.E;
                    break;
                case Players.two:
                    interactionKey = KeyCode.RightShift;
                    break;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(interactionKey))
            {
                if (heldLuggage.Count == 0)
                {
                    // Pick up luggage.
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
                    foreach (var collider in colliders)
                    {
                        if (collider.CompareTag("Luggage"))
                        {
                            PickUpLuggage(collider.gameObject);
                            break;
                        }
                    }
                }
                else
                {
                    // Drop luggage.
                    foreach (var luggage in heldLuggage)
                    {
                        luggage.transform.SetParent(null);
                    }
                    heldLuggage.Clear();
                }
            }
        }

        #region Public Functions.
        public void PickUpLuggage(GameObject luggage)
        {
            heldLuggage.Add(luggage);
            luggage.transform.SetParent(transform);
            luggage.transform.localPosition = Vector2.zero;
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
        #endregion

        #region Private Functions.
        private void OnTriggerEnter2D(Collider2D other)
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
                        luggage.transform.SetParent(transform);
                        luggage.transform.localPosition = new Vector2(0, heldLuggage.Count * 0.5f);
                        lastLuggage.AddLuggage();
                        heldLuggage.Add(other.gameObject);
                    }
                }
            }
        }
        #endregion
    }
}