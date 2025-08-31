using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowScoresButton : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "Puntaje";

    public void OnButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneToLoad);
    }
}