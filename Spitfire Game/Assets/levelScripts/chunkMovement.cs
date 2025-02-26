using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chunkMovement : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0, 1, -20);
    public float levelMoveSpeed = 2.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, levelMoveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
