using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public CharacterController controller;
    public Joystick Joystick;
    public float runSpeed;
    public Button KickButton;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    public float KickVelocity = 0f;
    public float NormalizedValue;
    private bool facingRight = true;
    public Vector3 Angle;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        
        horizontalMove = Joystick.Horizontal * runSpeed;
        verticalMove = Joystick.Vertical * runSpeed;

        float horizontalInput = Input.GetAxis("Horizontal") * runSpeed;
        float verticalInput = Input.GetAxis("Vertical") * runSpeed;

        //Vector3 moveDirection = new Vector3(horizontalMove + horizontalInput, verticalMove + verticalInput, 0f);
        Vector3 moveDirection = new Vector3(horizontalInput != 0 ? horizontalInput : horizontalMove, verticalInput != 0 ? verticalInput : verticalMove, 0f);
        Angle = moveDirection;

        if (moveDirection.magnitude > NormalizedValue)
        {
            moveDirection.Normalize();
        }

        
        controller.Move(moveDirection * Time.deltaTime);
        
        if (moveDirection.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveDirection.x < 0 && facingRight)
        {
            Flip();
        }

    }
    public bool IsFacingRight() 
    { 
        return facingRight; 
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}