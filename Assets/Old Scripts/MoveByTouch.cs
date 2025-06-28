using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public CharacterController controller; 
    public Joystick Joystick; 
    public float runSpeed = 40f; 
    float horizontalMove = 0f; 
    float verticalMove = 0f; 
    void Update() 
    { 
        // Get the horizontal and vertical input from the joystick
        horizontalMove = Joystick.Horizontal * runSpeed; 
        verticalMove = Joystick.Vertical * runSpeed; 
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 
        //animator.SetFloat("Speed", Mathf.Abs(verticalMove)); 
        // Create a Vector3 to store the movement direction
        Vector3 move = new Vector3(horizontalMove,verticalMove, 0f); 
        // Move the character controller
        controller.Move(move * Time.deltaTime); 
    }
}
