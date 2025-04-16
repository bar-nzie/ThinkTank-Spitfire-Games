using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] GameplaySubcription PlaneControls;
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
        _PlaneControl = new Vector2(PlaneControls.MoveInput.x, 0);
        rb.velocity = new Vector2(_PlaneControl.x, _PlaneControl.y) * moveSpeed;

        //Clamp to stop movement out of bounds
        Vector3 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -45f, 45f);
        rb.position = clampedPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float steerInput = PlaneControls.MoveInput.x;

        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(-tiltAroundZ, -90, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
