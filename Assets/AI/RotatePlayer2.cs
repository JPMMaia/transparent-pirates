using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer2 : MonoBehaviour {
    

    // Update is called once per frame
    void LateUpdate () {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (GetComponentInParent<AIPath>().velocity2D.magnitude > .05)
        {
            if (GetComponentInParent<AIPath>().velocity2D.x < 0)
                transform.localScale = new Vector3(.5f, .5f, .5f);
            else
                transform.localScale = new Vector3(-.5f, .5f, .5f);
        }

    }
    
}
