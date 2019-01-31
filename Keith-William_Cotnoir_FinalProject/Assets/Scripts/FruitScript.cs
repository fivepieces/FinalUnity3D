using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{

    // Use this for initialization
   // public AudioSource audiosource;

    void Start ()
    {
        //audiosource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Fruit"))
        {
            //audiosource.Play();
            Destroy(collision.gameObject);
        }

    }

}
