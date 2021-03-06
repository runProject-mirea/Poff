using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour, ICollectibleObject
{
    [SerializeField] private float score;
    [SerializeField] private float chargingPoints;
    [SerializeField] private float speedUp;
    [SerializeField] private float timeUp;
    [SerializeField] private float xJumpUp;
    [SerializeField] private float yJumpUp;
    [SerializeField] private AudioClip pickUpSound;

    public void DestroyCollectible()
    {
        //AudioSource.PlayClipAtPoint(pickUpSound, Camera.main.transform.position);
        FindObjectOfType<PointsWallet>().PickUpObject(this);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collect collision");
        if (collision.GetComponent<Player>() == true)
        {
            DestroyCollectible();
        }
    }

    public float getScore()
    {
        return score;
    }
    public float getChargingPoints()
    {
        return chargingPoints;
    }
    public float getSpeedUp()
    {
        return speedUp;
    }
    public float getTimeUp()
    {
        return timeUp;
    }
    public float getXJumpUp()
    {
        return xJumpUp;
    }
    public float getYJumpUp()
    {
        return yJumpUp;
    }
}