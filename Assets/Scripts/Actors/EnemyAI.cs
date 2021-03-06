﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Actors;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour {

    Animator _animator;
    Transform target;

	// Use this for initialization
	void Start () {
        _animator = GetComponentInChildren<Animator>();
        target = GetComponentInParent<AIPath>().target;

        var healthState = GetComponent<ActorHealthState>();
        healthState.OnDie += HealthState_OnDie;
	}

    private void HealthState_OnDie(object sender, System.EventArgs e)
    {
        _animator.SetBool("Alive", false);
        Deactivate();

        if(gameObject.name == "Werewolf")
        {
            SceneManager.LoadScene("Level 2");
        }
    }

    // Update is called once per frame
    void Update() {
        var players = GameObject.FindGameObjectsWithTag("Player");
        var d1 = Vector3.Distance(transform.position, players[0].transform.position);
        var d2 = Vector3.Distance(transform.position, players[1].transform.position);

        if (d1 < d2)
        {
            GetComponentInParent<AIPath>().target = players[0].transform;
        } else
        {
            GetComponentInParent<AIPath>().target = players[1].transform;
        }

        var d3 = Vector3.Distance(transform.position, GetComponentInParent<AIPath>().target.position);

        if (d3 < 3)
        {
            GetComponent<ActorWeaponState>().Attack(1.0f);
            _animator.SetBool("Attacking", true);
        } else
        {
            _animator.SetBool("Attacking", false);
        }
	}

    public void Activate()
    {
        GetComponent<Seeker>().enabled = true;
        GetComponent<AIPath>().enabled = true;
        GetComponentInChildren<BoxCollider2D>().enabled = true;
        GetComponent<EnemyAI>().enabled = true;
        GetComponentInChildren<KeepRotation>().enabled = true;
    }
    public void Deactivate()
    {
        GetComponent<Seeker>().enabled = false;
        GetComponent<AIPath>().enabled = false;
        GetComponentInChildren<BoxCollider2D>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        GetComponentInChildren<KeepRotation>().enabled = false;
    }
}
