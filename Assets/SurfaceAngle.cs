using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SurfaceAngle : MonoBehaviour
{
    public Transform rearRayPos;
    public Transform frontRayPos;
    public LayerMask layerMask;

    public float surfaceAngle;
    public bool uphill;
    public bool flatSurface;

    // Update is called once per frame
    void Update()
    {
        // May need to change z to -gameObject.transform.rotation.z instead of 0
        rearRayPos.rotation = Quaternion.Euler(-gameObject.transform.rotation.x, 0, 0);
        frontRayPos.rotation = Quaternion.Euler(-gameObject.transform.rotation.x, 0, 0);

        RaycastHit rearHit;
        if (Physics.Raycast(rearRayPos.position, rearRayPos.TransformDirection(-Vector3.up), out rearHit, Mathf.Infinity, layerMask))
        {
            // Debug.DrawRay(rearRayPos.position, rearRayPos.TransformDirection(-Vector3.up) * rearHit.distance, Color.yellow);
            surfaceAngle = Vector3.Angle(rearHit.normal, Vector3.up);
        }
        else
        {
            // Debug.DrawRay(rearRayPos.position, rearRayPos.TransformDirection(-Vector3.up) * 1000, Color.red);
            uphill = false;
        }

        RaycastHit frontHit;
        Vector3 frontRayStartPos = new Vector3(frontRayPos.position.x, rearRayPos.position.y, frontRayPos.position.z);
        if (Physics.Raycast(frontRayStartPos, frontRayPos.TransformDirection(-Vector3.up), out frontHit, Mathf.Infinity, layerMask))
        {
            // Debug.DrawRay(frontRayStartPos, frontRayPos.TransformDirection(-Vector3.up) * frontHit.distance, Color.yellow);
        }
        else
        {
            uphill = true;
        }

        if (frontHit.distance < rearHit.distance)
        {
            uphill = true;
            flatSurface = false;
        }
        else if (frontHit.distance > rearHit.distance)
        {
            uphill = false;
            flatSurface = false;
        }
        else if (frontHit.distance == rearHit.distance)
        {
            flatSurface = true;
            Debug.LogWarning("Flat surface");
        }
    }
}
