using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int power;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;

        if (go.tag == "Player")
        {
            go.GetComponent<Player>().TakeDamage(power);
            go.GetComponent<Player>().Jump(1);
        }

    }
}
