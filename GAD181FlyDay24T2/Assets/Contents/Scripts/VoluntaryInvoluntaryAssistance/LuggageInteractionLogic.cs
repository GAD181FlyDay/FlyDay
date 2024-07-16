using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// Picking up and dropping luggage logic.
    /// </summary>

    public class LuggageInteractionLogic : MonoBehaviour
    {
        #region variables
        public Players player;

        private GameObject _heldLuggage;
        private KeyCode _interactionKey;
        #endregion
        

        private void Start()
        {
            // Assign interaction keys based on the player type
            switch (player)
            {
                case Players.one:
                    _interactionKey = KeyCode.Q;
                    break;
                case Players.two:
                    _interactionKey = KeyCode.RightShift;
                    break;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(_interactionKey))
            {
                if (_heldLuggage == null)
                {
                    HoldLuggage();
                }
                else
                {
                    _heldLuggage.transform.SetParent(null);
                    _heldLuggage = null;
                }
            }
        }

        #region Private Functions.
        private void HoldLuggage()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Luggage"))
                {
                    _heldLuggage = collider.gameObject;
                    _heldLuggage.transform.SetParent(transform);
                    _heldLuggage.transform.localPosition = Vector2.zero;
                    break;
                }
            }
        }
        #endregion
    }
}