using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public int score = 0;
    public Text scoreText;

    public PlayerController playerControllerScript;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }

        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); 
        }

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
        //Display score until game is over
        if (!playerControllerScript.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        //Loss condition: hit obstacle
        if (playerControllerScript.gameOver && !won)
        {
            scoreText.text = "You lose!\nPress R to try again!";
        }

        //Win condition: 10 points
        if (score >= 10)
        {
            playerControllerScript.gameOver = true;
            won = true;

            //Stop player from running

            scoreText.text = "You win!\nPress R to play again!"
        }

        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
