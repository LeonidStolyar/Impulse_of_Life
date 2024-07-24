using System.Collections;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private float moveSpeed;
    private PlayerControls playerControls;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;
    protected override void Awake()
    {
        base.Awake();

        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update() {
        PlayerInput();
        
    }
    private void FixedUpdate()
    {
        Move();
        
    }
    private void OnEnable() {
        playerControls.Enable();
        
    }
    private void OnDisable() {
        playerControls.Disable();
    }
    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        movement.Normalize();

        animator.SetFloat("xMove", movement.x);
        animator.SetFloat("yMove", movement.y);
        
    }
    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
}
