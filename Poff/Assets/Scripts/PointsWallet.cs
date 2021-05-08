using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Отвечает за информацию о набранных очках
// взаимодействие с подбираемыми объектами
public class PointsWallet : MonoBehaviour
{
    [SerializeField] private DistanceScore distanceScoreObject;
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AbilityDash abilityDash;
    [SerializeField] private AbilityDash alwaysAbilityDash;
    [SerializeField] private TextMeshProUGUI chargesDashText;
    [SerializeField] private TextMeshProUGUI cooldownDashText;
    //[SerializeField] private CollectibleObject[] collectibleObjects;

    private float distanceScore;
    private float itemsScore;
    [SerializeField] private float currentScore;
    private void Awake()
    {
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
        distanceScoreObject.UpdateScore(rigidBody2D);
        distanceScore = distanceScoreObject.getDistance();
    }

    private void UpdateScoreText()
    {
        //UpdateCurrentScore();
        currentScore = Mathf.RoundToInt(currentScore);
        scoreText.text = "SCORE: " + currentScore.ToString();
    }

    public void UpdateChargesDashText()
    {
        //chargesDashText.text = "Charges: " + 
        //    (abilityDash.GetChargeNow() + alwaysAbilityDash.GetChargeNow()).ToString();

        /*if (abilityDash.GetChargeNow() > 0)
            chargesDashText.text = "Charges: " + abilityDash.GetChargeNow().ToString();
        else if (alwaysAbilityDash.GetCoolDownDashNow() <= 0)
            chargesDashText.text = "Charges: " + alwaysAbilityDash.GetChargeNow().ToString();*/
        if (abilityDash.GetChargeNow() > 0 && alwaysAbilityDash.GetCoolDownDashNow() <= 0)
            chargesDashText.text = "Charges: " + 
                (abilityDash.GetChargeNow() + alwaysAbilityDash.GetChargeNow()).ToString();
        else if (alwaysAbilityDash.GetCoolDownDashNow() <= 0)
            chargesDashText.text = "Charges: " + alwaysAbilityDash.GetChargeNow().ToString();
        else if (abilityDash.GetChargeNow() > 0)
            chargesDashText.text = "Charges: " + abilityDash.GetChargeNow().ToString();
        else
            chargesDashText.text = "Charges: 0";
    }

    public void UpdateCooldownDashText()
    {
        /*if (abilityDash.GetChargeNow() > 0)
        {
            abilityDash.CheckCooldown();
            cooldownDashText.text = abilityDash.GetCoolDownDashNow().ToString() + " s.";
        }
        else
        {*/
            alwaysAbilityDash.CheckCooldown();
            cooldownDashText.text = alwaysAbilityDash.GetCoolDownDashNow().ToString() + " s.";
        //}
    }

    public void PickUpObject(CollectibleObject item)
    {
        Debug.Log("PICK UP ITEM");
        itemsScore += item.getScore();
        abilityDash.SetChargingPoints(abilityDash.GetChargingPoints() + item.getChargingPoints());
        abilityDash.CheckCharges();
        //UpdateChargesDashText();
        //return item.getScore();
    }

    public float GetCurrentScore()
    {
        return currentScore;
    }
}
