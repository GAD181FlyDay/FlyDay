using UnityEngine.SceneManagement;
using UnityEngine;

namespace Player.One
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        public Animator playerAnimator;
        public Rigidbody playerRigidbody;
        public float moveSpeed = 0.4f, rotateSpeed = 1000f; // used to be dSpeed
        public float jumpForce = 100f;

        [SerializeField] PauseMenu pauseMenu;
        [SerializeField] private PlayerSaveData playerOneData;

        private bool _walking;
        private bool _isGrounded;
        private float _walkingAnimationDelay = 0.25f;
        private float _walkingAnimationTimer;
        #endregion

        void Start()
        {
            pauseMenu = GetComponent<PauseMenu>();
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

            #region Do we need sneaking?? not really
            //if (Input.GetKey(KeyCode.C) && walking)
            //{
            //    playerAnimator.SetBool("Sneaking", true);
            //    moveSpeed = 0.07f;
            //}
            //else
            //{
            //    playerAnimator.SetBool("Sneaking", false);
            //    moveSpeed = 0.5f;
            //}
            #endregion
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
                playerOneData.playerOnePos = transform.position;

                if (pauseMenu != null)
                {
                    if (pauseMenu.isPanelActive)
                    {
                        Debug.Log("Players can't move.");
                    }
                    else
                    {
                        Time.timeScale = 1.0f;
                    }
                }
            }
        }

        private void PlayerJumpCheckerAndExecuter()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
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
                _walking = playerAnimator.GetBool("Walking");
            }
            else
            {
                Debug.Log("Won't play animations");
                return;
            }
        }

        private void WalkingAnimationDelayer()
        {
            bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

            if (isMoving)
            {
                _walkingAnimationTimer = _walkingAnimationDelay; // Reset timer when moving
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
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

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
