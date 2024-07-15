using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeart : MonoBehaviour
{
    [SerializeField] private Transform HpPanel;
    [SerializeField] private GameObject HpPrefab;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i< _player.PlayerHP; i++)
        {
            Instantiate(HpPrefab, HpPanel);
        }
    }

    public void DestroyHeart()
    {
        if (HpPanel.childCount <= 0) return;
        Destroy(HpPanel.GetChild(0).gameObject);
    }

    public void MakeHeart()
    {
        if (HpPanel.childCount >= 5) return;
        Instantiate(HpPrefab, HpPanel);
    }
}
