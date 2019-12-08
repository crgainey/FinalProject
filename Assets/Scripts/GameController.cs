using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public Text gameover;
    private int score;
    public  int lives;
    
    public GameObject portal;

    public AudioSource winAudio;
    public AudioSource pickupAudio;
    //public AudioSource portalAudio;

    //this lets me grab the objects from unity and place them in this script??
    public GameObject restartButton, quitButton;

    private PlayerController playerController;

    void Start()
    {
        score = 0;
        lives = 3;
        gameover.text = "";
        SetGameover();
        
        portal.SetActive(false);
    
        //buttons false so they dont appear before needed
        restartButton.SetActive(false);
        quitButton.SetActive(false);

        //to play anim
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
        }
        if (playerControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }
    
    private void Update()
    {
        if (score == 4)
        {
            portal.SetActive(true);
            //portalAudio.Play();
        }


        if (Input.GetKey("escape"))
            Application.Quit();

    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score:" + score;
        SetGameover();

    }

    public void UpdateLives()
    {
        lives--;
        livesText.text = "Lives:" + lives;
        SetGameover();
    }

    public void ResetLives()
    {
        lives = 3;
        livesText.text = "Lives:" + lives;
    }

    void SetGameover()
    {
       
        if (score >= 8)
        {
            gameover.text = "You win! Game created by Cynthia Gainey!";
            winAudio.Play();
            restartButton.SetActive(true);
            quitButton.SetActive(true);

        }

        if (lives == 0)
        {
            gameover.text = "You lose! Game created by Cynthia Gainey!";
            playerController.anim.SetTrigger("Dead");
            restartButton.SetActive(true);
            quitButton.SetActive(true);

        }
    }
    
}
