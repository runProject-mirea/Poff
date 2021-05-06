using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDash : MonoBehaviour
{
    [Header("Dash Parameters")]
    [SerializeField] private float dashXVelocity = 20f;
    [SerializeField] private float dashTime = 0.5f;
    [SerializeField] private float coolDownDash = 3.5f;

    [Header("Dash Conditions")]
    private float coolDownDashNow = 0;
    private bool isDashing = false;

    [Header("Player Object")]
    [SerializeField] private Player player;

    void Awake()
    {
        player = gameObject.GetComponent<Player>();
    }

    void Update()
    {
        UpdateDashCooldown();
    }

    public IEnumerator Dash()
    {
        SetIsDashing(true);
        SetCoolDownDashNow(coolDownDash);

        float tempXVelocity = player.GetXVelocity();
        float tempYVelocity = player.GetYVelocity();
        player.SetXVelocity(dashXVelocity);
        player.SetYVelocity(0);
        player.GetRigidBody2D().velocity = new Vector2(player.GetXVelocity(), player.GetYVelocity());
        player.GetRigidBody2D().AddForce(new Vector2(player.GetXVelocity(), 
            player.GetYVelocity()), ForceMode2D.Impulse);

        float gravity = player.GetRigidBody2D().gravityScale;
        player.GetRigidBody2D().gravityScale = 0;

        Physics2D.IgnoreLayerCollision(6, 3, true);

        yield return new WaitForSeconds(dashTime);
        Physics2D.IgnoreLayerCollision(6, 3, false);
        player.SetXVelocity(tempXVelocity);
        player.SetYVelocity(tempYVelocity);
        isDashing = false;
        player.GetRigidBody2D().gravityScale = gravity;
    }

    private void UpdateDashCooldown()
    {
        coolDownDashNow -= Time.deltaTime;
    }

    // Setters
    public void SetDashXVelocity(float dashXVelocity)
    {
        this.dashXVelocity = dashXVelocity;
    }
    public void SetDashTime(float dashTime)
    {
        this.dashTime = dashTime;
    }
    public void SetCoolDownDash(float coolDownDash)
    {
        this.coolDownDash = coolDownDash;
    }
    public void SetCoolDownDashNow(float coolDownDashNow)
    {
        this.coolDownDashNow = coolDownDashNow;
    }
    public void SetIsDashing(bool isDashing)
    {
        this.isDashing = isDashing;
    }

    // Getters
    public float GetDashXVelocity()
    {
        return dashXVelocity;
    }
    public float GetDashTime()
    {
        return dashTime;
    }
    public float GetCoolDownDash()
    {
        return coolDownDash;
    }
    public float GetCoolDownDashNow()
    {
        return coolDownDashNow;
    }
    public bool GetIsDashing()
    {
        return isDashing;
    }
}
