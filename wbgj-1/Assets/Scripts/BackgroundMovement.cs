using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float speed;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        direction = Vector2.left; //sets direction of the movement
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameStarted == true) //if game started bool true, then background pieces will move
        {
            speed += speed * 0.02f * Time.deltaTime;
            transform.Translate(direction * speed * Time.deltaTime);
        }
       
        if(transform.position.x < -50f) //when they reach the boundary, they will delete
        {
            Destroy(gameObject);
        }
    }
}
