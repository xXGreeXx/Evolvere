using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore : MonoBehaviour {

	//start
	void Start ()
    {
        transform.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-3, 4), 0, Random.Range(-3, 4)), ForceMode.Impulse);
    }
	
	//update
	void FixedUpdate ()
    {

	}

    //on collision
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Terrain"))
        {
            MainGameHandler.CreateCreature(MainGameHandler.CreatureType.Plant, transform.position - new Vector3(0, 5, 0));
            Destroy(gameObject);
        }
    }
}
