using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// Script responsible for players dashing on key input.
    /// </summary>

    public class PlayerDashing : MonoBehaviour
    {
        #region Variables.
        public float dashSpeed = 2f;
        public float dashDuration = 0.5f;
        public Players player;

        private KeyCode _dashKey;
        private float _dashTime = 0f;
        private bool _isDashing = false;
        #endregion

        private void Start()
        {
            switch (player)
            {
                case Players.one:
                    _dashKey = KeyCode.Q;
                    break;
                case Players.two:
                    _dashKey = KeyCode.RightControl;
                    break;
            }
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
                transform.Translate(Vector3.forward * dashSpeed * Time.deltaTime);

                if (_dashTime <= 0)
                {
                    _isDashing = false;
                }
            }
        }
        #endregion
    }
}