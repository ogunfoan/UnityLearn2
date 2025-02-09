using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int startSpawn = 2;
    public GameObject[] spawnUnits;
    private Vector3 spawnPoint = new Vector3( 31 ,1 , 0);
    private PlayerController playerControllerScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("spawnUnit" , Random.Range(1f,4f) , startSpawn);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void spawnUnit()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(spawnUnits[Random.Range(0, spawnUnits.Length)], spawnPoint, spawnUnits[0].transform.rotation);

        }
    }
}
