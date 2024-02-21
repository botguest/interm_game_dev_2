using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFlipper : MonoBehaviour
{
    public float flipStrength = 700f;
    public float moveSpeed = 5f;
    public float maxFlipAngle = 45f; // Maximum rotation angle from the original rotation
    public float flipDirection = 1f; // Use 1 for one direction, -1 for the opposite direction

    public bool left = false; //If it's the left flipper
    public float leftMost = -6;
    public float rightMost = 6;
    public float flipInterval = 5;

    public KeyCode flipKey = KeyCode.Space;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    

    private Rigidbody2D rb;
    private float startPositionX;
    private float originalRotation;
    private bool isFlipping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPositionX = rb.position.x;
        originalRotation = rb.rotation;
    }

    void Update()
    {
        HandleFlipping();
        HandleMovement();
    }

    void HandleFlipping()
    {
        if (Input.GetKeyDown(flipKey) && !isFlipping)
        {
            isFlipping = true;
        }
        else if (Input.GetKeyUp(flipKey))
        {
            isFlipping = false;
        }

        if (isFlipping)
        {
            // Adjust targetRotation calculation to consider flipDirection
            float rotationAmount = flipStrength * Time.fixedDeltaTime * flipDirection;
            float targetRotation = rb.rotation + rotationAmount;
            if (flipDirection > 0)
            {
                targetRotation = Mathf.Min(targetRotation, originalRotation + maxFlipAngle);
            }
            else
            {
                targetRotation = Mathf.Max(targetRotation, originalRotation - maxFlipAngle);
            }
            rb.MoveRotation(targetRotation);
        }
        else
        {
            // Smoothly interpolate back towards the original rotation
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, originalRotation, 80f * Time.deltaTime));
        }
    }

    void HandleMovement()
    {
        float move = 0f;
        if (Input.GetKey(moveLeftKey))
        {
            if (left == false && gameObject.transform.localPosition.x >= leftMost + flipInterval) 
            {
                move = -moveSpeed * Time.fixedDeltaTime;
            }

            else if (left == true && gameObject.transform.localPosition.x >= leftMost)
            {
                move = -moveSpeed * Time.fixedDeltaTime;
            }
            
        }
        else if (Input.GetKey(moveRightKey))
        {
            if (left == false && gameObject.transform.localPosition.x <= rightMost)
            {
                move = moveSpeed * Time.fixedDeltaTime;
            }

            else if (left == true && gameObject.transform.localPosition.x <= rightMost - flipInterval)
            {
                move = moveSpeed * Time.fixedDeltaTime;
            }
        }

        if (move != 0f)
        {
            Vector2 newPosition = rb.position + new Vector2(move, 0);
            rb.MovePosition(newPosition);
        }
    }
}
