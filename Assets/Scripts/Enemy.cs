using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{


    

    // This is the Red Demons Health Thing It does not work im using it for the destroyer boss   

    public int damage;

    public int health;

    public GameObject Blood;


    public Slider hb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hb.value = health;
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
