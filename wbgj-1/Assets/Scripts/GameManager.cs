using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static float speed = 5; //all static variables can be used in other scripts
    public static float score = 0;
    public static float scoreIncrease = 1;

    public static bool stopScore = true;

    public static bool goodTrip = true;

    public GameObject speaker; //connects to the audio source
    

    public TextMeshProUGUI scoreText; //connects to UI

    public static bool gameStarted = false;

     public void Update()
    {
        //increasing speed overtime
        if (goodTrip == true) //makes speed and score for good trip
        {
            speed = 5;
            scoreIncrease = 3;
        }
        else if(goodTrip == false) //increases speed and score when in the bad trip
        {
            speed = 10;
            scoreIncrease = 15;
        }

        speed += speed * 0.075f * Time.deltaTime; //adds speed to speed so it increases

        if (stopScore == false) //boolean increases the score only when game is running
        {
            //increasing score every second
            score += scoreIncrease * Time.deltaTime;
        }


        //(int) is casting. turns the float into an integer
        scoreText.text = ((int)score).ToString();

    }
}
