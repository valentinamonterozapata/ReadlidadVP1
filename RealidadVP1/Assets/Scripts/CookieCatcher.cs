using UnityEngine;
using TMPro;

public class CookieCatcher : MonoBehaviour
{
    public TMP_Text cookieCounterText;
    public AudioSource crunchSound;

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

    void UpdateCounterDisplay()
    {
        if (cookieCounterText != null)
        {
            cookieCounterText.text = " " + cookieCount.ToString();
        }
    }
}
