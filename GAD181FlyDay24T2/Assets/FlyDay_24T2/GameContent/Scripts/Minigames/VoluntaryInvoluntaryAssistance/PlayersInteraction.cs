using System.Collections.Generic;
using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    ///  This script is responsible for players interacting with luggage boxes and luggages.
    /// </summary>
    
    public class PlayersInteraction : MonoBehaviour
    {
        #region Variables.
        public Players player;
        public Transform holdPoint;
        public KeyCode interactionKey;
        public KeyCode dropKey;
        public float luggageSpacing = 2f;
        public int maxLuggageCount = 3;

        private List<GameObject> _heldLuggage = new List<GameObject>();
        #endregion

        private void Start()
        {
            switch (player)
            {
                case Players.one:
                    interactionKey = KeyCode.E;
                    dropKey = KeyCode.LeftAlt;
                    break;
                case Players.two:
                    interactionKey = KeyCode.RightShift;
                    dropKey = KeyCode.RightAlt;
                    break;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(interactionKey))
            {
                if (_heldLuggage.Count < maxLuggageCount)
                {
                    Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f);
                    foreach (var collider in colliders)
                    {
                        if (collider.CompareTag("LuggageBox"))
                        {
                            LuggageBoxes luggageBox = collider.GetComponent<LuggageBoxes>();
                            if (luggageBox != null)
                            {
                                luggageBox.TrySpawnLuggage(this);
                            }
                            break;
                        }
                        else if (collider.CompareTag("Luggage"))
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
        public void DropLuggage()
        {
            foreach (var luggage in _heldLuggage)
            {
                luggage.transform.SetParent(null);
                luggage.tag = "Luggage"; // Forces tag on dropped object!!1

                Rigidbody rb = luggage.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }
            }
            _heldLuggage.Clear();
        }

        public void PickUpLuggage(GameObject luggage)
        {
            _heldLuggage.Add(luggage);
            luggage.transform.SetParent(holdPoint);
            luggage.tag = "HeldLuggage"; // Changes tag so that the same luggage doesn't get picked up again!
            UpdateLuggagePositions();

            Rigidbody rb = luggage.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }

        public bool CanPickUpLuggage()
        {
            return _heldLuggage.Count < maxLuggageCount;
        }

        public List<GameObject> GetHeldLuggage()
        {
            return _heldLuggage;
        }

        public void RemoveLuggage(GameObject luggage)
        {
            _heldLuggage.Remove(luggage);
            UpdateLuggagePositions();
        }

        public void UpdateLuggagePositions()
        {
            for (int i = 0; i < _heldLuggage.Count; i++)
            {
                _heldLuggage[i].transform.localPosition = Vector3.up * (i * luggageSpacing);
            }
        }
        #endregion
    }
}
