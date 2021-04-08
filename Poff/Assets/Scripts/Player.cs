using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Velocity")]
    public float xVelocity = 5;
    public float yVelocity = 6;
    private bool grounded = true;
    private bool dblJump = true;

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
            Jump();
        }
    }

    private void Jump()
    {
        if (grounded == true)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, yVelocity);
            grounded = false;
        }
        else if (!grounded && dblJump)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, yVelocity);
            dblJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        grounded = true;
        dblJump = true;
        // check message upon collition for functionality working of code.
        Debug.Log("I am colliding with something");
    }

    /* ------- Механика смерти -------
     * Функция Death() будет вызываться при столкновении.
     * Если это объект моба, стены или невидимого поля под игроком, движущегося за ним по оси x (но не y)
     */
    public void Death()
    {

    }
}
