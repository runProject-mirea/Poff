using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Отвечает за информацию о набранных очках
// взаимодействие с подбираемыми объектами
public class PointsWallet : MonoBehaviour
{
    [SerializeField] private DistanceScore distanceScoreObject;
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AbilityDash abilityDash;
    //[SerializeField] private AbilityDash alwaysAbilityDash;
    // Перенести TMP отображение рывка в класс рывка, как это сделано с HealthTimer
    [SerializeField] private TextMeshProUGUI chargesDashText;
    [SerializeField] private TextMeshProUGUI cooldownDashText;
    [SerializeField] private HealthTimer healthTimer;
    [SerializeField] private AbilityJump jumpAbility;
    //[SerializeField] private CollectibleObject[] collectibleObjects;

    private float distanceScore;
    private float itemsScore;
    [SerializeField] private float currentScore;
    private void Awake()
    {
        if (distanceScoreObject == null)
            distanceScoreObject = new DistanceScore();
        if (abilityDash == null)
            abilityDash = new AbilityDash();
        if (jumpAbility == null)
            jumpAbility = new AbilityJump();
        //if (alwaysAbilityDash == null)
        //    alwaysAbilityDash = new AbilityDash();
        distanceScore = distanceScoreObject.getDistance();
        DontDestroyOnLoad(scoreText);
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateDistanceScore();
        UpdateCurrentScore();
        UpdateChargesDashText();
        UpdateCooldownDashText();

        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // по-хорошему, отображение очков должно обновляться 
        // в классе, отвечающем за информацию на экране
        UpdateScoreText();
    }

    private void UpdateCurrentScore()
    {
        currentScore = itemsScore + distanceScore;
    }

    private void UpdateDistanceScore()
    {
        distanceScoreObject.UpdateScore(player.GetRigidBody2D());
        distanceScore = distanceScoreObject.getDistance();
    }

    private void UpdateScoreText()
    {
        currentScore = Mathf.RoundToInt(currentScore);
        scoreText.text = "SCORE: " + currentScore.ToString();
    }

    public void UpdateChargesDashText()
    {
        if (abilityDash.GetChargeNow() > 0)// && alwaysAbilityDash.GetCoolDownDashNow() <= 0)
            chargesDashText.text = "Charges: " +
                //(abilityDash.GetChargeNow() + alwaysAbilityDash.GetChargeNow()).ToString();
                abilityDash.GetChargeNow().ToString();
        //else if (alwaysAbilityDash.GetCoolDownDashNow() <= 0)
        //    chargesDashText.text = "Charges: " + alwaysAbilityDash.GetChargeNow().ToString();
        else if (abilityDash.GetChargeNow() > 0)
            chargesDashText.text = "Charges: " + abilityDash.GetChargeNow().ToString();
        else
            chargesDashText.text = "Charges: 0";
    }

    public void UpdateCooldownDashText()
    {
        abilityDash.CheckCooldown();
        //alwaysAbilityDash.CheckCooldown();
        if (abilityDash.GetChargeNow() > 0)// && alwaysAbilityDash.GetCoolDownDashNow() >= 0)
            cooldownDashText.text = abilityDash.GetCoolDownDashNow().ToString() + " s.";
        //else if (alwaysAbilityDash.GetCoolDownDashNow() >= 0)
        //    cooldownDashText.text = alwaysAbilityDash.GetCoolDownDashNow().ToString() + " s.";
        else if (abilityDash.GetChargeNow() > 0)
            cooldownDashText.text = abilityDash.GetCoolDownDashNow().ToString() + " s.";
        else
            cooldownDashText.text = "0 s.";
        
        //abilityDash.CheckCooldown();
        //cooldownDashText.text = abilityDash.GetCoolDownDashNow().ToString() + " s.";
        //alwaysAbilityDash.CheckCooldown();
        //cooldownDashText.text = alwaysAbilityDash.GetCoolDownDashNow().ToString() + " s.";
    }

    public void PickUpObject(CollectibleObject item)
    {
        Debug.Log("PICK UP ITEM");
        itemsScore += item.getScore();

        abilityDash.SetChargingPoints(abilityDash.GetChargingPoints() + item.getChargingPoints());
        abilityDash.CheckCharges();

        player.SetXVelocity(player.GetXVelocity() + item.getSpeedUp());
        //healthTimer.SetTime(healthTimer.GetTime() + item.getTimeUp());

        healthTimer.AddTime(item.getTimeUp());
        healthTimer.PrintTime(healthTimer.GetTime());

        jumpAbility.SetXVelocity(jumpAbility.GetXVelocity() + item.getXJumpUp());
        jumpAbility.SetYVelocity(jumpAbility.GetYVelocity() + item.getYJumpUp());
        //UpdateChargesDashText();
        //return item.getScore();
    }

    public float GetCurrentScore()
    {
        return currentScore;
    }
}