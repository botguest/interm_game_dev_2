using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrScoreWall : MonoBehaviour
{
    public float forceMagnitude = 10f; // Adjust the force magnitude as needed
    public float torqueAmount = 500f; // Adjust the torque amount as needed
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            /*
            Rigidbody2D ballRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            
            if (ballRigidbody != null)
            {
                // Calculate the reflection direction
                Vector2 reflectionDirection = Vector2.Reflect(other.relativeVelocity, other.contacts[0].normal).normalized;

                // Apply a force in the reflection direction
                ballRigidbody.AddForce(reflectionDirection * forceMagnitude, ForceMode2D.Impulse);

                // Apply torque to spin the ball
                ballRigidbody.AddTorque(torqueAmount, ForceMode2D.Impulse);
            }
            */
            
            Destroy(gameObject);
        }
    }
}
