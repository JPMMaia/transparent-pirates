using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {
    public GameObject P1;
    public GameObject P2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(
            (P1.transform.position.x + P2.transform.position.x) / 2,
            (P1.transform.position.y + P2.transform.position.y) / 2,
            0);

    }
}
