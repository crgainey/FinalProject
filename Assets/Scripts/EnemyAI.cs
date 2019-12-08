using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject explosion;

    public float speed;
    public float distance;
    public float health;
    public Transform groundDetection;

    private bool movingRight = true;

    private GameController gameController;

    void Start()
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

    
    void Update()
    {
       if(health <= 0)
        {
            //Debug.Log("Health");
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
       
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Instantiate(explosion, other.transform.position, other.transform.rotation);
        gameController.UpdateLives();
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    
}
