using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{



    public float speed;  


    public int damage;







    public float lifeTime; 
    // Start is called before the first frame update
    void Start()
    {


        Destroy(gameObject, lifeTime); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
        Destroy(gameObject);    
    }
}
