using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehaviorScript : MonoBehaviour {

    Vector3 targetPosition = new Vector3();

    int maxHealth = 100;
    int health = 100;
    int reproductionValue = 100;
    int speed = 50;
    int food = 0;
    int water = 0;


	//start
	void Start ()
    {
        //define base position
        targetPosition = new Vector3(Random.Range(76, 444), 0, Random.Range(258, 461));
	}
	
	//update
	void FixedUpdate ()
    {
        transform.LookAt(targetPosition);

        Rigidbody body = transform.GetComponent<Rigidbody>();
        body.AddForce(new Vector3(0, 0, speed + body.mass), ForceMode.Force);
	}
}
