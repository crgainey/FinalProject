using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{

    public Transform barkPoint;
    public float distance;

    public GameObject barkBlast;
    public GameObject explosion;

    public float startTimeShots;
    private float timeBtwShots;

    public AudioSource barkAudio;


    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            { 
                barkAudio.Play();
                Instantiate(barkBlast, barkPoint.position, transform.rotation);
                timeBtwShots = startTimeShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    
}
