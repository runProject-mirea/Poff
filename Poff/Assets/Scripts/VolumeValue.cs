using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{

    private AudioSource audioSrc;
    private float musicVoulume = 1f;

    //��� �� ����� ���� ������� ��������� � ���������   
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
      
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVoulume;
    }
    //�������� ���������� � ������� � ���������� � ���������� 
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
