using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController1 : MonoBehaviour
{
    public float acceleration = 15f;
    public float steering = 5f;
    public float maxSpeed = 20f;
    public float driftFactor = 0.95f;
    public float weight = 1f;

    private Rigidbody rb;
    private float moveInput;
    private float steerInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get player input
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // Apply weight to the car
        Vector3 forwardVelocity = transform.forward * Vector3.Dot(rb.velocity, transform.forward);
        Vector3 rightVelocity = transform.right * Vector3.Dot(rb.velocity, transform.right);

        rb.velocity = forwardVelocity + rightVelocity * driftFactor;

        // Move the car forward or backward
        rb.AddForce(transform.forward * moveInput * acceleration * weight);

        // Limit the speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Rotate the car
        float direction = Vector3.Dot(rb.velocity, transform.forward);
        if (direction >= 0.0f)
        {
            rb.angularVelocity = new Vector3(0f, steerInput * steering * (rb.velocity.magnitude / maxSpeed), 0f);
        }
        else
        {
            rb.angularVelocity = new Vector3(0f, -steerInput * steering * (rb.velocity.magnitude / maxSpeed), 0f);
        }
    }
}
