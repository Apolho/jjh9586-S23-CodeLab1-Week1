using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public GameObject player; //references player
    Rigidbody2D rb; //references rigidbody

    public float jumpForce; //initializes jumpForce. Makes it ublic to be edited in inspector

    bool hasJumped; //bool will be true or false to stop players from spamming force

    string newScene;

    public GameObject spawners;

    Animator running;

    public GameObject musicManager;

    public GameObject feed;
    public GameObject logo;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //gets rigidbody component
        hasJumped = false; 
        running = GetComponent<Animator>(); //gets animator component

    }

    // Update is called once per frame
    void Update() //has code for the jump. Bool allows player to jump once before landing on ground
    {
        Vector2 jump = new Vector2(0, jumpForce); //creates a vector2 that is force added only to y
        if (Input.GetKeyDown(KeyCode.Space) && hasJumped == false && GameManager.gameStarted == true) //when space is pressed
        //and the character hasn't jumped and game started, then character will jump
        {
            Debug.Log("Jump");
            rb.AddForce(jump); //adds force to jump
            hasJumped = true; //will turn this true to not allow it to add force anymore
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) //allows the character to jump again ince they land
    {
        {
            if (collision.gameObject.CompareTag("Floor")) //when collides with the floor, will allow player to jump again
            {
                Debug.Log("Collided");
                hasJumped = false; 
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && GameManager.goodTrip == true) //if in the goodtrip scene and hits obstacl
        {
            Debug.Log("SceneChange");
            newScene = "Bad Trip"; //will turn string to bad scene
            Invoke("ChangeScene", .3f); //will chnage the scene 
            GameManager.goodTrip = false; //will turn this false to make sure its in the bad trip
        }
        else if (collision.gameObject.CompareTag("Obstacle") && GameManager.goodTrip == false)
        {
            newScene = "End Screen"; //chnages string to end screen
            Invoke("ChangeScene", 1f); //changes to end screen
            GameManager.stopScore = true; //will stop the score by grabbing the variable from another script
        }
    }

    public void OnMouseDown() //when character clicked, game starts and does these things
    {
        GameManager.stopScore = false; //won't let score start till clicked
        spawners.SetActive(true); //will activate spawners
        GameManager.gameStarted = true; //will chnage for other things
        running.enabled = enabled; //will enable animations
        musicManager.GetComponent<MusicManager>().ChangeSong(); // will call function in another script to change the song
        Destroy(feed); //destroy the feed
        Destroy(logo); //destoy the logo
        canvas.SetActive(true); //adds score text
        Cursor.visible = false;
    }
    public void ChangeScene()
    {
        Debug.Log("ChangeScene Called with: + newScene");

        SceneManager.LoadScene(newScene);
    }
}
