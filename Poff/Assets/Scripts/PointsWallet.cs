using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsWallet : MonoBehaviour
{
    private DistanceScore scoreManager;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] TextMeshProUGUI scoreText;
    //[SerializeField] private CollectibleObject[] collectibleObjects;

    private float distanceScore;
    private float itemsScore;
    [SerializeField] private float currentScore;
    // Start is called before the first frame update
    private void Awake()
    {
        scoreManager = new DistanceScore();
        distanceScore = scoreManager.getDistance();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateDistanceScore();
        UpdateCurrentScore();
        UpdateScoreText();
    }

    private void UpdateCurrentScore()
    {
        //UpdateDistanceScore();
        currentScore = itemsScore + distanceScore;
    }

    private void UpdateDistanceScore()
    {
        scoreManager.UpdateScore(player);
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
        //return item.getScore();
    }

    /*private void PickUpObject(CollectibleObject[] collectibleObjects, Collision2D collision)
    {
        //Object encounteredObject = collision.collider.gameObject;
        for (int i = 0; i < collectibleObjects.Length; i++) {
            if (collision.collider.gameObject == collectibleObjects[i])
            {
                
            }
        }
    }*/
}
