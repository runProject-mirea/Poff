using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityJump : MonoBehaviour
{
    [Header("Jump Parameters")]
    [SerializeField] private AudioClip pickUpSound;

    [Header("Jump Conditions")]
    private bool grounded = true;
    private bool dblJump = true;

    [Header("Player Object")]
    [SerializeField] private Player player;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Collider2D bodyCollider;

    void Awake()
    {
        player = gameObject.GetComponent<Player>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        bodyCollider = gameObject.GetComponent<Collider2D>();
    }

    public void Jumpa(float xVelocity, float yVelocity)
    {
        if (grounded == true)
        {
            //player.GetRigidBody2D().velocity = new Vector2(
            rigidBody.velocity = new Vector2(
                xVelocity, yVelocity);
            grounded = false;
        }
        else if (!grounded && dblJump)
        {
            //player.GetRigidBody2D().velocity = new Vector2(
            rigidBody.velocity = new Vector2(
                xVelocity, yVelocity);
            dblJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        //Debug.Log("Collision");
        if (IsGrounded())
        {
            Debug.Log("Grounded");
            grounded = true;
            dblJump = true;
        }
    }

    private bool IsGrounded()
    {
        //return Physics2D.Raycast(player.GetPlayerCollider2D().bounds.center, Vector2.down,
        //    player.GetPlayerCollider2D().bounds.extents.y + 0.01f, 1 << 3);
        return Physics2D.Raycast(bodyCollider.bounds.center, Vector2.down,
            player.GetPlayerCollider2D().bounds.extents.y + 0.01f, 1 << 3);
    }

    // Setters
    public void SetGrounded(bool grounded)
    {
        this.grounded = grounded;
    }
    public void SetDblJump(bool dblJump)
    {
        this.dblJump = dblJump;
    }
    // Getters
    public bool GetGrounded()
    {
        return grounded;
    }
    public bool GetDblJump()
    {
        return dblJump;
    }
}
