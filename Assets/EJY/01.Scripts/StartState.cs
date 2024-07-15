using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Collections;

public class StartState : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private GameObject heartUI;

    

    private void Start()
    {
        heartUI.SetActive(false);

        cam = Camera.main;
        cam.orthographicSize = 3;
        cam.transform.position = new Vector3(-3, -2, -10);
        
        StartCoroutine(TextBlinkCoroutine());
    }

    [SerializeField] private TextMeshProUGUI _startToPressText;

    private IEnumerator TextBlinkCoroutine()
    {
        _startToPressText.DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.2f);
        _startToPressText.DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(TextBlinkCoroutine());
    }
}