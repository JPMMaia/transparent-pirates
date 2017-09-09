using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    public float maxSpeed = 5f;
    Vector2 move;
    Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float hSpeed = Input.GetAxis("Horizontal");
        float vSpeed = Input.GetAxis("Vertical");

        move = new Vector2(hSpeed, vSpeed);

        rigidBody.velocity = move * maxSpeed;
    }
}
