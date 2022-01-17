using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 2.0f;
    public float GroundLevel;
    public Vector2 movementVector;
    //private const float gravity = -9.8f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        /*if(grounded == false)
        {
            movementVector.y += gravity * Time.deltaTime;
        }*/

        

        if (yPos < GroundLevel)
        {
            //newY = GroundLevel;
            //movementVector.y = 0.0f;
            grounded = true;
        }
        float newY = yPos;
        transform.position = new Vector3
            (xPos + movementVector.x * MovementSpeed 
            * Time.deltaTime, newY);
        
    }

    public void OnMove(InputValue input)
    {
        movementVector.x = input.Get<Vector2>().x;
    }

    public float JumpSpeed = 6.0f;
    public bool grounded = true;
    public void OnJump(InputValue input)
    {
        if(input.isPressed && grounded)
        {
            //movementVector.y = JumpSpeed;
            rb.AddForce(new Vector2(0.0f, JumpSpeed), ForceMode2D.Impulse);
            grounded = false;
        }
    }
}
