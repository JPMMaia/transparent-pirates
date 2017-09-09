using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    public float maxSpeed = 5f;
    Vector2 move;
    Rigidbody2D rigidBody;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var weaponState = GetComponent<Assets.Scripts.Actors.ActorWeaponState>();
            weaponState.Attack();
        }
    }

    private void FixedUpdate()
    {
        float hSpeed = Input.GetAxis("Horizontal");
        float vSpeed = Input.GetAxis("Vertical");

        move = new Vector2(hSpeed, vSpeed);

        rigidBody.velocity = move * maxSpeed;
        if (hSpeed < 0.0f)
            transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        else if (hSpeed > 0.0f)
            transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
    }
}
