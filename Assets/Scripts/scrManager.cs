using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Assign this in the inspector.

    private GameObject scoreWall;
    private int initScoreWCount;
    private int scoreWallCount;
    private int score = 0;
    
    
    void Start()
    {
        scoreWall = GameObject.Find("preScoreWall");
        initScoreWCount = scoreWall.transform.childCount;
        scoreWallCount = initScoreWCount;
        
        scoreText.text = "Score: " + score;
        Debug.Log("Num of Children: " + scoreWallCount);
    }

    void Update()
    {
        //For debugging.
        /*
        if (scoreWall.transform.childCount != scoreWallCount)
        {
            Debug.Log("Num of Children: " + scoreWall.transform.childCount);
            scoreWallCount = scoreWall.transform.childCount;
        }
        */
        if (scoreWall.transform.childCount != scoreWallCount)
        {
            scoreWallCount = scoreWall.transform.childCount;
            int score_diff = initScoreWCount - scoreWallCount;
            score = score_diff * 10;
            
            // Update the scoreText's text property to display the current score
            scoreText.text = "Score: " + score;
        }

        if (scoreWallCount <= 0)
        {
            scoreText.text = "Score: " + score + "\n\nBOMB DEFUSED. YOU'VE WON!\n\n<SPACE> to restart";

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        
    }
}
