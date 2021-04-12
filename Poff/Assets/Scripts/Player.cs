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
    private CircleCollider2D circleCollider2D;

    void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
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

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (IsGrounded())
        {
            grounded = true;
            dblJump = true;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(circleCollider2D.bounds.center, Vector2.down,
            circleCollider2D.bounds.extents.y + 0.01f, 1 << 3);
    }

    /* ------- Механика смерти -------
     * Функция Death() будет вызываться при столкновении.
     * Если это объект моба, стены или невидимого поля под игроком, движущегося за ним по оси x (но не y)
     */
    public void Death()
    {

    }
}
