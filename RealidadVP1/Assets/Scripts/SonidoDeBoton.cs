using UnityEngine;
using UnityEngine.UI;

public class JugarBoton : MonoBehaviour
{
    public AudioSource audioManager;
    public float inicioEnSegundos = 0.5f;

    public void ReproducirSonido()
    {
        audioManager.Play();
    }
}