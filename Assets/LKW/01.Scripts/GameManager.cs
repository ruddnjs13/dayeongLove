using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _obstacleSpawnManager;
    void Start()
    {
        _obstacleSpawnManager.SetActive(false);
    }

    void Update()
    {
        
    }
}
