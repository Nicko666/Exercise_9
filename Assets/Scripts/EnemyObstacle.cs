using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObstacle : Enemy
{
    public Rigidbody2D rb;
    public Vector2 force;
    public float rotation;

    private void Start()
    {
        rb.AddForce(force);   
        rb.angularVelocity = rotation;
    }

}
