using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceScore : MonoBehaviour, IUIScore
{
    Vector2 oldPos;
    private float totalDistance = 0.0f;

    public DistanceScore()
    {
        totalDistance = 0.0f;
    }

    public void UpdateScore(Rigidbody2D player)
    {
        totalDistance += (player.position - oldPos).magnitude;
        oldPos = player.position;
    }

    public float getDistance()
    {
        return totalDistance;
    }
}
