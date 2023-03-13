using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int power;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Damage(player);
        }

    }

    public virtual void Damage(Player player)
    {
        player.TakeDamage(power);
    }
}
