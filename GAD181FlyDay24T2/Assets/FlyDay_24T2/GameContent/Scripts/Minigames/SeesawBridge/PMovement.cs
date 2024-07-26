using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal")* speed*Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 position = new Vector3 (horizontal, 0 , vertical); 
        transform.Translate (position); 
    }
    void Update () 
    {
        Movement(); 
    }
}
