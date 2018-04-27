using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehaviorScript : MonoBehaviour {

    //variables for both plants and animals
    public MainGameHandler.CreatureType creatureType;
    int maxHealth = 100;
    int health = 100;
    int reproductionValue = 100;
    int water = 0;

    //variables for animals
    Vector3 targetPosition = new Vector3();
    int speed = 50;
    int food = 0;

    //variables for plants
    int energy = 0;
    int height = 0;
    int heightMax = 0;

	//start
	void Start ()
    {
        //define base position
        targetPosition = new Vector3(Random.Range(76, 444), 0, Random.Range(258, 461));
	}
	
	//update
	void FixedUpdate ()
    {
        //cause death if below water level
        if (transform.position.y < MainGameHandler.waterLevel)
        {
            MainGameHandler.creatures.Remove(gameObject);
            Destroy(gameObject);
        }

        //handle if plant
        if (creatureType.Equals(MainGameHandler.CreatureType.Plant))
        {
            //increase reproduction value
            reproductionValue++;

            if (reproductionValue >= 500)
            {
                GameObject spore = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                spore.name = "Spore";
                spore.transform.position = transform.position;
                spore.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);

                Spore sporeScript = spore.AddComponent<Spore>();
                Rigidbody body = spore.AddComponent<Rigidbody>();
                body.mass = 0.025F;

                reproductionValue = 0;
            }
        }
        else
        {
            transform.LookAt(targetPosition);
            Rigidbody body = transform.GetComponent<Rigidbody>();
            body.AddForce(new Vector3(0, 0, speed + body.mass), ForceMode.Force);
        }
	}
}
