using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbody;

    // forças de movimento
    private float movementX;
    private float movementY;
    public float movementSpeed = 10f;
    public float jumpForce = 6f;
    public float jumpCooldown = 2f;
    private float nextJumpTime;

    public bool grounded;    
    public int placar = 0;  // placar do jogador

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();  // Get the rigidbody component    
        nextJumpTime = Time.time;           
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded();     
        if (grounded == true)
        {
            Vector3 movimento = new Vector3(movementX, 0.0f, movementY);        
            rbody.AddForce(movimento*movementSpeed);
        }          
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();       

        movementX = input.x;
        movementY = input.y;        
    }

    void OnJump(InputValue value)
    {
        IsGrounded();
        // if (value.isPressed && Time.time >= nextJumpTime)
        if (value.isPressed && grounded == true)
        {            
            rbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
            // nextJumpTime = Time.time + jumpCooldown;
        }
    }

    void IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            grounded = true;
        }
        else {
            grounded = false;
        }
    }
}
