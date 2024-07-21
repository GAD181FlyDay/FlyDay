using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueMovingCode : MonoBehaviour
{
    public int currentCodeRotation = 0;

    void RotateStatue()
    {
        transform.Rotate(new Vector3(0, 90, 0)); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateStatue();
        }
    }
}
