using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Enemy 
{



    // Basic Patrol Code  Works Good  

    public Transform[] patrolPoints;

    public float speed;

    int currentPointIndex;

    float waitTime;

    public float startWaitTime;

    Animator animator;

 
    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[0].position;

        transform.rotation = patrolPoints[0].rotation;

        waitTime = startWaitTime;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);


        if (transform.position == patrolPoints[currentPointIndex].position)
        {
            transform.rotation = patrolPoints[currentPointIndex].rotation; 

            animator.SetBool("isRunning2" ,false );

            if (waitTime<=0){

                if (currentPointIndex + 1 < patrolPoints.Length)
                {
                    currentPointIndex++;
                }
                
                else
                {
                    currentPointIndex = 0;
                }
                waitTime = startWaitTime;  
            }

            else
            {
                waitTime -= Time.deltaTime;  
            }

        }

        else
        {
            animator.SetBool("isRunning2", true);

        }

    }

  

}
