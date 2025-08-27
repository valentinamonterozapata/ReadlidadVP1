using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] objects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRandomObject());
    }


    private IEnumerator SpawnRandomObject()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            InstantiateRandomObject();
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    private void InstantiateRandomObject()
    {
        int objectIndex = Random.Range(0, objects.Length);

        GameObject obj = Instantiate(objects[objectIndex], transform.position, objects[objectIndex].transform.rotation);

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector2.up * 15, ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("El objeto instanciado no tiene Rigidbody.");
        }
    }
}
