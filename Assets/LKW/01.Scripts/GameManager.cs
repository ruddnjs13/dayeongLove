using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _obstacleSpawnManager;
    [SerializeField] private GameObject gameOverUI;
    void Start()
    {
        _obstacleSpawnManager.SetActive(false);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }


}
