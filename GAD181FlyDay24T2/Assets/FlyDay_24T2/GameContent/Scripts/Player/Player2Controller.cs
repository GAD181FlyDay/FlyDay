using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player.Tw0
{
    public class Player2Controller : MonoBehaviour
    {
        #region Variables
        [SerializeField] private PlayerSaveData playerTwoData;
        public Animator playerAnimator;
        public Rigidbody playerRigidbody;
        public float moveSpeed = 0.4f, rotateSpeed = 1000f;
        public float jumpForce = 100f;

        private bool _isGrounded;
        private float _walkingAnimationDelay = 0.25f;
        private float _walkingAnimationTimer;
        #endregion

        void Start()
        {
            // transform.position = playerTwoData.playerTwoPos;
        }

        void FixedUpdate()
        {
            MovePlayer();
        }

        private void Update()
        {
            CurrentSceneChecker();
            WalkingAnimationSetter();
            WalkingAnimationDelayer();
            PlayerJumpCheckerAndExecuter();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = false;
            }
        }

        #region Private Functions

        private void CurrentSceneChecker()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "MainGameScene")
            {
                playerTwoData.playerTwoPos = transform.position;
            }
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
