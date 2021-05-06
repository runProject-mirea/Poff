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
     

    void Awake()
    {
        dashAbility = gameObject.GetComponent<AbilityDash>();
        jumpAbility = gameObject.GetComponent<AbilityJump>();
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        playerCollider2D = gameObject.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        UpdatePlayerPosition();
    }

    public void UpdatePlayerPosition()
    {
        rigidBody2D.velocity = new Vector2(xVelocity, rigidBody2D.velocity.y);
        //if (Input.touchCount > 0)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpAbility.Jumpa(xVelocity, yVelocity);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D was pressed");
            if (dashAbility.GetCoolDownDashNow() <= 0)// && dashAbility.GetChargeNow() > 0)
            {
                Debug.LogError("CHARGE");
                StartCoroutine(dashAbility.Dash());
                jumpAbility.SetGrounded(true);
                jumpAbility.SetDblJump(true);
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
