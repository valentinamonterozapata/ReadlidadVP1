using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    public float timeRemaining = 60f;
    private bool timerIsRunning = false;
    public GameObject showScoresButton;
    public GameObject nameInputFieldPanel;

    void Start()
    {
        timerIsRunning = true;
        gameOverPanel.SetActive(false);
        UpdateTimerDisplay(timeRemaining);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimerDisplay(timeRemaining);
                OnTimerEnd();
            }
        }
    }

    void UpdateTimerDisplay(float time)
    {
        int seconds = Mathf.FloorToInt(time % 60);
        int minutes = Mathf.FloorToInt(time / 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void OnTimerEnd()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        showScoresButton.SetActive(true);
        nameInputFieldPanel.SetActive(true);
        Debug.Log("¡Tiempo terminado!");
    }
}