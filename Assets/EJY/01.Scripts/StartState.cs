using DG.Tweening;
using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class StartState : MonoBehaviour
{
    private Camera cam;

    private event Action OnClickEvent;
    private event Action OnEscEvent;

    [SerializeField] private GameObject heartUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject escUI;
    [SerializeField] private TextMeshProUGUI _startToPressText;
    [SerializeField] private TextMeshProUGUI _vannerText;


    private void Start()
    {
        OnClickEvent += HandleStartEvent;
        
        gameOverUI.SetActive(false);
        escUI.SetActive(false);

        heartUI.SetActive(false);
        heartUI.transform.localScale = Vector3.zero;

        cam = Camera.main;
        cam.orthographicSize = 3;
        cam.transform.position = new Vector3(-3, -2, -10);
        
        StartCoroutine(TextBlinkCoroutine());
    }

    private void HandleEscEvent()
    {
        if (escUI.activeSelf == true)
        {

            escUI.SetActive(false);

            Time.timeScale = 1f;
        }
        else
        {
            escUI.SetActive(true);

            Time.timeScale = 0;
        }

    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            OnClickEvent?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscEvent?.Invoke();
        }
    }

    private void HandleStartEvent()
    {
        StopAllCoroutines();

        OnEscEvent += HandleEscEvent;

        heartUI.SetActive(true);
        heartUI.transform.DOScale(Vector3.one, 3.5f);

        _vannerText.DOFade(0, 1.5f);
        _startToPressText.DOFade(0, 1.5f);

        cam.DOOrthoSize(5, 3.5f);
        cam.transform.DOMove(new Vector3(0,0,-10),3.5f);

        OnClickEvent -= HandleStartEvent;
    }

    private void OnDisable()
    {
        OnClickEvent += HandleEscEvent;
        OnEscEvent -= HandleEscEvent;
    }
    private IEnumerator TextBlinkCoroutine()
    {
        _startToPressText.DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.2f);
        _startToPressText.DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(TextBlinkCoroutine());
    }
}