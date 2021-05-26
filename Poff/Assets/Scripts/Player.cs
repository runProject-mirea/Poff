using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // ��������� yVelocity � ����� JumpAbility
    [Header("Player Parameters")]
    [SerializeField] private float xVelocity = 0;
    private float xVelocityNow;
    private Rigidbody2D rigidBody2D;
    private CircleCollider2D playerCollider2D;

    //[Header("Health Timer")]
    //[SerializeField] private HealthTimer timer;

    [Header("Jump Ability")]
    [SerializeField] private AbilityJump jumpAbility;

    [Header("Dash Ability")]
    [SerializeField] private AbilityDash dashAbility;
    [SerializeField] private AbilityDash alwaysDashAbility;

    [Header("Wallet Ability")]
    [SerializeField] private PointsWallet wallet;

    private void Awake()
    {
        xVelocityNow = xVelocity;
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
            //Debug.Log("Grounded");
            jumpAbility.UpdateJumps();
            xVelocityNow = xVelocity;
        }
    }

    public void UpdatePlayerPosition()
    {
        rigidBody2D.velocity = new Vector2(xVelocityNow, rigidBody2D.velocity.y);
        //rigidBody2D.velocity.Set(xVelocityNow, rigidBody2D.velocity.y);
        //float horizontal = xVelocityNow;
        //rigidBody2D.AddForce(horizontal * Vector2.right);
        //if (Input.touchCount == 1)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpAbility.Jumpa();
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //if (dashAbility.GetCoolDownDashNow() <= 0)
            if (dashAbility.GetCoolDownDashNow() <= 0 && dashAbility.GetChargeNow() > 0)
                //&& alwaysDashAbility.GetIsDashing() == false)
            {
                dashAbility.Dash();
                jumpAbility.UpdateJumps();
                wallet.UpdateChargesDashText();
            }
            /*else if (alwaysDashAbility.GetCoolDownDashNow() <= 0 && dashAbility.GetIsDashing() == false)
            {
                alwaysDashAbility.Dash();
                jumpAbility.UpdateJumps();
                wallet.UpdateChargesDashText();
            }*/
        }
    }


    /* ------- �������� ������ -------
     * ������� Death() ����� ���������� ��� ������������.
     * ���� ��� ������ ����, ����� ��� ���������� ���� ��� �������, ����������� �� ��� �� ��� x (�� �� y)
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
    public void SetXVelocityNow(float xVelocityNow)
    {
        this.xVelocityNow = xVelocityNow;
    }

    // Getters
    public float GetXVelocity()
    {
        return xVelocity;
    }
    public float GetXVelocityNow()
    {
        return xVelocityNow;
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
