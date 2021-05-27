using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    float speed;
    private Transform backTransform;
    private float backSize;
    private float backPos;

    void Start()
    {
        backTransform = GetComponent<Transform>();
        backSize = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        //backPos += 
    }
}
