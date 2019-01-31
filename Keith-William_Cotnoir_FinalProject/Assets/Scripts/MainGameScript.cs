using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameScript : MonoBehaviour
{

	// Use this for initialization
    public GameObject[] m_EnemyArray = new GameObject[1];
    public GameObject m_Player;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            
    }

    void FollowCamera()
    {
        if (m_Player.transform.position.y >= 0)
        {
            Vector3 campos = Camera.main.transform.position;
            Camera.main.transform.position = new Vector3(campos.x, m_Player.transform.position.y, campos.z);
        }
    }

}
