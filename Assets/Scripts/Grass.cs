using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{

    private Animator anim; 

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>(); 

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("Trigger");
        } 

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
