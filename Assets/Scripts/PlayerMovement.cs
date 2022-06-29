using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Collider2D characterCollider;
    private Collider2D shieldCollider;

    public float mouvementSpeed = 10f;

    void Start()
    {
        for(int i=0; i<transform.childCount; ++i)
        {
            Transform child = transform.GetChild(i);
            switch(child.name)
            {
                case "Character":
                    characterCollider = child.GetComponent<Collider2D>();
                    break;
                case "Shield":
                    shieldCollider = child.GetComponent<Collider2D>();
                    break;
            }
        }
    }

    void Update()
    {
        //HandleCollision();

        Vector3 position = transform.position;

        // Point toward the cursor
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0;
        Debug.Log(target - position);
        transform.LookAt(target - position);
        

        // Move to requested direction
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        float goalX = position.x + horizontalMovement * Time.deltaTime * mouvementSpeed;
        float goalY = position.y + verticalMovement * Time.deltaTime * mouvementSpeed;

        transform.position = new Vector3(goalX, goalY, 0);
    }

}
