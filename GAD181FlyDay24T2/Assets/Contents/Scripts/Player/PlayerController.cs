using UnityEngine.SceneManagement;
using UnityEngine;

namespace Player.One
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerSaveData playerOneData;
        public Animator playerAnimator;
        public Rigidbody playerRigidbody;
        public float dSpeed = 0.27f, rotateSpeed = 200;
        [SerializeField] private float inspectorChangeablePlayerSpeed = 2f;
        public float acceleration;
        private float currentSpeed = 0f;
        bool walking;


        void Start()
        {

        }

        void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontal, 0, vertical);
            movement.Normalize();

            if (movement == Vector3.zero)
            {
                return;
            }

           
            if (movement != Vector3.zero)
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, dSpeed, acceleration * Time.fixedDeltaTime);
                playerRigidbody.MovePosition(playerRigidbody.position + movement * currentSpeed * Time.fixedDeltaTime);
                Quaternion rotateQuat = Quaternion.LookRotation(movement,Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateQuat, rotateSpeed * Time.deltaTime);
            }
        }


        private void Update()
        {
            CurrentSceneChecker();
            

            if (playerAnimator != null)
            {
                bool pressSneak = (Input.GetKeyDown(KeyCode.C));
                bool pressWalk = (Input.GetKeyDown(KeyCode.D));
                bool pressRunning = (Input.GetKeyDown(KeyCode.LeftShift));
                bool running = playerAnimator.GetBool("Running");
                walking = playerAnimator.GetBool("Walking");
                bool sneaking = playerAnimator.GetBool("Sneaking");
            }
            else if (playerAnimator == null)
            {
                Debug.Log("Won't play aniamtions");
                return;
            }

            if (Input.GetKey(KeyCode.W))
            {
                playerAnimator.SetBool("Walking", true);
            }

            else if (Input.GetKey(KeyCode.A))
            {
                playerAnimator.SetBool("Walking", true);

            }

            else if (Input.GetKey(KeyCode.S))
            {
                playerAnimator.SetBool("Walking", true);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                playerAnimator.SetBool("Walking", true);

            }
            else
            {
                playerAnimator.SetBool("Walking", false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnimator.SetBool("Jumping", true);
            }

            else
            {
                playerAnimator.SetBool("Jumping", false) ;
            }

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
                PlayerTwoSpeedChanger(inspectorChangeablePlayerSpeed);
            }
        }
   
        private void PlayerTwoSpeedChanger(float speed)
        {
            dSpeed = speed;
        }

        #region Private Functions

        private void CurrentSceneChecker()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "MainGameScene")
            {
                #region Give player's position to ScriptableObject.
                playerOneData.playerOnePos = transform.position;
                #endregion
            }
        }
        #endregion

    }
}