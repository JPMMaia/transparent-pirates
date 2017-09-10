using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    Animator _animator;
    Transform target;

	// Use this for initialization
	void Start () {
        _animator = GetComponentInChildren<Animator>();
        target = GetComponent<AIPath>().target;
	}
	
	// Update is called once per frame
	void Update () {
        var players = GameObject.FindGameObjectsWithTag("Player");

        if (Vector3.Distance(transform.position,players[0].transform.position) < Vector3.Distance(transform.position, players[1].transform.position))
        {
            target = players[0].transform;
        } else
        {
            target = players[1].transform;
        }
	}
}
