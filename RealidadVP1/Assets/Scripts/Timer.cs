using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    //public TextMeshProUGUI scoreText; // Asume que ya tienes los puntajes listos
    public float timeRemaining = 60f;
    private bool timerIsRunning = false;
    public GameObject showScoresButton;
    public GameObject nameInputFieldPanel; // 👈 El objeto que contiene el input field

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
        Time.timeScale = 0f; // Pausa la escena
        gameOverPanel.SetActive(true);
        showScoresButton.SetActive(true); // 👈 Activa el botón
        nameInputFieldPanel.SetActive(true);
        //scoreText.text = GetFormattedScores(); // Simula o conecta con tu sistema de puntajes
        Debug.Log("¡Tiempo terminado!");
    }

    //string GetFormattedScores()
    //{
    //    //// Aquí puedes conectar con tu sistema real de puntajes
    //    //return "1. Alex - 120 pts\n2. Sam - 95 pts\n3. Luna - 80 pts";
    //}
}