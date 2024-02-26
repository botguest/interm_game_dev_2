using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Assign this in the inspector.
    public bool live_lost = false; //flag for update. Triggered by Respawn
    public int lives = 3;
    public GameObject respawnManager;

    private GameObject scoreWall;
    private int initScoreWCount;
    private int scoreWallCount;
    private int score = 0;

    string liveIcon()
    {
        switch (lives)
        {
            case 3:
                return "O O O";
            case 2:
                return "O O";
            case 1:
                return "O";
            case 0:
                return "";
        }

        return "";
    }
    
    void Start()
    {
        scoreWall = GameObject.Find("preScoreWall");
        initScoreWCount = scoreWall.transform.childCount;
        scoreWallCount = initScoreWCount;
        
        scoreText.text = "Score: " + score + "\n" + liveIcon();
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
            scoreText.text = "Score: " + score + "\n" + liveIcon();
        }
        
        //add a case for when losing a live.
        if (live_lost)
        {
            lives--;
            scoreText.text = "Score: " + score + "\n" + liveIcon();
            
            live_lost = false;
        }

        if (lives <= 1)
        {
            respawnManager.GetComponent<scrRespawn>().respawnable = false; //if no live, no respawn.
        }
        
        if (lives <= 0)
        {
            scoreText.text = "Score: " + score + "\n\nBOMB EXPLODED. YOU'VE LOST!\n\n<ENTER> to restart";
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (scoreWallCount <= 0)
        {
            Destroy(GameObject.FindWithTag("ball"));
            respawnManager.GetComponent<scrRespawn>().respawnable = false; //if no wall, no respawn.
            scoreText.text = "Score: " + score + " + " + lives * 10 + "\n\nBOMB DEFUSED. YOU'VE WON!\n\n<ENTER> to restart";

            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        
    }
}
