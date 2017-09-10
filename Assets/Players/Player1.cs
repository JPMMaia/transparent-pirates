using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Assets.Scripts.Actors;

public class Player1 : MonoBehaviour {

    public float maxSpeed = 5f;
    Vector2 move;
    Rigidbody2D rigidBody;
    Animator anim;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        GetComponent<ActorHealthState>().OnDie += Player2_OnDie;

    }

    private void Player2_OnDie(object sender, System.EventArgs e)
    {
        SceneManager.LoadScene("GameOver");
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var weaponState = GetComponent<ActorWeaponState>();
            var luckyState = GetComponent<ActorLuckyState>();
            weaponState.Attack(luckyState.DamageMultiplier);
            anim.SetBool("Attacking", true);
        }
        else
        {
            anim.SetBool("Attacking", false);
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
