using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player Velocity")]
    [SerializeField] private float xVelocity = 5f;
    [SerializeField] private float yVelocity = 6f;

    [SerializeField] private float dashXVelocity = 12f;
    [SerializeField] private float dashTime = 1f;
    [SerializeField] private float coolDownDash = 5;
    private float coolDownDashNow = 0;
    private bool isDashing;
    //private bool isReadyDash = true;
    

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
        UpdateDashCooldown();
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

    private IEnumerator Dash()
    {
        if (coolDownDashNow > 0)
        //if (isReadyDash)
            yield break;
        isDashing = true;
        //isReadyDash = false;
        coolDownDashNow = coolDownDash;

        float tempXVelocity = xVelocity;
        float tempYVelocity = yVelocity;
        xVelocity = dashXVelocity;
        yVelocity = 0;
        player.velocity = new Vector2(xVelocity, yVelocity);
        player.AddForce(new Vector2(xVelocity, yVelocity), ForceMode2D.Impulse);

        float gravity = player.gravityScale;
        player.gravityScale = 0;

        Physics2D.IgnoreLayerCollision(6, 3, true);

        yield return new WaitForSeconds(dashTime);
        Physics2D.IgnoreLayerCollision(6, 3, false);
        xVelocity = tempXVelocity;
        yVelocity = tempYVelocity;
        isDashing = false;
        player.gravityScale = gravity;

        grounded = true;
        dblJump = true;
    }

    private void UpdateDashCooldown()
    {
        //if (!isReadyDash)
        //{
            coolDownDashNow -= Time.deltaTime;
        //    if (coolDownDashNow <= 0)
        //        isReadyDash = true;
        //}
    }

    /* ------- Механика смерти -------
     * Функция Death() будет вызываться при столкновении.
     * Если это объект моба, стены или невидимого поля под игроком, движущегося за ним по оси x (но не y)
     */
    public void Death()
    {
        //DataSaved data = FindObjectOfType<DataSaved>().setScore();
        //data.setScore();
        FindObjectOfType<DataSaved>().setScore();
        SceneManager.LoadScene("Game Over");
    }
}
