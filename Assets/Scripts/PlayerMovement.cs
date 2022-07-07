using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float mouvementSpeed = 10f;
    public float rotationSpeed = 300f;


    void Start()
    {

    }

    private void Update()
    {
        Vector2 position = transform.position;

        // Point toward the cursor
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, target - position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        // Move to requested direction
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        float goalX = position.x + horizontalMovement * Time.deltaTime * mouvementSpeed;
        float goalY = position.y + verticalMovement * Time.deltaTime * mouvementSpeed;

        transform.position = new Vector3(goalX, goalY, 0);
    }

}
