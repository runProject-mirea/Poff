using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Velocity")]
    [SerializeField] private float xVelocity = 5f;
    [SerializeField] private float yVelocity = 6f;

    [SerializeField] private float dashXVelocity = 12f;
    [SerializeField] private float dashTime = 1f;
    private bool isDashing;

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

        if (Input.GetKeyDown(KeyCode.D) && isDashing == false)
        {
            Debug.Log("D was pressed");
            StartCoroutine(Dash());
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
        Debug.Log("Collision");
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

    /*private IEnumerator Dash(float direction)
    {
        isDashing = true;
        player.velocity = new Vector2(player.velocity.x, 0f);
        player.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = player.gravityScale;
        player.gravityScale = 0;
        yield return new WaitForSeconds(1f);
        isDashing = false;
        player.gravityScale = gravity;
    }*/

    private IEnumerator Dash()
    {
        Debug.Log("Dash");

        isDashing = true;

        float tempXVelocity = xVelocity;
        float tempYVelocity = yVelocity;
        xVelocity = dashXVelocity;
        yVelocity = 0;
        player.velocity = new Vector2(xVelocity, yVelocity);
        player.AddForce(new Vector2(xVelocity, yVelocity), ForceMode2D.Impulse);

        float gravity = player.gravityScale;
        player.gravityScale = 0;

        Physics2D.IgnoreLayerCollision(6, 3, true);
        //playerCollider2D.enabled = false;

        yield return new WaitForSeconds(dashTime);
        Physics2D.IgnoreLayerCollision(6, 3, false);
        //playerCollider2D.enabled = true;
        xVelocity = tempXVelocity;
        yVelocity = tempYVelocity;
        isDashing = false;
        player.gravityScale = gravity;

        grounded = true;
        dblJump = true;
    }

    //точность до секунды
    /*IEnumerator ExecuteAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        Debug.Log("Я работаю");
        //сделать нужное
    }*/

    /* ------- Механика смерти -------
     * Функция Death() будет вызываться при столкновении.
     * Если это объект моба, стены или невидимого поля под игроком, движущегося за ним по оси x (но не y)
     */
    public void Death()
    {

    }
}
