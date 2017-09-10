using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Actors;
using UnityEngine.SceneManagement;


public class Player2 : MonoBehaviour {

    AIPath aipath;
    Animator _anim;
    
	// Use this for initialization
	void Start () {
        aipath = GetComponent<AIPath>();
        _anim = GetComponentInChildren<Animator>();

        GetComponent<ActorHealthState>().OnDie += Player2_OnDie;
	}

    private void Player2_OnDie(object sender, System.EventArgs e)
    {
        SceneManager.LoadScene("GameOver");
    }

    // Update is called once per frame
    void Update () {
        if (aipath.velocity2D.magnitude > .1f)
            _anim.SetBool("Moving", true);
        else
            _anim.SetBool("Moving", false);


        if (Input.GetMouseButtonDown(0))
        {
            aipath.target.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButtonDown(1))
        {
            var weaponState = GetComponent<ActorWeaponState>();
            var luckyState = GetComponent<ActorLuckyState>();
            weaponState.Attack(luckyState.DamageMultiplier);

            _anim.SetBool("Shooting", true);
        }
        else
        {
            _anim.SetBool("Shooting", false);
        }
	}
}
