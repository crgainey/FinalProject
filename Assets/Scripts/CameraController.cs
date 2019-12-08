using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;



    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(target.transform.position.x, this.transform.position.y, this.transform.position.z);

        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
