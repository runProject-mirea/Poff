using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Отвечает за информацию о набранных очках
// взаимодействие с подбираемыми объектами
public class PointsWallet : MonoBehaviour
{
    [SerializeField] private DistanceScore scoreManager;
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AbilityDash chargingDash;
    //[SerializeField] private CollectibleObject[] collectibleObjects;

    private float distanceScore;
    private float itemsScore;
    [SerializeField] private float currentScore;
    // Start is called before the first frame update
    private void Awake()
    {
        scoreManager = new DistanceScore();
        chargingDash = gameObject.GetComponent<AbilityDash>();
        distanceScore = scoreManager.getDistance();
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
        scoreManager.UpdateScore(rigidBody2D);
        distanceScore = scoreManager.getDistance();
    }

    private void UpdateScoreText()
    {
        //UpdateCurrentScore();
        currentScore = Mathf.RoundToInt(currentScore);
        scoreText.text = "SCORE: " + currentScore.ToString();
    }

    public void PickUpObject(CollectibleObject item)
    {
        Debug.Log("PICK UP ITEM");
        itemsScore += item.getScore();
        chargingDash.SetChargingPoints(chargingDash.GetChargingPoints() + item.getChargingPoints());
        chargingDash.CheckCharges();
        //return item.getScore();
    }

    public float GetCurrentScore()
    {
        return currentScore;
    }
}
