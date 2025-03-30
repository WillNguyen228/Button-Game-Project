using System;
using UnityEngine;
using UnityEngine.InputSystem.Composites;


public class mosquitoMove : MonoBehaviour
{
    private Rigidbody2D rb2d; // Reference to the Rigidbody2D component
    float rand_direction2;
    float rand_direction1;
    bool once = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the GameObject
        
    }

    // Update is called once per frame
    void Update()
    {
        // float horizontalInput = Input.GetAxis("Horizontal"); // Returns -1, 0, or 1
        // float verticalInput = Input.GetAxis("Vertical"); // Returns -1, 0, or 1
        // float moveSpeed = 5f; // Speed of the mosquito movement

        // // Calculate movement direction
        // Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f); // Only move on the X-axis for 2D

        // // Apply movement to the sprite's position
        // transform.position += movement * moveSpeed * Time.deltaTime;
    }


    void FixedUpdate()
    {
        if (once == true)
        {
            // Randomly generate a direction for the mosquito to move in
            rand_direction1 = UnityEngine.Random.Range(-1f, 1f);
            rand_direction2 = UnityEngine.Random.Range(-1f, 1f);
            once = false;
        }
        Vector3 moveDirection = new Vector3(rand_direction1, rand_direction2).normalized; // Example direction
        rb2d.linearVelocity = moveDirection * 10f; // Set the velocity of the Rigidbody2D

    }

    private void OnCollisionEnter2D(Collision2D bounce)
    {
        if (bounce.gameObject.tag == "Colide"){
            Debug.Log("Hit:" + bounce.transform.name);
            rand_direction1 = UnityEngine.Random.Range(-1f, 1f);
            rand_direction2 = UnityEngine.Random.Range(-1f, 1f);
        }
    }
}
