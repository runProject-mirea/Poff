using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Перенести yVelocity в класс JumpAbility
    [Header("Player Parameters")]
    [SerializeField] private float xVelocity = 5f;
    [SerializeField] private float yVelocity = 6f;
    private Rigidbody2D rigidBody2D;
    private CircleCollider2D playerCollider2D;

    [Header("Jump Ability")]
    [SerializeField] private AbilityJump jumpAbility;

    [Header("Dash Ability")]
    [SerializeField] private AbilityDash dashAbility;
    [SerializeField] private AbilityDash alwaysDashAbility;

    [Header("Wallet Ability")]
    [SerializeField] private PointsWallet wallet;

    private void Awake()
    {
        if (rigidBody2D == null)
            rigidBody2D = GetComponent<Rigidbody2D>();
        if (playerCollider2D == null)
            playerCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        UpdatePlayerPosition();
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        Debug.Log("Collision");
        if (jumpAbility.IsGrounded())
        {
            Debug.Log("Grounded");
            jumpAbility.UpdateJumps();
        }
    }

    public void UpdatePlayerPosition()
    {
        rigidBody2D.velocity = new Vector2(xVelocity, rigidBody2D.velocity.y);
        //if (Input.touchCount == 1)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpAbility.Jumpa(xVelocity, yVelocity);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D was pressed");
            //if (dashAbility.GetCoolDownDashNow() <= 0)
            if (dashAbility.GetCoolDownDashNow() <= 0 && dashAbility.GetChargeNow() > 0
                && alwaysDashAbility.GetIsDashing() == false)
            {
                dashAbility.Dash();
                jumpAbility.UpdateJumps();
                wallet.UpdateChargesDashText();
            }
            else if (alwaysDashAbility.GetCoolDownDashNow() <= 0 && dashAbility.GetIsDashing() == false)
            {
                alwaysDashAbility.Dash();
                jumpAbility.UpdateJumps();
                wallet.UpdateChargesDashText();
            }
        }
    }

    /* ------- Механика смерти -------
     * Функция Death() будет вызываться при столкновении.
     * Если это объект моба, стены или невидимого поля под игроком, движущегося за ним по оси x (но не y)
     */
    public void Death()
    {
        FindObjectOfType<DataSaved>().setScore();
        SceneManager.LoadScene("Game Over");
    }

    // Setters
    public void SetXVelocity(float xVelocity)
    {
        this.xVelocity = xVelocity;
    }
    public void SetYVelocity(float yVelocity)
    {
        this.yVelocity = yVelocity;
    }

    // Getters
    public float GetXVelocity()
    {
        return xVelocity;
    }
    public float GetYVelocity()
    {
        return yVelocity;
    }
    public Rigidbody2D GetRigidBody2D()
    {
        return rigidBody2D;
    }
    public CircleCollider2D GetPlayerCollider2D()
    {
        return playerCollider2D;
    }
}
