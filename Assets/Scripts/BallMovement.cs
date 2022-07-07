using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Vector2 initialDirection;

    public float Speed { get; set; } = 1f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = initialDirection * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReflectDirection(Vector2 normal)
    {
        Speed *= 1.1f;
        Debug.Log(rb.velocity);
        rb.velocity = Vector3.Reflect(rb.velocity, normal).normalized * Speed;
    }


    public Vector2 GetMovementDirection()
    {
        return rb.velocity.normalized;
    }
}
