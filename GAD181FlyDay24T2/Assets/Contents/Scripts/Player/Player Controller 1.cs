using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public Animator playerAnimator;
    public Rigidbody playerRigidbody;
    public float wSpeed, sSpeed, dSpeed, aSpeed, rotateSpeed;
    public bool Walking, Running, Jumping, Sneaking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerRigidbody.velocity = transform.forward * dSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerRigidbody.velocity = -transform.forward * aSpeed * Time.deltaTime; ;
        }
         
    }

    private void Update()
    {
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
            if (Walking = true)
            {
                playerAnimator.SetBool("Sneaking", true);
            }
        }
    }
}
