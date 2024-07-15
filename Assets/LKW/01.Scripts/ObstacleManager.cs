using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Obstacles;
    [SerializeField] private Transform SpawnPos;

    private void Start()
    {
        StartCoroutine(SpawnObstacleCorouint());
    }

    private IEnumerator SpawnObstacleCorouint()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            GameObject obstacle =  Obstacles[Random.Range(0, 3)];
            obstacle.transform.position = SpawnPos.position;
        }
    }
}
