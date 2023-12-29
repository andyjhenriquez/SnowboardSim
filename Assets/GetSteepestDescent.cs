using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSteepestDescent : MonoBehaviour
{
    public Transform snowboard;
    public LayerMask layerMask;

    private Vector3 terrainNormal;

    public Vector3 steepestDescent;

    void Update()
    {
        // Calculate steepest descent
        steepestDescent = CalculateSteepestDescent(snowboard.position);


        // Draw the result (you can use it as needed)
        // Debug.DrawRay(this.transform.position, steepestDescent, Color.green);
    }

    Vector3 CalculateSteepestDescent(Vector3 currentPos)
    {
        RaycastHit hit;
        if (Physics.Raycast(currentPos, -snowboard.up, out hit, Mathf.Infinity, layerMask))
        {
            // Debug.Log("HITTING COLLIDER: " + hit.collider);
            return hit.normal;
        }
        else
            return snowboard.up;
    }
}
