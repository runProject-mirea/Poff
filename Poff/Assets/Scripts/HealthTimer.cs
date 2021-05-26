using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTimer : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private Player player;
    [SerializeField] private MonoBehaviour obj;
    [SerializeField] private TextMeshProUGUI healthTimerText;
    [SerializeField] private float time;

    private void Awake()
    {
        if (player == null)
            player = new Player();
        if (obj == null)
            obj = new MonoBehaviour();
        time = maxTime;
    }

    private void Update()
    {
        UpdateTime();
    }
    private void UpdateTime()
    {
        time -= Time.deltaTime;
        PrintTime(time);
        TryDeathPlayer();
        TryDestroyObject();
    }

    public void PrintTime(float time)
    {
        healthTimerText.text = time + " s.";
    }

    public void TryDestroyObject()
    {
        if (CheckTime())
        {
            Destroy(obj);
        }
    }

    public void TryDeathPlayer()
    {
        if (CheckTime())
        {
            player.Death();
        }
    }

    public bool CheckTime()
    {
        if (time > maxTime)
        {
            time = maxTime;
            return false;
        }
        else if (time > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    public void AddTime(float addingTime)
    {
        time += addingTime;
    }

    public void SetTime(float time)
    {
        this.time = time;
    }
    public float GetTime()
    {
        return time;
    }
}
