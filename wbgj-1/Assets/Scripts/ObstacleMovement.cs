using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float obstacleSpeed;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.left;

        obstacleSpeed = GameManager.speed; //sets obstacle speed to global speed variable
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(direction * obstacleSpeed * Time.deltaTime);
        if (transform.position.x < -20)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }

   
}
