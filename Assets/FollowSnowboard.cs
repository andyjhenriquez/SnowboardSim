using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSnowboard : MonoBehaviour
{
    public GameObject snowboard;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = snowboard.transform.position + offset;
    }
}
