using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] GameplaySubcription PlaneControls;

    private Rigidbody rb;
    private NarrationScript narrationScript;
    private ScrollingText scrollingText;

    public float smooth = 5.0f;
    public float tiltAngle = 60.0f;
    public float moveSpeed = 10f;

    private bool hasMovedOnce = false;

    Vector2 _PlaneControl;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        narrationScript = FindObjectOfType<NarrationScript>();
        scrollingText = FindObjectOfType<ScrollingText>();
    }

    //Physics stuff always in FixedUpdate plz
    //Might have to make this enumerator
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

        if (narrationScript.waitForPlayerActionFlying == true && !hasMovedOnce && Mathf.Abs(steerInput) > 0.1f)
        {
            hasMovedOnce = true;
            narrationScript.PlayerCompletedActionFlying();
            scrollingText.PlayerCompletedActionFlying();
        }

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
