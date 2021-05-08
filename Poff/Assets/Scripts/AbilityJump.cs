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
    //[SerializeField] private Player player;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Collider2D bodyCollider;

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

    public void UpdateJumps()
    {
        Debug.LogError("UpdateJumps");
        grounded = true;
        dblJump = true;
    }

    public bool IsGrounded()
    {
        //return Physics2D.Raycast(player.GetPlayerCollider2D().bounds.center, Vector2.down,
        //    player.GetPlayerCollider2D().bounds.extents.y + 0.01f, 1 << 3);
        return Physics2D.Raycast(bodyCollider.bounds.center, Vector2.down,
            bodyCollider.bounds.extents.y + 0.01f, 1 << 3);
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
