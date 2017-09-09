using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer2 : MonoBehaviour {

    Transform target;

    private void Start()
    {
        target = GetComponentInParent<AIPath>().target;
    }

    // Update is called once per frame
    void LateUpdate () {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (GetComponent<AIPath>().velocity2D.x < 0.1)
            transform.localScale = new Vector3(.5f,.5f,.5f);
        else
            transform.localScale = new Vector3(-.5f, .5f, .5f);

    }
    
}
