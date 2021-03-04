using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform levelPart_1;

    private void Awake()
    {
        Transform lastLevelPartTransform;
        lastLevelPartTransform = SpawnLevelPart(levelPart_Start.Find("EndPosition").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        SpawnLevelPart(new Vector3(7.5f, -0.25f, 0));
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart_1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
