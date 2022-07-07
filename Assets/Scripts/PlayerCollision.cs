using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Collidable characterCollidable;
    Collidable shieldCollidable;

    void Start()
    {
        for(int i=0; i<transform.childCount; ++i)
        {
            Transform child = transform.GetChild(i);
            if(child.name == "Character")
            {
                characterCollidable = child.GetComponent<Collidable>();
            }
            else
            {
                if (child.name == "Shield")
                {
                    shieldCollidable = child.GetComponent<Collidable>();
                }
            }
        }

        if(characterCollidable != null)
        {
            characterCollidable.Collided.AddListener(ManageCharacterCollision);
        }

        if(shieldCollidable != null)
        {
            shieldCollidable.Collided.AddListener(ManageShieldCollision);
        }
    }

    
    public void ManageCharacterCollision(GameObject other, Vector2 collisionPoint)
    {
        Debug.Log("character touched !");
    }

    public void ManageShieldCollision(GameObject other, Vector2 collisionPoint)
    {
        Debug.Log("shield touched !");
    }
}
