using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerOne
{


    public class PlayerController : MonoBehaviour
    {
        public Animator playerAnimator;
        public Rigidbody playerRigidbody;
        public float dSpeed = 0.175f, rotateSpeed = 200;
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
            if (playerAnimator != null)
            {
                bool pressSneak = (Input.GetKeyDown(KeyCode.C));
                bool pressWalk = (Input.GetKeyDown(KeyCode.D));
                bool pressRunning = (Input.GetKeyDown(KeyCode.LeftShift));
                bool running = playerAnimator.GetBool("Running");
                walking = playerAnimator.GetBool("Walking");
                bool sneaking = playerAnimator.GetBool("Sneaking");
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
                    dSpeed = 0.05f;
                }

            }
            else
            {
                playerAnimator.SetBool("Sneaking", false);
                dSpeed = 0.175f;
            }
        }
    }
}