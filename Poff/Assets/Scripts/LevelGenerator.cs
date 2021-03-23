using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_LEVEL_PART = 35f;
    //private const float PLAYER_DISTANCE_DELETE_LEVEL_PART = 75f;

    [SerializeField] private Transform levelPart_Start;
    // отсюда выбираются префабы платформ для создания последущей части уровня
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Player player;
    public float distanceSpawn;

    // нужен, чтобы знать, где был последний созданный префаб платформ и для создания нового
    public Vector3 lastSpawnEndPosition;
    //private Transform lastDeleteEndPosition;
    // нужно для удаления пройденных частей уровня (префабов платформ)
    public List<Transform> lastDeleteEndPosition;

    private void Awake()
    {
        // Запоминаем положение стартового префаба
        // чтобы в будущем создать новый и чтобы удалить текущий стартовый
        lastSpawnEndPosition = levelPart_Start.Find("EndPosition").position;
        lastDeleteEndPosition.Add(levelPart_Start.Find("EndPosition"));
    }

    private void Update()
    {
        // узнаём рсстояние от игрока до последнего созданного префаба платформ (они генерируются наперёд игрока)
        if (Vector3.Distance(player.transform.position, lastSpawnEndPosition) < PLAYER_DISTANCE_LEVEL_PART)
        {
            // удаление платформ происходит только при создании новых
            if (lastDeleteEndPosition != null)
            {
                DeleteLevelPart();
            }
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        // рандомно выбирает префаб платформ из списка
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        // генерирует выбранный префаб по координатам
        // (x последнего префаба + дистанция | y последнего префаба | z последнего префаба)
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, 
            new Vector3(lastSpawnEndPosition.x + distanceSpawn, lastSpawnEndPosition.y, lastSpawnEndPosition.z));
        // находим последние созданные префабы
        // запоминаем его для создания нового префаба платформ 
        lastSpawnEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        // запоминаем его в лист префабов для удаления
        lastDeleteEndPosition.Add(lastLevelPartTransform.Find("EndPosition"));
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        // генерируется новый префаб платформ
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    // удаляет все префабы платформ, записанные в лист lastDeleteEndPosition
    private void DeleteLevelPart()
    {
        for (int i = 0; i < lastDeleteEndPosition.Count; i++)
        {
            // если элемент не null и расстояние от игрока до него больше PLAYER_DISTANCE_LEVEL_PART,
            // то удаляет этот префаб, в котором находится EndPosition 
            // и удаляет этот элемент из lastDeleteEndPosition
            if (lastDeleteEndPosition[i] != null &&
                Vector3.Distance(player.transform.position, lastDeleteEndPosition[i].position) > PLAYER_DISTANCE_LEVEL_PART)
            {
                Destroy(lastDeleteEndPosition[i].parent.gameObject);
                lastDeleteEndPosition.RemoveAt(0);
            }
        }
    }
}