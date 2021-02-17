using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMover : MonoBehaviour
{
    //Animator can be private
    private Animator animator;
    public Transform target;
    // make public moveSpeed to change speed in inspector
    public float moveSpeed;
    public LayerMask groundLayer;
    private Rigidbody rigidbodyPlayer;
    
    // components for jumping
    public float jumpForce;
    public bool isOnGround;
    public bool isJumping;

    public void Start()
    {
        // Getting the animator and the rigidbody on start to be able to move player
        animator = GetComponent<Animator>();
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        isOnGround = IsOnGround();

        
    }

    // setting up move horizontal and vertical
    public void Move(float horizontal, float vertical)
    {
        animator.SetFloat("Horizontal", moveSpeed * horizontal);
        animator.SetFloat("Vertical", moveSpeed * vertical);
    }

    public void RotateToMousePosition()
    {
        // making plane to set to plane
        Plane plane = new Plane(Vector3.up, target.position);
        float distance;

        // raycast to set camera to mouse
        // can move mouse to rotate the player
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // creating ray to the plane
        if (plane.Raycast(ray, out distance))
        {
            // if we hit it
            Vector3 intersection = ray.GetPoint(distance);
            // rotate to look when move mouse
            target.LookAt(intersection);
        }

    }

    public void Jump()
    {
       if(isOnGround == true)
        {
           
            rigidbodyPlayer.AddRelativeForce(Vector3.up * jumpForce);
            
            return;
        }


    }



    private bool IsOnGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, .3f, groundLayer))
        {
            // raycast down to ground to see if on ground
            return true;
        }

        // if not raycasting to ground, return false
        return false;
    }


}
