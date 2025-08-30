using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerMinutes;
    public TextMeshProUGUI timerSeconds;
    public TextMeshProUGUI timerSeconds100;

    private float startTime;
    private bool isRunning = false;

    void Start()
    {
        // Inicia el temporizador automáticamente al comenzar la escena
        isRunning = true;
        startTime = Time.time;
    }

    void Update()
    {
        if (!isRunning) return;

        float timerTime = Time.time - startTime;

        // Detener el conteo al llegar a 60 segundos
        if (timerTime >= 60f)
        {
            timerTime = 60f;
            isRunning = false;

            SceneManager.LoadScene("Score");
        }

        int minutesInt = (int)timerTime / 60;
        int secondsInt = (int)timerTime % 60;
        int seconds100Int = (int)((timerTime - (minutesInt * 60 + secondsInt)) * 100);

        timerMinutes.text = minutesInt.ToString("D2");
        timerSeconds.text = secondsInt.ToString("D2");
        timerSeconds100.text = seconds100Int.ToString("D2");
    }
}
