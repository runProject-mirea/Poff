using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{

    private AudioSource audioSrc;
    private float musicVoulume = 1f;

    //Что бы можно было полчить информацю с копонента   
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
      
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVoulume;
    }
    //Заберает информацию с бегунка и отпровляет К КОМПОНЕНТУ 
    public void setVoulume(float vol)
    {
        musicVoulume = vol;
        int gameStatusCount = FindObjectsOfType<AudioSource>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
