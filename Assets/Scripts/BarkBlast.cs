using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkBlast : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;

    public LayerMask whatIsSolid;

    public GameObject blastDestroy;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBlast",lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyAI>().TakeDamage(damage);
                //Debug.Log(hitInfo.transform.name);
                //Destroy(hitInfo.transform.gameObject);
                
            }
            DestroyBlast();
        }

            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyBlast()
    {
        Instantiate(blastDestroy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
