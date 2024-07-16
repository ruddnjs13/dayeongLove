using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private float curretScore = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�浹");
        curretScore++;
        _scoreText.text = $"Score : {curretScore}";
    }
}
