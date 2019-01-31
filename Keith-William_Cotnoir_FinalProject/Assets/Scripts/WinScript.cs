﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{

    // Use this for initialization
    public GameObject winmonster;
    public Animator animator;
    public Rigidbody2D rigidBody;

    private Vector3 pos1 = new Vector3(-4.0f, 38.11f, 0);
    private Vector3 pos2 = new Vector3(4.0f, 38.11f, 0);
    public float speed = 1.0f;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
