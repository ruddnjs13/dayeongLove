using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject escUI;
    public void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnPlay()
    {
        escUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
