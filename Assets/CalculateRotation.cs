using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CalculateRotation : MonoBehaviour
{
    private float previousRotationZ;
    public float changeInRotationZ;

    // Update is called once per frame
    void Update()
    {
        // On first frame, orient snowboard accordingly
        if (this.transform.rotation != new Quaternion(0, 0, 0, 1))
        {
            if (previousRotationZ - this.transform.rotation.z > -0.2f && previousRotationZ - this.transform.rotation.z < 0.2f)
            {
                //if (this.transform.eulerAngles.z <= 180f)
                    changeInRotationZ = -(previousRotationZ - this.transform.rotation.z);
                //else
                //    changeInRotationZ = previousRotationZ - this.transform.eulerAngles.z - 360f;
            }
            else
                changeInRotationZ = 0f;

            //Debug.Log("CHANGE IN ROT: " + changeInRotationZ);
            //if (this.transform.eulerAngles.z <= 180f)
                previousRotationZ = this.transform.rotation.z;
            //else
            //    previousRotationZ = this.transform.eulerAngles.z - 360f;
        }
    }
}
