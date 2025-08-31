using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] objects;
    public Transform spawnPoint;
    public float spawnRadius = 5f;
    public float minForce = 600f;
    public float maxForce = 1200f;
    public int maxCookies = 100;


    private int cookieCount = 0;

    void Start()
    {
        if (spawnPoint == null)
        {
            Debug.LogError("No se ha asignado el SpawnPoint en el Inspector.");
            return;
        }

        StartCoroutine(SpawnRandomObject());
    }

    private IEnumerator SpawnRandomObject()
    {
        yield return new WaitForSeconds(1);

        while (cookieCount < maxCookies)
        {
            InstantiateRandomObject();
            cookieCount++;
            yield return new WaitForSeconds(1);
        }
    }

    private void InstantiateRandomObject()
    {
        GameObject selectedObject;

        float chance = Random.Range(0f, 1f);
        if (chance < 0.8f)
        {
            int cookieIndex = Random.Range(0, 2);
            selectedObject = objects[cookieIndex];
        }
        else
        {
            selectedObject = objects[2];
        }

        if (selectedObject == null) return;

        Vector3 spawnPos = spawnPoint.position + new Vector3(
            Random.Range(-spawnRadius, spawnRadius),
            0f,
            Random.Range(-spawnRadius, spawnRadius)
        );

        GameObject obj = Instantiate(selectedObject, spawnPos, Quaternion.identity);
        if (obj == null) return;

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 launchDir = new Vector3(
                Random.Range(-1f, 1f),
                1f,
                Random.Range(-0.5f, 0.5f)
            ).normalized;

            float force = Random.Range(minForce, maxForce);
            rb.AddForce(launchDir * force, ForceMode.Impulse);
            rb.AddTorque(Random.insideUnitSphere * 5f, ForceMode.Impulse);
        }

        Destroy(obj, 5f);
    }

}
