using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsTrigger : MonoBehaviour {

    public List<EnemyAI> mobs = new List<EnemyAI>();

    public void Awake()
    {
        foreach (EnemyAI e in mobs)
            e.Deactivate();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (EnemyAI e in mobs)
                e.Activate();

            GetComponent<Collider2D>().enabled = false;
        }
    }
}
