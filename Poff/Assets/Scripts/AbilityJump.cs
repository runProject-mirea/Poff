using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityJump : MonoBehaviour
{
    [Header("Jump Parameters")]
    [SerializeField] private float xVelocity;
    [SerializeField] private float yVelocity;
    [SerializeField] private int jumps;
    [SerializeField] private AudioClip pickUpSound;

    [Header("Jump Conditions")]
    private bool grounded = true;
    private int nowJumps;

    [Header("Player Object")]
    [SerializeField] private Player player;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Collider2D bodyCollider;
    private float playerXVelocity;

    private void Awake()
    {
        playerXVelocity = player.GetXVelocityNow();
        nowJumps = jumps;
    }

    public void Jumpa()
    {
        if (grounded == true && nowJumps > 0)
        {
            grounded = false;
            nowJumps -= 1;
            //Debug.Log(playerXVelocity);
            StartCoroutine(DoJump());// playerXVelocity));
            
        }
        else if (!grounded && nowJumps > 0)
        {
            nowJumps -= 1;
            StartCoroutine(DoJump());// playerXVelocity));
            
        }
    }

    private IEnumerator DoJump()//float tempXVelocity)
    {
        player.SetXVelocityNow(xVelocity + playerXVelocity * 0.1f);
        rigidBody.velocity = new Vector2(xVelocity + playerXVelocity * 0.1f, yVelocity);
        yield return null;
    }

    public void UpdateJumps()
    {
        grounded = true;
        nowJumps = jumps;
    }

    public bool IsGrounded()
    {
        return Physics2D.Raycast(bodyCollider.bounds.center, Vector2.down,
            bodyCollider.bounds.extents.y + 0.01f, 1 << System.Convert.ToInt32(player.transform.localScale.y));
    }

    //Setters
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
    public bool GetGrounded()
    {
        return grounded;
    }
    public int GetNowJumps()
    {
        return nowJumps;
    }
}

/*public void Jumpa()
    {
        //rigidBody.velocity.Set(0, 0);
        if (grounded == true && nowJumps > 0)
        {
            //rigidBody.velocity = new Vector2(
            //    xVelocity, yVelocity);
            float temp = rigidBody.gravityScale;
            rigidBody.gravityScale = 0;
            rigidBody.AddForce(new Vector2(xVelocity, yVelocity), ForceMode2D.Impulse);
            rigidBody.gravityScale = temp;
            grounded = false;
            nowJumps -= 1;
        }
        else if (!grounded && nowJumps > 0)
        {
            //rigidBody.velocity = new Vector2(
            //    xVelocity, yVelocity);
            float temp = rigidBody.gravityScale;
            rigidBody.gravityScale = 0;
            rigidBody.AddForce(new Vector2(xVelocity, yVelocity), ForceMode2D.Impulse);
            rigidBody.gravityScale = temp;
            nowJumps -= 1;
        }
    }*/