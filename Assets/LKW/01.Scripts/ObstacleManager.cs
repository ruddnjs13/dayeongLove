using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Obstacles;
    [SerializeField] private GameObject[] DoubleObstacles;
    [SerializeField] private Transform SpawnPos;

    private void Start()
    {
        StartCoroutine(SpawnObstacleCorouint());
    }

    private IEnumerator SpawnObstacleCorouint()
    {
        while (true)
        {
            if (Random.Range(0,3) == 0)
            {
                GameObject Doubleobstacle = DoubleObstacles[Random.Range(0, 3)];
                Doubleobstacle.transform.position = SpawnPos.position;
               
            }
            else
            {
                GameObject obstacle = Obstacles[Random.Range(0, 3)];
                obstacle.transform.position = SpawnPos.position;
            }
            yield return new WaitForSeconds(4.8f);
        }
    }
}
