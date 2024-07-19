using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    public class PlayerDashing : MonoBehaviour
    {
        #region Variables.
        public float dashSpeed = 20f; // Speed of the dash
        public float dashDuration = 0.5f; // Duration of the dash
        public Players player;

        private KeyCode _dashKey;
        private float _dashTime = 0f;
        private bool _isDashing = false;
        private Rigidbody _rigidbody;
        private PlayersInteraction _playersInteraction;
        #endregion

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playersInteraction = GetComponent<PlayersInteraction>();

            switch (player)
            {
                case Players.one:
                    _dashKey = KeyCode.Q;
                    break;
                case Players.two:
                    _dashKey = KeyCode.RightControl;
                    break;
            }

            // Ensure Rigidbody settings
            _rigidbody.mass = 1f;
            _rigidbody.drag = 0f;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        private void Update()
        {
            HandleDash();
        }

        #region Private Functions.
        private void HandleDash()
        {
            if (Input.GetKeyDown(_dashKey) && !_isDashing)
            {
                _isDashing = true;
                _dashTime = dashDuration;
            }

            if (_isDashing)
            {
                _dashTime -= Time.deltaTime;
                Dash();

                _playersInteraction.UpdateLuggagePositions();

                if (_dashTime <= 0)
                {
                    _isDashing = false;
                    _rigidbody.velocity = Vector3.zero; // Stop the dash by nullifying the velocity
                }
            }
        }

        private void Dash()
        {
            // Apply continuous dash force
            Vector3 dashDirection = transform.forward * dashSpeed * Time.deltaTime;
            _rigidbody.AddForce(dashDirection, ForceMode.VelocityChange);
            Debug.Log("Dashing in direction: " + dashDirection);
        }
        #endregion
    }
}
