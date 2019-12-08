using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnContact : MonoBehaviour
{

    public AudioSource pickupAudio;

    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        gameController.UpdateScore();
        Destroy(gameObject);
 
    }
}
