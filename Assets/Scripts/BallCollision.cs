using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    Collidable ballCollidable;
    public GameObject bounceEffect;

    // Start is called before the first frame update
    void Start()
    {
        ballCollidable = GetComponent<Collidable>();
        if(ballCollidable != null)
        {
            ballCollidable.Collided.AddListener(ManageBallCollision);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ManageBallCollision(GameObject other, Vector2 collisionPoint)
    {
        if(other.CompareTag("Bouncy"))
        {
            BallMovement movementComponent = transform.GetComponent<BallMovement>();
            if(movementComponent != null)
            {
                if (bounceEffect != null)
                {
                    Vector2 movementDirection = movementComponent.GetMovementDirection();
                    Quaternion emissionDirection = Quaternion.LookRotation(movementDirection, Vector3.forward);
                    GameObject instantiated = Instantiate(bounceEffect, collisionPoint, emissionDirection);
                    ParticleSystem ps = instantiated.GetComponent<ParticleSystem>();
                    ps.startSpeed = movementComponent.Speed;
                }
                movementComponent.ReflectDirection(other.transform.up);
            }
        }
    }

}
