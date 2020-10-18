using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{





    public int damage;

    public int health;









    public GameObject Blood;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }



    public void TakeDamage(int damage)
    {




        Instantiate(Blood, transform.position, Quaternion.identity);


        health -= damage;
        print(health);
        if (health <= 0)
        {
            Destroy(gameObject);

        }

    }

}
