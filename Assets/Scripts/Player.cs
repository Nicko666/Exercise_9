using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static event Action<Player> PlayerIsCreated;
    public static event Action PlayerIsDead;
    public static event Action<int> PlayerIsDamaged;
    public static event Action<GameObject> PlayerWin;

    public int health;

    private float moveSpeed = 6.0f;
    private float jumpPower = 8.0f;

    public bool isGrounded;

    [SerializeField] private Rigidbody2D rb;
    private Controls controls;
    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        controls = new();

        controls.Enable();

        //controls.Player.Jump.performed += Jump;

        PlayerIsCreated(this);
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        GroundedCheck();
        EnemyCheck();
        Move(controls.Player.Move.ReadValue<float>());
        // action with space continiously pressed
        Jump(controls.Player.Jump.ReadValue<float>());
    }


    private void Move(float value)
    {
        rb.velocity = new Vector2(value * moveSpeed, rb.velocity.y);
    }

    public void Jump(float value)
    {
        if (isGrounded && value > 0.5)
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        Jump(1);
    }

    public void GroundedCheck()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y / 2 + 0.1f, LayerMask.GetMask("Default"));

        if (hitGround)
        {
            isGrounded = true;
            Debug.Log(hitGround.collider.gameObject.name);
        }  
    }

    public void EnemyCheck()
    {
        RaycastHit2D hitGround = Physics2D.CircleCast(transform.position, transform.localScale.y / 2 - 0.1f, Vector3.down, 0.2f, LayerMask.GetMask("Enemy"));

        if (hitGround)
        {
            isGrounded = true;
            Destroy(hitGround.collider.gameObject);
            Jump(1);
        }

    }

    public void TakeDamage(int value)
    {
        animator.SetTrigger("Damage");
        health -= value;
                
        if(health <= 0)
        {
            Die();
        }

        PlayerIsDamaged(value);
    }

    public void Win()
    {
        PlayerWin(this.gameObject);
        controls.Disable();
    }

    public void Die()
    {
        PlayerIsDead();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fin")
        {
            Win();
        }
    }


}
