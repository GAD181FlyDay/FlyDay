using UnityEngine.SceneManagement;
using UnityEngine;

namespace Player.One
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables.
        [SerializeField] PauseMenu pauseMenu;
        [SerializeField] private PlayerSaveData playerOneData;
        public Animator playerAnimator;
        public Rigidbody playerRigidbody;
        public float dSpeed = 0.5f, rotateSpeed = 1000f;
        private bool walking;
        #endregion

        void Start()
        {
            pauseMenu = GetComponent<PauseMenu>();
        }

        void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontal, 0, vertical);
            movement.Normalize();

            if (movement != Vector3.zero)
            {
                playerRigidbody.MovePosition(playerRigidbody.position + movement * dSpeed * Time.fixedDeltaTime);
                Quaternion rotateQuat = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateQuat, rotateSpeed * Time.deltaTime);
            }
            else
            {
                playerRigidbody.velocity = Vector3.zero; 
            }
        }

        private void Update()
        {
            CurrentSceneChecker();

            #region bool assigning to play animations
            if (playerAnimator != null)
            {
                //bool pressSneak = (Input.GetKeyDown(KeyCode.C));
                //bool pressWalk = (Input.GetKeyDown(KeyCode.D));
                //bool pressRunning = (Input.GetKeyDown(KeyCode.LeftShift));
                //bool running = playerAnimator.GetBool("Running");
                walking = playerAnimator.GetBool("Walking");
                //bool sneaking = playerAnimator.GetBool("Sneaking");
            }
            #endregion

            else if (playerAnimator == null)
            {
                Debug.Log("Won't play animations");
                return;
            }

            bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
            playerAnimator.SetBool("Walking", isMoving);

            #region Check if player is trying to jump.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnimator.SetBool("Jumping", true);
            }
            else
            {
                playerAnimator.SetBool("Jumping", false);
            }
            #endregion.

            #region Check if player is sneaking.
            if (Input.GetKey(KeyCode.C))
            {
                if (walking == true)
                {
                    playerAnimator.SetBool("Sneaking", true);
                    dSpeed = 0.07f;
                }
            }
            else
            {
                playerAnimator.SetBool("Sneaking", false);
                dSpeed = 0.5f; 
            }
            #endregion
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
        #endregion
    }
}
