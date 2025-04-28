using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class AttractionMovement : MonoBehaviour
{
    [SerializeField] MenuSubcription MenuControls;
    Rigidbody rb;

    public float smooth = 5.0f;
    public float tiltAngle = 60.0f;
    public float moveSpeed = 10f;

    Vector2 _PlaneControl;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Physics stuff always in FixedUpdate plz
    private void FixedUpdate()
    {
        _PlaneControl = new Vector2(Mathf.Cos(Time.fixedTime) * 5, 0);
        //_PlaneControl = new Vector2(PlaneControls.MoveInput.x, 0);
        rb.velocity = new Vector2(_PlaneControl.x, _PlaneControl.y) * moveSpeed;

        //Clamp to stop movement out of bounds
        Vector3 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -25f, 25f);
        rb.position = clampedPosition;

        //float steerInput = rb.velocity.x / (5f * moveSpeed);

        //float tiltAroundZ = steerInput * tiltAngle;

        //Quaternion target = Quaternion.Euler(-tiltAroundZ, -90, 0);

        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        //transform.rotation = target;
    }

    // Update is called once per frame
    void Update()
    {
        //float steerInput = MenuControls.MoveInput.x;

        float horizontalVelocity = rb.velocity.x;

        // Deadzone to prevent tilt when movement is negligible
        if (Mathf.Abs(horizontalVelocity) < 0.1f)
        {
            horizontalVelocity = 0f;
        }

        float steerInput = horizontalVelocity / (5f * moveSpeed);
        steerInput = Mathf.Clamp(steerInput, -1f, 1f);

        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = steerInput * tiltAngle;
        
        //Sean: I commented this out and changed it with the code above, using Input.GetAxis is a different input
        //system to the input map I made and to keep all inputs consistant I changed "tiltAroundZ" to use the "steerInput" 
        //variable that uses the axis from the input map's controls.
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        
        // Sean: this was commented out before don't think it's useful but I left it
        //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(-tiltAroundZ, -90, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }

}
