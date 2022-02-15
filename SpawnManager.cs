using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabRopes;
    public GameObject[] prefabFruits;
    private float startDelay = 2;
    private float repeatDelay = 2;
    private float yPos = 8f;
    private float xPos = 15f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnInstantiate", startDelay, repeatDelay);
        //InvokeRepeating("SpawnFruits", 3, 20);
    }

    void SpawnInstantiate()
    {
        // generate random index form prefabs []
        int indexObs = Random.Range(0, prefabRopes.Length);
        float spawnX = Random.Range(-xPos, xPos); // RANGE OF X  
        float spawnY = Random.Range(0, yPos); // RANGE OF Y
        Vector2 randomPos = new Vector2(xPos, spawnY); // NEW VECTOR RANDOM POS Y/X 
       
        // Instantiation 
        Instantiate(prefabRopes[indexObs], randomPos, prefabRopes[indexObs].transform.rotation);
    }

    // FRUITS SPWAN
    void SpawnFruits()
    {
        // generate random index form prefabs []
        int indexObs = Random.Range(0, prefabRopes.Length);
        float spawnX = Random.Range(-xPos, xPos); // RANGE OF X  
        float spawnY = Random.Range(0, yPos); // RANGE OF Y
        Vector2 randomPos = new Vector2(xPos, spawnY); // NEW VECTOR RANDOM POS Y/X 

        Instantiate(prefabFruits[indexObs], randomPos, prefabFruits[indexObs].transform.rotation);
    }
}
