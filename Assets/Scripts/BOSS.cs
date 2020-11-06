using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BOSS : MonoBehaviour
{
    // Start is called before the first frame update
    
    // Update is called once per frame
  
    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;


    public Animator CamAnim;
    public Slider healthBar;
    private Animator anim;
    public bool isDead;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (health <= 25)
        {
            anim.SetTrigger("Intro");
        }

        if (health <= 0)
        {
            anim.SetTrigger("Outro");
        }

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the player damage ! 
        if (other.CompareTag("Player") && isDead == false)
        {
            if (timeBtwDamage <= 0)
            {
                FindObjectOfType<CameraShake>().Shake();
                CamAnim.SetTrigger("shake");
                other.GetComponent<Player>().health -= damage;
            }
        }
    }
}


