using UnityEngine;
using TMPro;

public class CookieCatcher : MonoBehaviour
{
    public TMP_Text cookieCounterText; // Asigna el TextMeshPro desde el Inspector
    private int cookieCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Cookie"))
                {
                    cookieCount += 10;
                    UpdateCounterDisplay();
                    Destroy(hit.collider.gameObject); 
                }
            }
        }
    }

    void UpdateCounterDisplay()
    {
        cookieCounterText.text = " " + cookieCount.ToString();
    }
}
