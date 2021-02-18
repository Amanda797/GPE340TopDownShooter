using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // made pawnmover private
    private PawnMover pawnMover;
    void Start()
    {
        // getting component pawnmover
        pawnMover = GetComponent<PawnMover>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // creating vector 3 to make position
        Vector3 newPosition = Vector3.zero;

        // getting keycode W to press W
        if (Input.GetKey(KeyCode.W))
        {
            // transform world forward into local space
            // using InverseTransformDirection to move player forward
            newPosition = transform.InverseTransformDirection(Vector3.forward);
        }

        // if player presses S, with GetKey and KeyCode S
        if (Input.GetKey(KeyCode.S))
        {
            // transform world forward into local space
            // Then use transform InverseTransformDirection to move backwards by using a negative Vector3
            newPosition = transform.InverseTransformDirection(-Vector3.forward);
        }

        
        // if player presses D, with Getkey and Keycode D
        if (Input.GetKey(KeyCode.D))
        {
            // transform world forward into local space
            // Then use transform InverseTransformDirection to move player to the right
            newPosition = transform.InverseTransformDirection(Vector3.right);
        }

        // if player presses A, with Getkey and keycode A
        if (Input.GetKey(KeyCode.A))
        {
            // transform world forward into local space
            // Then use transform InverseTransformDirection to move player to the left
            newPosition = transform.InverseTransformDirection(Vector3.left);
        }

        // if player presses space bar using input getkey and keycode space for space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Then player will jump
            pawnMover.Jump();
        }

        // Needed to Rotate mouse position to let player rotate character
        pawnMover.RotateToMousePosition();
        pawnMover.Move(newPosition.x, newPosition.z);
    }
}
