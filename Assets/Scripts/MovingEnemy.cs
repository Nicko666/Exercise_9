using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MovingEnemy : Enemy
{
    [SerializeField] [Range(-1, 1)] private int direction;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private float horizontalBorder;

    private void Start()
    {
        horizontalBorder = transform.localScale.x / 2;
    }

    private void Update()
    {
        Move();
        BorderCheck();
    }

    private void Move()
    {
        rb.velocity = Vector2.right * direction * speed;
    }

    public void BorderCheck()
    {
        RaycastHit2D hitBorder = Physics2D.Raycast(transform.position, Vector2.right * direction, horizontalBorder + 0.1f, LayerMask.GetMask("Default"));
        if (hitBorder)
        {
            direction *= -1;
        }
    }
}
