using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Config")]
    [SerializeField] private float speed;

    public Vector2 MoveDirection => moveDirection;

    private PlayerAnimations playerAnimations;
    private PlayerActions actions;
    private Player player;
    private Rigidbody2D rb2D;
    private Vector2 moveDirection;

    private void Awake()
    {
        player = GetComponent<Player>();
        playerAnimations = GetComponent<PlayerAnimations>();
        actions = new PlayerActions();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (player.Stats.Health <= 0) return;
        
        rb2D.MovePosition(rb2D.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (moveDirection == Vector2.zero)
        {
            playerAnimations.SetMoveBoolTransition(false);
            return;
        }
        playerAnimations.SetMoveBoolTransition(true);
        playerAnimations.SetMoveAnimation(moveDirection);
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
