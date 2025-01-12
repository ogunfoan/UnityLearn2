using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int startSpawn = 2;
    public GameObject[] spawnUnits;
    private Vector3 spawnPoint = new Vector3( 31 ,0 , 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnUnit" , Random.Range(1f,4f) , startSpawn);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void spawnUnit()
    {
        Instantiate(spawnUnits[Random.Range(0, spawnUnits.Length)], spawnPoint, spawnUnits[0].transform.rotation);
    }
}
