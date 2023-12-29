using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UIElements;

public class OrientTracker : MonoBehaviour
{
    public Transform tracker;
    public Transform trackerParent;

    private void Update()
    {
        if (tracker.rotation != new Quaternion (0f, 0f, 0f, 1f))
        {
            trackerParent.rotation = Quaternion.Inverse(tracker.rotation);
            Destroy(this.gameObject.GetComponent<OrientTracker>());
        }
    }
}
