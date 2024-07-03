using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerOne
{


    public class Player2Controller : MonoBehaviour
    {
        public Animator playerAnimator;
        public Rigidbody playerRigidbody;
        public float dSpeed = 0.175f, rotateSpeed = 200;
        public float acceleration;
        private float currentSpeed = 0f;



        void Start()
        {

        }


        void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal1");
            float vertical = Input.GetAxis("Vertical1");

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
            bool pressSneak = (Input.GetKeyDown(KeyCode.C));
            bool pressWalk = (Input.GetKeyDown(KeyCode.D));
            bool pressRunning = (Input.GetKeyDown(KeyCode.LeftShift));
            bool running = playerAnimator.GetBool("Running");
            bool walking = playerAnimator.GetBool("Walking");
            bool sneaking = playerAnimator.GetBool("Sneaking");


            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerAnimator.SetBool("Walking", true);
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerAnimator.SetBool("Walking", true);

            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                playerAnimator.SetBool("Walking", true);

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                playerAnimator.SetBool("Walking", true);

            }
            else
            {
                playerAnimator.SetBool("Walking", false);
            }

            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                playerAnimator.SetBool("Jumping", true);
            }



            if (Input.GetKey(KeyCode.RightShift))
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