using UnityEngine;
using UnityEngine.UI;

public class ControlMusica : MonoBehaviour
{
    public AudioSource musicaFondo;
    public Button botonMusicaOn;
    public Button botonMusicaOff;

    void Start()
    {

        botonMusicaOn.onClick.AddListener(DesactivarMusica);
        botonMusicaOff.onClick.AddListener(ActivarMusica);

        ActualizarEstadoMusica(true); 
    }

    public void ActivarMusica()
    {
        ActualizarEstadoMusica(true);
    }

    public void DesactivarMusica()
    {
        ActualizarEstadoMusica(false);
    }

    private void ActualizarEstadoMusica(bool activo)
    {
        musicaFondo.mute = !activo;


    }
}