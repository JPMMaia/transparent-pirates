using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2 : MonoBehaviour {

    AIPath aipath;
    Animator _anim;
    
	// Use this for initialization
	void Start () {
        aipath = GetComponent<AIPath>();
        _anim = GetComponentInChildren<Animator>();
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
            var weaponState = GetComponent<Assets.Scripts.Actors.ActorWeaponState>();
            weaponState.Attack();

            _anim.SetBool("Shooting", true);
        }
        else
        {
            _anim.SetBool("Shooting", false);
        }
	}
}
