using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // set it to a target. Public so other scripts can see
    public Transform target;

    // make a Vector 3
    private Vector3 offset;

    // make a float to contain speed
    // It is public so you can change the speed in the inspector
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // sets up camera to follow player by finding player position and subtracting offset
        transform.position = Vector3.MoveTowards(transform.position, target.position - offset, Speed * Time.deltaTime);
    }
}
