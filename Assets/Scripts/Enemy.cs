using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int power;

    public float weaknessY;

    private void Start()
    {
        weaknessY = transform.localScale.y * 0.4f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if((player.transform.position.y - weaknessY) < transform.position.y)
            {
                player.TakeDamage(power);
            }
        }

    }
}
