using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private Animator animator;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("xMove", horizontal);
        animator.SetFloat("yMove", vertical);
        
        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();
        
        //_rb.velocity = movement * speed;
        _rb.MovePosition(_rb.position + movement * speed * Time.fixedDeltaTime);
        
    }
}
