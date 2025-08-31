using UnityEngine;
using TMPro;

public class CookieCatcher : MonoBehaviour
{
    public TMP_Text cookieCounterText;
    public AudioSource crunchSound;
    public AudioSource boomSound;

    private int cookieCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject.CompareTag("Bomb"))
                {
                    RestartGameWithoutTimer();
                    Destroy(clickedObject);
                    if (boomSound != null)
                    {
                        boomSound.Play();
                    }
                    return;
                }

                if (clickedObject != null && clickedObject.CompareTag("Cookie"))
                {
                    cookieCount += 10;
                    UpdateCounterDisplay();

                    if (crunchSound != null)
                    {
                        crunchSound.Play();
                    }

                    Destroy(clickedObject);
                }
            }
        }
    }

    void RestartGameWithoutTimer()
    {
        cookieCount = 0;
        UpdateCounterDisplay();

        GameObject[] cookies = GameObject.FindGameObjectsWithTag("Cookie");
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");

        foreach (GameObject obj in cookies)
        {
            Destroy(obj);
        }

        foreach (GameObject obj in bombs)
        {
            Destroy(obj);
        }
    }

    void UpdateCounterDisplay()
    {
        if (cookieCounterText != null)
        {
            cookieCounterText.text = " " + cookieCount.ToString();
        }
    }
}
