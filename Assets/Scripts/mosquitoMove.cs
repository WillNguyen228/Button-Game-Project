using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.Rendering;


public class mosquitoMove : MonoBehaviour
{
    private Rigidbody2D rb2d; // Reference to the Rigidbody2D component
    float rand_direction2;
    float rand_direction1;
    bool once = true;
    public float repulsionRadius = 10f;
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

        // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Vector3 directionToMouse = (mousePos - transform.position).normalized;
        // float distance = Vector3.Distance(transform.position, mousePos);
        // // Debug.Log("Hit:" + bounce.transform.name);
        // if (distance < repulsionRadius)
        // {
        //     // Move the object in the opposite direction
        //     transform.Translate(-directionToMouse * 3f * Time.deltaTime);
        //     // rand_direction1 = -directionToMouse[0];
        //     // rand_direction2 = -directionToMouse[1];
        // }

        Vector3 moveDirection = new Vector3(rand_direction1, rand_direction2).normalized; // Example direction
        rb2d.linearVelocity = moveDirection * 10f; // Set the velocity of the Rigidbody2D

    }

    private void OnCollisionEnter2D(Collision2D bounce)
    {
        if (bounce.gameObject.tag == "CollideLeft"){
            Debug.Log("Hit:" + bounce.transform.name);
            rand_direction1 = UnityEngine.Random.Range(0f, 1f);
            rand_direction2 = UnityEngine.Random.Range(-1f, 1f);
        }
        else if (bounce.gameObject.tag == "CollideRight"){
            Debug.Log("Hit:" + bounce.transform.name);
            rand_direction1 = UnityEngine.Random.Range(-1f, 0f);
            rand_direction2 = UnityEngine.Random.Range(-1f, 1f);
        }
        else if (bounce.gameObject.tag == "CollideRoof"){
            Debug.Log("Hit:" + bounce.transform.name);
            rand_direction1 = UnityEngine.Random.Range(-1f, 1f);
            rand_direction2 = UnityEngine.Random.Range(-1f, 0f);
        }
        else if (bounce.gameObject.tag == "CollideFloor"){
            Debug.Log("Hit:" + bounce.transform.name);
            rand_direction1 = UnityEngine.Random.Range(-1f, 1f);
            rand_direction2 = UnityEngine.Random.Range(0f, 1f);
        }
    }
}
