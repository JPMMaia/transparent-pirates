using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotation : MonoBehaviour {

    Transform target;

    private void Start()
    {
        target = GetComponentInParent<AIPath>().target;
    }

    // Update is called once per frame
    void LateUpdate () {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (target.position.x < transform.position.x)
            transform.localScale = new Vector3(.5f,.5f,.5f);
        else
            transform.localScale = new Vector3(-.5f, .5f, .5f);

    }
    
}
