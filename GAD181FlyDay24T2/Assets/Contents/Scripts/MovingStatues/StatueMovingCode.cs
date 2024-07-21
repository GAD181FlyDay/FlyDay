using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueMovingCode : MonoBehaviour
{
    public int currentCodeRotation = 0;
    bool playerDettected;

    void RotateStatue()
    {
        transform.Rotate(new Vector3(0, 90, 0)); 
        if (currentCodeRotation < 3)
        {
            currentCodeRotation ++;
        }
        else 
        {
            currentCodeRotation = 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerDettected == true)
        {
            RotateStatue();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerDettected = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerDettected = false;
        }
    }
}
