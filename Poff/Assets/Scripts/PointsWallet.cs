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
    [SerializeField] private TextMeshProUGUI chargesDashText;
    //[SerializeField] private CollectibleObject[] collectibleObjects;

    private float distanceScore;
    private float itemsScore;
    [SerializeField] private float currentScore;
    // Start is called before the first frame update
    private void Awake()
    {
        distanceScoreObject = new DistanceScore();
        abilityDash = gameObject.GetComponent<AbilityDash>();
        distanceScore = distanceScoreObject.getDistance();
        DontDestroyOnLoad(scoreText);
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateDistanceScore();
        UpdateCurrentScore();

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
        chargesDashText.text = "Charges: " + abilityDash.GetChargeNow().ToString();
    }

    public void PickUpObject(CollectibleObject item)
    {
        Debug.Log("PICK UP ITEM");
        itemsScore += item.getScore();
        abilityDash.SetChargingPoints(abilityDash.GetChargingPoints() + item.getChargingPoints());
        abilityDash.CheckCharges();
        UpdateChargesDashText();
        //return item.getScore();
    }

    public float GetCurrentScore()
    {
        return currentScore;
    }
}
