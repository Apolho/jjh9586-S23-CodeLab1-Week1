using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    float interval;
    public float minTime = 2f;
    public float maxTime = 5f;

    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        interval = Random.Range(minTime, maxTime);
        InvokeRepeating("Spawn", 1f, interval); //invokes it at random times
    }
   

    // Update is called once per frame
    void Spawn()
   {
        GameObject newPrefab = Instantiate(obstacle,transform.position, transform.rotation); //instantiates object 
   }
    
}
