using UnityEngine;

public class Croquetas : MonoBehaviour
{

    public GameObject croquetaRebanada;
    public GameObject jugoCroqueta;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateCroquetaRebanada()
    {
        Instantiate(croquetaRebanada, transform.position, transform.rotation);
        Instantiate(jugoCroqueta, new Vector3(transform.position.x, transform.position.y, 0), jugoCroqueta.transform.rotation);
    }

    private void OnMouseDown()
    {
        InstantiateCroquetaRebanada();
        Destroy(gameObject);
    }
}
