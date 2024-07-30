using UnityEngine;

namespace Player.Two
{
    public class Player2Controller : MonoBehaviour
    {
        #region Variables

        public Animator playerAnimator;
        public Rigidbody playerRigidbody;
        public float moveSpeed = 0.4f, rotateSpeed = 1000f;
        public float jumpForce = 100f;

        #region Raycast Vars
        public Transform groundCheck; 
        public float groundDistance = 0.1f; 
        public LayerMask groundMask;
        
        private bool _isGrounded;
        #endregion

        private float _walkingAnimationDelay = 0.25f;
        private float _walkingAnimationTimer;
        #endregion

        void FixedUpdate()
        {
            MovePlayer();
        }

        private void Update()
        {
            GroundCheck();
            WalkingAnimationSetter();
            WalkingAnimationDelayer();
            PlayerJumpCheckerAndExecuter();
        }

        #region Private Functions

        private void GroundCheck()
        {
            _isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundMask);
        }

        private void PlayerJumpCheckerAndExecuter()
        {
            if (Input.GetKeyDown(KeyCode.RightControl) && _isGrounded)
            {
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerAnimator.SetBool("Jumping", true);
            }
            else
            {
                playerAnimator.SetBool("Jumping", false);
            }
        }

        private void WalkingAnimationSetter()
        {
            if (playerAnimator != null)
            {
                bool walking = playerAnimator.GetBool("Walking");
            }
            else
            {
                Debug.Log("Won't play animations");
                return;
            }
        }

        private void WalkingAnimationDelayer()
        {
            bool isMoving = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow);

            if (isMoving)
            {
                _walkingAnimationTimer = _walkingAnimationDelay;
                playerAnimator.SetBool("Walking", true);
            }
            else
            {
                if (_walkingAnimationTimer > 0)
                {
                    _walkingAnimationTimer -= Time.deltaTime;
                }
                else
                {
                    playerAnimator.SetBool("Walking", false);
                }
            }
        }

        private void MovePlayer()
        {
            float horizontal = Input.GetAxis("Horizontal1");
            float vertical = Input.GetAxis("Vertical1");

            Vector3 movement = new Vector3(horizontal, 0, vertical);
            movement.Normalize();

            if (movement != Vector3.zero)
            {
                playerRigidbody.MovePosition(playerRigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
                Quaternion rotateQuat = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateQuat, rotateSpeed * Time.deltaTime);
            }
            else
            {
                playerRigidbody.velocity = new Vector3(0, playerRigidbody.velocity.y, 0);
            }
        }

        #endregion
    }
}
