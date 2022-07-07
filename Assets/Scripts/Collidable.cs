using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collidable : MonoBehaviour
{
    public UnityEvent<GameObject, Vector2> Collided;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessCollision(collision.gameObject, collision.ClosestPoint(transform.position));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProcessCollision(collision.gameObject, collision.GetContact(0).point);
    }

    private void ProcessCollision(GameObject other, Vector2 collisionPoint)
    {
        Collided.Invoke(other, collisionPoint);
    }
}
