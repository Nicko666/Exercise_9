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

    public float weaknessY;

    private void Start()
    {
        weaknessY = transform.localScale.y * 0.4f;
        horizontalBorder = transform.localScale.x / 2;
    }

    private void Update()
    {
        BorderCheck();
        Move();
    }

    private void Move()
    {
        rb.velocity = Vector2.right * direction * speed;
    }

    public void BorderCheck()
    {
        //old script
        //RaycastHit2D hitBorder = Physics2D.Raycast(transform.position, Vector2.right * direction, horizontalBorder + 0.1f, LayerMask.GetMask("Default"));
        if (rb.velocity == Vector2.zero)//hitBorder)
        {
            direction *= -1;
        }
    }

    public override void Damage(Player player)
    {
        if ((player.transform.position.y - weaknessY) < transform.position.y)
        {
            player.TakeDamage(power);
        }
    }
}
