using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightHandlerScript : MonoBehaviour {

    //define global variables
    public float speed = 0.025F;

	//update
	void FixedUpdate ()
    {
        GameObject.Find("Sun").transform.Rotate(new Vector3(0, 15 * speed, 0));
        MainGameHandler.currentTimeOfDay = (int)GameObject.Find("Sun").transform.rotation.y;
	}
}
