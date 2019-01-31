using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating2 : MonoBehaviour {

    // Use this for initialization
    private Vector3 pos1 = new Vector3(-4.0f, 27.49f, 0);
    private Vector3 pos2 = new Vector3(4.0f, 27.49f, 0);
    public float speed = 1.0f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
