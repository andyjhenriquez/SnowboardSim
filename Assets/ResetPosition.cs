using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class ResetPosition : MonoBehaviour
{
    public Transform resetTransform;
    public GameObject player;
    public Camera playerHead;

    public InputActionReference resetCameraRight;
    public InputActionReference resetCameraLeft;

    private void Update()
    {
        if (resetCameraRight.action.triggered || resetCameraLeft.action.triggered) 
        {
            ResetPos();
        }
    }

    public void ResetPos()
    {
        player.GetComponent<XROrigin>().MoveCameraToWorldLocation(resetTransform.position);
        player.GetComponent<XROrigin>().MatchOriginUpCameraForward(resetTransform.up, resetTransform.forward);
    }
}
