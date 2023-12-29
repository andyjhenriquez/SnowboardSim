using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SnowboardPhysics : MonoBehaviour
{
    private float surfaceAngle;
    private float angle;
    private bool uphill;
    private bool flatSurface;

    public float speed;
    public float brakingAmount;

    public Rigidbody rb;

    private Vector3 steepestDescent;

    // Update is called once per frame
    void Update()
    {
        // Get surface angle and other data from SurfaceAngle script
        surfaceAngle = this.GetComponent<SurfaceAngle>().surfaceAngle;
        uphill = this.GetComponent<SurfaceAngle>().uphill;
        flatSurface = this.GetComponent<SurfaceAngle>().flatSurface;

        angle = Vector3.Angle(transform.forward, Vector3.forward);
        // Debug.Log(angle);

        // Debug.DrawRay(this.transform.position, transform.forward * transform.forward.z, Color.red);
        steepestDescent = this.GetComponent<GetSteepestDescent>().steepestDescent;

        // Apply speed using surface angle
        if (!uphill)   // Downhill
        {
            // Debug.DrawRay(this.transform.position, transform.forward, Color.red);
            rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Acceleration);
        }
        else if (uphill)   // Uphill
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Acceleration);
        }
        else    // Flat surface
        {
            rb.AddForce(transform.forward * 0.1f * Time.deltaTime, ForceMode.Acceleration);
        }

        // Debug.Log(rb.velocity);
    }
}
