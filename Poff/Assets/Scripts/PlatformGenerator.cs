using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    /*[SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform levelPart_1;

    private void Awake()
    {
        SpawnLevelPart(levelPart_Start.GetChild();
        SpawnLevelPart(new Vector3(7.5f, -0.25f, 0));
    }

    private void SpawnLevelPart(Vector3 spawnPosition)
    {
        Instantiate(levelPart_1, spawnPosition, Quaternion.identity);
    }*/

    public GameObject thePlatform;
    public Transform generatorPlatform;
    public float distanceBetween;

    private float platformWidth;

    private void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
    }

    private void Update()
    {
        if (transform.position.x < generatorPlatform.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, 
                transform.position.y, transform.position.z);

            Instantiate(thePlatform, transform.position, transform.rotation);
        }
    }
}
