using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// This script is responsible for player dashing Logic.
    /// </summary>

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
            #region Basic assignations of values and components.
            ///<summary>
            /// Rigidbody is assigned.
            /// Interaction script is assigned.
            /// KeyCodes for each players are assigned.
            /// Rigidbody is made sure to be specific values to avoid
            /// interfering with the dashing logic.
            /// </summary>

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

            RigidBodySettingsAdjuster();

            #endregion
        }

        private void Update()
        {
            HandleDash();
        }

        #region Private Functions.

        private void RigidBodySettingsAdjuster()
        {
            ///<summary>
            /// Sets player mass to a float of 1.
            /// Drag to 0.
            /// Sets constraints on players' XYZ rotations.
            /// </summary>

            _rigidbody.mass = 1f;
            _rigidbody.drag = 0f;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        private void HandleDash()
        {
            ///<summary>
            /// Checks for player input and checks if they weren't dashing
            /// to make them dash.
            ///  Ensures that the dash stops after the dash time has ended 
            ///  by nullifying the velocity.
            /// </summary>

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
                    _rigidbody.velocity = Vector3.zero;
                }
            }
        }

        private void Dash()
        {
            ///<summary>
            /// Continuously apply velocity force to the forward direction of the player.
            /// </summary>
            Vector3 dashDirection = transform.forward * dashSpeed * Time.deltaTime;
            _rigidbody.AddForce(dashDirection, ForceMode.VelocityChange);
            // Debug.Log("Dashing in direction: " + dashDirection);
        }
        #endregion
    }
}
