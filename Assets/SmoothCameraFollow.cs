using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    //[SerializeField] private Vector3 offset;
    [SerializeField] private float damping;
    [SerializeField] private Transform target;
    
    private Vector2 vel = Vector2.zero;

    
    void FixedUpdate()
    {
        Vector2 targetPosition = target.position;

        transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref vel, damping);
    }
}
