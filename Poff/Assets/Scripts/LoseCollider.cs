﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    // Назначение игрока, за которым будет следовать LoseCollider
    [SerializeField] Player player;

    public void Update()
    {
        UpdateLoseColliderPosition();
    }

    public void UpdateLoseColliderPosition()
    {
        // LoseCollider следует за персонажем игрока по оси х
        transform.position = new Vector2(player.transform.position.x, transform.position.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //При столкновении загружет сцену "Game Over"
        SceneManager.LoadScene("Game Over");
    }
}