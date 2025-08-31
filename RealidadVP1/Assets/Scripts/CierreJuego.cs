using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Cerrando el juego...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Solo funciona en el editor
#else
        Application.Quit(); // Funciona en la build final
#endif
    }
}