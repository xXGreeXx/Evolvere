using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour {

	//update
	void FixedUpdate ()
    {
        transform.position -= new Vector3(0, 3, 0);
	}

    //on collide
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
