using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_LEVEL_PART = 35f;
    private const float PLAYER_DISTANCE_DELETE_LEVEL_PART = 75f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Player player;
    public float distanceSpawn;


    public Vector3 lastSpawnEndPosition;
    //private Transform lastDeleteEndPosition;
    public List<Transform> lastDeleteEndPosition;

    private void Awake()
    {
        lastSpawnEndPosition = levelPart_Start.Find("EndPosition").position;
        //lastDeleteEndPosition = levelPart_Start.Find("EndPosition");
        lastDeleteEndPosition.Add(levelPart_Start.Find("EndPosition"));
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastSpawnEndPosition) < PLAYER_DISTANCE_LEVEL_PART)
        {
            if (lastDeleteEndPosition != null)
            {
                DeleteLevelPart();
            }
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, 
            new Vector3(lastSpawnEndPosition.x + distanceSpawn, lastSpawnEndPosition.y = 0, lastSpawnEndPosition.z = 0));
        lastSpawnEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        //lastDeleteEndPosition = lastLevelPartTransform.Find("EndPosition");
        lastDeleteEndPosition.Add(lastLevelPartTransform.Find("EndPosition"));
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    private void DeleteLevelPart()
    {
        //Destroy(lastDeleteEndPosition.parent.gameObject);
        for (int i = 0; i < lastDeleteEndPosition.Count; i++)
        {
            if (lastDeleteEndPosition[i] != null &&
                Vector3.Distance(player.transform.position, lastDeleteEndPosition[i].position) > PLAYER_DISTANCE_DELETE_LEVEL_PART)
            {
                Destroy(lastDeleteEndPosition[i].parent.gameObject);
                lastDeleteEndPosition.RemoveAt(0);
            }
        }
    }
}