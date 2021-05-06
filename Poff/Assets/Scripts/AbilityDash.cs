using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Сделать подсчитывание чарджов 
// chargingPoints = chargingPoints (PointsWallet & CollectibleObject) +
// chargeNow = chargingPoints / pointsForCharge (40 / 30 = 1,33) -
// если chargingPoints >= pointsForCharge * totalCharge -
// то chargingPoints = pointsForCharge * totalCharge -
public class AbilityDash : MonoBehaviour
{
    [Header("Dash Parameters")]
    [SerializeField] private float dashXVelocity = 20f;
    [SerializeField] private float dashTime = 0.5f;
    [SerializeField] private float coolDownDash = 3.5f;
    [SerializeField] private float pointsForCharge = 30f;
    [SerializeField] private int totalCharge = 3;
    //!!!!!!!!!!!!
    // Добавить в скрипты аудиоклип, ещё в Player, Dash, Jump, Wallet
    [SerializeField] private AudioClip pickUpSound;
    //[SerializeField] private CollectibleObject[] chargingItems;

    //[Header("Dash Conditions")]
    private float coolDownDashNow = 0;
    [Header("Dash Conditions")]
    [SerializeField] private float chargingPoints = 0;
    [SerializeField] private int chargeNow = 0;
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
        chargeNow -= 1;
        chargingPoints -= 30;

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

    public void CheckCharges()
    {
        Debug.LogError("(int)chargingPoints = " + chargingPoints);
        Debug.LogError("(int)pointsForCharge = " + pointsForCharge);
        chargeNow = (int)chargingPoints / (int)pointsForCharge;
        if (chargingPoints >= pointsForCharge * totalCharge)
        {
            chargingPoints = pointsForCharge * totalCharge;
            chargeNow = 3;
        }
        if (chargingPoints < 0)
            chargingPoints = 0;
        if (chargeNow < 0)
            chargeNow = 0;
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
    public void SetCoolDownDashNow(float coolDownDashNow)
    {
        this.coolDownDashNow = coolDownDashNow;
    }
    public void SetChargingPoints(float chargingPoints)
    {
        this.chargingPoints = chargingPoints;
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
    public float GetPointsForCharge()
    {
        return pointsForCharge;
    }
    public float GetChargingPoints()
    {
        return chargingPoints;
    }
    public int GetChargeNow()
    {
        return chargeNow;
    }
    public bool GetIsDashing()
    {
        return isDashing;
    }

}
