using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailController : MonoBehaviour
{
    public Transform target;
    
    private float distance;
    private Vector3 direction;
    private float targetDistance = 0.6f;

    private void Update()
    {
        LookDirection();
    }

    private void LookDirection()
    {
        direction = target.position - transform.position;
        distance = direction.magnitude;
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
            MoveTail();
    }

    private void MoveTail()
    {
        if (distance > targetDistance)
        {
            transform.Translate(direction.normalized * (distance - targetDistance));
        }
    }
}
