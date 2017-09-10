using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Actors;

public class MoonProp : MonoBehaviour {

    public GameObject Werewolf;

    public Sprite broken;

	// Use this for initialization
	void Start () {

        var healthState = GetComponent<ActorHealthState>();
        healthState.OnDie += HealthState_OnDie;
    }

    private void HealthState_OnDie(object sender, System.EventArgs e)
    {
        Werewolf.GetComponent<ActorHealthState>().MaxHealth = 100;
        Werewolf.GetComponent<ActorHealthState>().Health = 100;

        GetComponent<SpriteRenderer>().sprite = broken;
    }
    

// Update is called once per frame
void Update () {
		
	}
}
