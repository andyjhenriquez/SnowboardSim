using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float input;

    public float rotateYawSpeed;
    public float rotateRollSpeed;

    public GameObject tracker;

    private float rollAngle;
    // Update is called once per frame
    void Update()
    {
        // Get input from player (will be changed to VR board)
        input = Input.GetAxis("Horizontal");

        // Clamp roll angle
        rollAngle = -(input * rotateRollSpeed * Time.deltaTime);
        rollAngle = Mathf.Clamp(rollAngle, 0f, 45f);

        // Ensure board rotates accordingly
        // transform.Rotate(0f, input * rotateYawSpeed * Time.deltaTime, 0f, Space.World);
        transform.Rotate(0f, tracker.GetComponent<CalculateRotation>().changeInRotationZ * rotateYawSpeed * Time.deltaTime, 0f, Space.World);
        // transform.Rotate(0f, 0f, rollAngle, Space.Self);
    }
}
