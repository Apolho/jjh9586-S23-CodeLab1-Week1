using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    public float speed;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        direction = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameStarted == true)
        {
            speed += speed * 0.005f * Time.deltaTime;
            transform.Translate(direction * speed * Time.deltaTime);
        }

        if (transform.position.x < -50f)
        {
            transform.position = new Vector2(50f, -2.7f);
        }
    }
}
