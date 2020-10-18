using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;

    Rigidbody2D rb;

    bool facingRight=true;

    bool isGrounded;

    public Transform groundCheck;  

    public float checkRadius;

    public LayerMask whatIsGround;

    public float jumpForce;

    bool isTouchingFront;

    public Transform frontCheck; 

    bool wallSliding;

    public float wallSlidingSpeed;

    bool wallJumping;

    public float xWallForce;

    public float yWallForce; 

    public float wallJumpTime;

    Animator animator;

    public int health;

    public float timeBetweenAttacks;

    float nextAttackTime;

    public Transform attackPoint; 
    
    public float attackRange;

    public LayerMask enemyLayer;

    public int damage;



    public GameObject Blood;

    AudioSource source;








    public AudioClip jumpSound;


    public AudioClip hurtSound;  


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  

        animator = GetComponent<Animator>();

        source = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >  nextAttackTime)
        {
            if (Input.GetKey(KeyCode.Space))
            {




                FindObjectOfType<CameraShake>().Shake(); 
                animator.SetTrigger("attack");
                nextAttackTime = Time.time + timeBetweenAttacks; 
            } 
        }
        float input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

        if (input > 0 && facingRight == false)
        {
            Flip(); 
        }
        else if (input < 0 && facingRight == true)
        {
            Flip();
        }
        if (input != 0)
        {
            animator.SetBool("isRunning", true);

        }

        else
        {
            animator.SetBool("isRunning", false);

        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); 

         if(Input.GetKeyDown(KeyCode.UpArrow)&&isGrounded == true )
        {
            rb.velocity = Vector2.up * jumpForce;
            source.clip = jumpSound;
            source.Play();
        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if(isGrounded==true)
        {
            animator.SetBool("isJumping", false); 
        }
         else
        {

            animator.SetBool("isJumping", true ); 
        }


        if (isTouchingFront == true && isGrounded == false && input != 0)
        {
            wallSliding = true;
        }
        else
        { 
            wallSliding = false;  
        }

        if(wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlidingSpeed, float.MaxValue)); 
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)&&wallSliding == true )
        {
            wallJumping = true;

            Invoke("SetWallJumpToFalse", wallJumpTime); 
        }

        if(wallJumping == true )

        {
            rb.velocity = new Vector2(xWallForce * -input, yWallForce);

            source.clip = jumpSound;
            source.Play();

        }
    }
      void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);  

        facingRight = !facingRight; 
    }

    void SetWallJumpToFalse()
    {
        wallJumping = false; 
    }

    public void TakeDamage(int damage)
    {







        source.clip = hurtSound;
        source.Play();








        Instantiate(Blood, transform.position, Quaternion.identity); 



        FindObjectOfType<CameraShake>().Shake();


        health -= damage;
        print(health);
        if (health <= 0)
        {
            Destroy(gameObject);

        }

    }



      public void attack ()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);


        foreach (Collider2D col in enemiesToDamage)
        {
            col.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {


        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange); 
    }
}

    