using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2 : MonoBehaviour {

    AIPath aipath;
    
	// Use this for initialization
	void Start () {
        aipath = GetComponent<AIPath>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            aipath.target.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
	}
}
