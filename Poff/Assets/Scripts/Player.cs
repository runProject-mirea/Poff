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

    private Rigidbody2D player;
    private CircleCollider2D playerCollider2D;

    void Awake()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        playerCollider2D = gameObject.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        UpdatePlayerPosition();
    }

    public void UpdatePlayerPosition()
    {
        player.velocity = new Vector2(xVelocity, player.velocity.y);
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
            player.velocity = new Vector2(player.velocity.x, yVelocity);
            grounded = false;
        }
        else if (!grounded && dblJump)
        {
            player.velocity = new Vector2(player.velocity.x, yVelocity);
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
        return Physics2D.Raycast(playerCollider2D.bounds.center, Vector2.down,
            playerCollider2D.bounds.extents.y + 0.01f, 1 << 3);
    }

    /* ------- Механика смерти -------
     * Функция Death() будет вызываться при столкновении.
     * Если это объект моба, стены или невидимого поля под игроком, движущегося за ним по оси x (но не y)
     */
    public void Death()
    {

    }
}
