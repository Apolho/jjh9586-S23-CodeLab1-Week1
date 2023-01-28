using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMovement : MonoBehaviour
{
    public float speed;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        direction = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameStarted == true)
        {
            speed += speed * 0.02f * Time.deltaTime;
            transform.Translate(direction * speed * Time.deltaTime);
        }

        if (transform.position.x < -20f)
        {
            transform.position = new Vector2(27f, 2.1f);
        }
    }
}
