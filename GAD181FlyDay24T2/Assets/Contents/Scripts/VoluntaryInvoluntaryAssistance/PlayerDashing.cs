using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// Script responsible for players dashing on key input.
    /// </summary>

    public class PlayerDashing : MonoBehaviour
    {
        #region Variables.
        public float speed = 5f;
        public float dashSpeed = 10f;
        public float dashDuration = 0.5f;
        public Players player;

        private KeyCode _moveLeftKey;
        private KeyCode _moveRightKey;
        private KeyCode _moveUpKey;
        private KeyCode _moveDownKey;
        private KeyCode _dashKey;


        private float _dashTime = 0f;
        private bool _isDashing = false;
        #endregion

        private void Start()
        {
            switch (player)
            {
                case Players.one:
                    _moveLeftKey = KeyCode.A;
                    _moveRightKey = KeyCode.D;
                    _moveUpKey = KeyCode.W;
                    _moveDownKey = KeyCode.S;
                    _dashKey = KeyCode.Q;
                    break;
                case Players.two:
                    _moveLeftKey = KeyCode.LeftArrow;
                    _moveRightKey = KeyCode.RightArrow;
                    _moveUpKey = KeyCode.UpArrow;
                    _moveDownKey = KeyCode.DownArrow;
                    _dashKey = KeyCode.RightControl;
                    break;
            }
        }

        private void Update()
        {
            HandleMovement();
            HandleDash();
        }

        #region Private Functions.
        private void HandleMovement()
        {
            if (!_isDashing)
            {
                float moveX = 0f;
                float moveY = 0f;

                if (Input.GetKey(_moveLeftKey))
                    moveX = -1f;
                if (Input.GetKey(_moveRightKey))
                    moveX = 1f;
                if (Input.GetKey(_moveUpKey))
                    moveY = 1f;
                if (Input.GetKey(_moveDownKey))
                    moveY = -1f;

                Vector2 movement = new Vector2(moveX, moveY).normalized * speed * Time.deltaTime;
                transform.Translate(movement);
            }
        }

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
                transform.Translate(Vector2.up * dashSpeed * Time.deltaTime);

                if (_dashTime <= 0)
                {
                    _isDashing = false;
                }
            }
        }
        #endregion
    }
}