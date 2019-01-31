using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{

    // Use this for initialization
    public static float MIN_X_BOUNDS;
    public static float MAX_X_BOUNDS;
    public BoxCollider2D playerCollider;
    public GameObject Layer2;
    public Animator m_Animator;
    public Rigidbody2D m_RigidBody;
    public Text m_text;
    public Text total_score;
    public int collectCount = 0;
    void Start()
    {
        int totalScore = PlayerPrefs.GetInt("TotalScore");
        total_score.text = totalScore.ToString();

        m_Animator = GetComponent<Animator>();
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_text = GetComponent<Text>();
        total_score = GetComponent<Text>();
        MIN_X_BOUNDS = -(Camera.main.aspect * Camera.main.orthographicSize);
        MAX_X_BOUNDS = Camera.main.aspect * Camera.main.orthographicSize;


    }

    // Update is called once per frame
    void Update()
    {





    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            //top check
            BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
            if (transform.position.y + (playerCollider.size.y * transform.localScale.x) / 2f <
                collision.transform.position.y - (collider.size.y * collision.transform.localScale.x) / 2f)
            {
                Destroy(collision.gameObject);
            }
            //Bottom check
            else if (transform.position.y - (playerCollider.size.y * transform.localScale.x) / 2f <
                collision.transform.position.y + (collider.size.y * collision.transform.localScale.x) / 2f)
            {
                m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0f, 0f);
                m_Animator.SetBool("isJumping", false);
                m_RigidBody.gravityScale = 0;
            }

        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (m_Animator.GetBool("isAttacking") == true)
            {
                Destroy(collision.gameObject);


            }
            else
            {
                //Destroy(collision.gameObject);
            }
        }


            if (collision.gameObject.layer == LayerMask.NameToLayer("Bonus"))
        {
            BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
            if (transform.position.y - (playerCollider.size.y * transform.localScale.x) / 2f <
                collision.transform.position.y + (collider.size.y * collision.transform.localScale.x) / 2f)
            {
                m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0f, 0f);
                m_Animator.SetBool("isJumping", false);
                m_RigidBody.gravityScale = 0;
            }

        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Floating"))
        {
            BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
            if (transform.position.y - (playerCollider.size.y * transform.localScale.x) / 2f <
                collision.transform.position.y + (collider.size.y * collision.transform.localScale.x) / 2f)
            {
                m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0f, 0f);
                m_Animator.SetBool("isJumping", false);
                m_RigidBody.gravityScale = 0;
            }

        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Win"))
        {
            BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
            if (transform.position.y - (playerCollider.size.y * transform.localScale.x) / 2f <
                collision.transform.position.y + (collider.size.y * collision.transform.localScale.x) / 2f)
            {
                SceneManager.LoadScene(2);
            }

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bonus"))
        {
            BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
            if (transform.position.y - (playerCollider.size.y * transform.localScale.x) / 2f <
                collision.transform.position.y + (collider.size.y * collision.transform.localScale.x) / 2f)
            { 
            m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0f, 0f);
            m_Animator.SetBool("isJumping", false);
            m_RigidBody.gravityScale = 1;
            }
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
            if (transform.position.y - (playerCollider.size.y * transform.localScale.x) / 2f <
                collision.transform.position.y + (collider.size.y * collision.transform.localScale.x) / 2f)
            {
                m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0f, 0f);
                m_Animator.SetBool("isJumping", false);
                m_RigidBody.gravityScale = 1;
            }
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Floating"))
        {
            BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
            if (transform.position.y - (playerCollider.size.y * transform.localScale.x) / 2f <
                collision.transform.position.y + (collider.size.y * collision.transform.localScale.x) / 2f)
            {
                m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0f, 0f);
                m_Animator.SetBool("isJumping", false);
                m_RigidBody.gravityScale = 1;
            }
        }
    }


}
