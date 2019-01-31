using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour {

    // Use this for initialization
    public Animator m_Animator;
    public Rigidbody2D m_RigidBody;
    public SpriteRenderer m_Renderer;
    public AudioSource m_Audiosource;
    const float PLAYER_NORMAL_SPEED = 5f;
    const float GROUND_HEIGHT = -3.741f;
    const float MIN_JUMP_FORCE = 5f;


    void Start () {
        m_Animator = GetComponent<Animator>();
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<SpriteRenderer>();
        m_Audiosource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update () {

        //While holding the A or D key
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            m_Animator.SetBool("isRunning", true);
        }
        //While not holding the A or D key
        else
        {
            m_Animator.SetBool("isRunning", false);
        }

        //While pressing W to jump
        if (Input.GetKey(KeyCode.W) && !m_Animator.GetBool("isJumping"))
        {
            m_Animator.SetBool("isJumping", true);
            GetComponent<AudioSource>().Play();
            m_RigidBody.AddForce(new Vector2(0, MIN_JUMP_FORCE), ForceMode2D.Impulse);
            m_RigidBody.gravityScale = 0.7f;
        }

        //While pressing F to attack
        if (Input.GetKey(KeyCode.F))
        {
            m_Animator.SetBool("isAttacking", true);
            
        }
        else
        {
            m_Animator.SetBool("isAttacking", false);
        }

        //Force the player from falling below this height
        if (transform.position.y < GROUND_HEIGHT)
        {
            m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0f, 0f);
            transform.position = new Vector3(transform.position.x, GROUND_HEIGHT, 0);
            m_Animator.SetBool("isJumping", false);
            m_RigidBody.gravityScale = 0;
        }


        //Flip the character when running
        if (Input.GetAxis("Horizontal") > 0)
        {
            m_Renderer.flipX = true;
            m_Animator.SetBool("isRunning", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            m_Renderer.flipX = false;
            m_Animator.SetBool("isRunning", true);
        }
        else
            m_Animator.SetBool("isRunning", false);


    }

    void FixedUpdate()
    {
       
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (transform.position.x - m_Renderer.bounds.extents.x < PlayerScript.MIN_X_BOUNDS)
            {
                m_RigidBody.velocity = new Vector3(0, m_RigidBody.velocity.y, 0);
            }
            else
            {
                m_RigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * PLAYER_NORMAL_SPEED, m_RigidBody.velocity.y, 0);
            }
            
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            if (transform.position.x + m_Renderer.bounds.extents.x > PlayerScript.MAX_X_BOUNDS)
            {
                m_RigidBody.velocity = new Vector3(0, m_RigidBody.velocity.y, 0);
            }
            else
            {
                m_RigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * PLAYER_NORMAL_SPEED, m_RigidBody.velocity.y, 0);
            }
        }
        else
        {
            m_RigidBody.velocity = new Vector3(0f, m_RigidBody.velocity.y, 0f);
        }

    }
}
