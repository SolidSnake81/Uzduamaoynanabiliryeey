using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : Enemy
{

    // Magics Code Does Not Work Good Enough 


    public GameObject fireball_red_1;

    public float timeBetweenShots;

    float nextShotTime;

    public Transform shotPoint;   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

         if (Time.time > nextShotTime)

        {
            Instantiate(fireball_red_1, shotPoint.position, transform.rotation);

            nextShotTime = Time.time + timeBetweenShots; 

        }
    }
}
