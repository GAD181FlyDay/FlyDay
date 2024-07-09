using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{

    public bool hasRotated;
    [SerializeField] Rigidbody playerRb;
    void Start()
    {
        StartCoroutine(RotationLoop());
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (hasRotated && horizontal > 0 || hasRotated && horizontal < 0 || hasRotated && vertical > 0 || hasRotated && vertical < 0 )
        {
            Debug.Log("You Lose");
        }
        Debug.Log(horizontal + " " + vertical);
    }

    IEnumerator RotationLoop ()
    {
        while (true)
        {
            float randomTime = Random.Range(1.0f, 10.0f);
            
            yield return new WaitForSeconds(randomTime);
            float randomChance = Random.Range(1.0f, 10.0f);
            
            if (randomChance > 5) 
            {
                hasRotated = true;
                RotateEnemy(180);
            }
            yield return new WaitForSeconds(5);
            RotateEnemy(-180);
            hasRotated = false;
        }
    }

    void RotateEnemy (float rotationAmount)
    {
        transform.Rotate(0, rotationAmount, 0);
    }
}
