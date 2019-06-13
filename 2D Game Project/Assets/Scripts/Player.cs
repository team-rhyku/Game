using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;

    


    public bool grounded;
    public bool canDoubleJump;
    public bool wallsliding;
    public bool facingRight = true;

    public int ourHealth;
    public int maxHealth = 100;

    private Rigidbody2D rb2d;
    private Animator anim;
    public Transform wallCheckPoint;
    public bool wallCheck;
    public LayerMask wallLayerMask;

    
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        ourHealth = maxHealth;

    }


    void Update()
    {
        anim.SetBool("Grounded",grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));


        if (Input.GetAxis("Horizontal") < -0.1)
        {
            transform.localScale = new Vector3(-0.03927656f, 0.02296619f, 1);
            facingRight = false;
        }

        

        if (Input.GetAxis("Horizontal") > 0.1)
        {
            transform.localScale = new Vector3(0.03927656f, 0.02296619f, 1);
            facingRight = true;
        }

        if(Input.GetButtonDown("Jump") && !wallsliding)
        {
            if(grounded)
            { 
            rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {
                if(canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower / 1.75f);
                }
            }
        }

        if (ourHealth > maxHealth)
            ourHealth = maxHealth;

        if(ourHealth <= 0)
        {
            ourHealth = 0;
            Die();
        }
        if(!grounded)
        {
            wallCheck = Physics2D.OverlapCircle(wallCheckPoint.position, 0.1f, wallLayerMask);

            if(facingRight && Input.GetAxis("Horizontal") > 0.1f || !facingRight && Input.GetAxis("Horizontal") < 0.1f)
            {
                if(wallCheck)
                {
                    HandleWallSliding();
                }
            }
        }

        if(wallCheck == false || grounded)
        {
            wallsliding = false;
        }
    }

    void HandleWallSliding()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, -0.7f);

        wallsliding = true;

        if(Input.GetButtonDown("Jump"))
        {
            if(facingRight)
            {
                rb2d.AddForce(new Vector2(-1.5f, 3) * jumpPower);
            }
            else
            {
                rb2d.AddForce(new Vector2(1.5f, 3) * jumpPower);
            }
        }
    }

    void FixedUpdate()
    {

        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;


        float h = Input.GetAxis("Horizontal");

        if(grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        if(grounded)
        {

            rb2d.AddForce((Vector2.right * speed) * h);
        }
        else
        {

            rb2d.AddForce((Vector2.right * speed/2) * h);
        }


        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y); 

        }

        if(rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }


    public void Damage(int dmg)
    {
        ourHealth -= dmg;
    }
}
