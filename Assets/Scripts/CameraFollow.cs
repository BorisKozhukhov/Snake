using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        FollowSnake();
    }

    private void FollowSnake()
    {
        Vector3 pos = transform.position;
        pos.z = target.position.z - 11.5f;
        transform.position = pos;
    }
}
