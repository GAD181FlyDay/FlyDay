using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement2 : MonoBehaviour
{
    [SerializeField] float Speed = 100;

    void Movement2()
    {
        float horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        Vector3 position = new Vector3(horizontal, 0, vertical);
        transform.Translate(position);
    }
    void Update()
    {
        Movement2();
    }
}
