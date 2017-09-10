using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer2 : MonoBehaviour {
    

    // Update is called once per frame
    void LateUpdate () {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else
            transform.localScale = new Vector3(-1f, 1f, 1f);

    }
    
}
