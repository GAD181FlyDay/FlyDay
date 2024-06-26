using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public Rigidbody playerRigidbody;
    public float dSpeed, rotateSpeed; 
   

    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;

        if (movement == Vector3.zero)
        {
            return;
        }

        playerRigidbody.MovePosition(playerRigidbody.position + movement * Time.fixedDeltaTime);
    }

    private void Update()
    {
        bool pressSneak = (Input.GetKeyDown(KeyCode.C));
        bool pressWalk = (Input.GetKeyDown(KeyCode.D));
        bool pressRunning = (Input.GetKeyDown(KeyCode.D));
        bool running = playerAnimator.GetBool("Running");
        bool walking = playerAnimator.GetBool("Walking");
        bool sneaking = playerAnimator.GetBool("Sneaking");


        if (Input.GetKeyDown(KeyCode.D))
        {
            playerAnimator.SetBool("Walking", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetBool("Jumping", true);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {

        }
    }
}
