using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Velocity")]
    public float xVelocity = 5;
    public float yVelocity = 6;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdatePlayerPosition();
    }

    public void UpdatePlayerPosition()
    {
        
        rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);

        //if (Input.touchCount > 0)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, yVelocity);
        }
    }
}
