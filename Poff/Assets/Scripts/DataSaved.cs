using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataSaved : MonoBehaviour
{
    [SerializeField] PointsWallet pointsWallet;
    [SerializeField] private float score;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<DataSaved>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void CheckSerializedFields()
    {
        if (pointsWallet == null)
        {
            Debug.LogError("PointsWallet is empty!!!");
        }
    }

    public void setScore()
    {
        if (pointsWallet == null)
        {
            Debug.LogError("PointsWallet is empty!!!");
            score = FindObjectOfType<PointsWallet>().getCurrentScore();
        }
        else
        {
            score = pointsWallet.getCurrentScore();
        }
    }

    public float getScore()
    {
        return score;
    }
}
