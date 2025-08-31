using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowScoresButton : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "Puntaje"; // Cambia esto por el nombre real de tu escena

    public void OnButtonClick()
    {
        Time.timeScale = 1f; // Reactiva el tiempo si estaba pausado
        SceneManager.LoadScene(sceneToLoad);
    }
}