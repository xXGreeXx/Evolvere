using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehaviorScript : MonoBehaviour {

    //variables for both plants and animals
    public MainGameHandler.CreatureType creatureType;
    int maxHealth = 100;
    int health = 100;
    int reproductionValue = 0;
    int water = 0;
    int age = 0;
    int maxAge = 520;

    //variables for animals
    Vector3 targetPosition = new Vector3();
    int speed = 50;
    int food = 0;

    //variables for plants
    int energy = 150;
    float height = 1;
    float heightMax = 2;

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

        //handle joint simulation
        age++;
        if (age >= maxAge)
        {
            MainGameHandler.creatures.Remove(gameObject);
            Destroy(gameObject);
        }

        //handle if plant
        if (creatureType.Equals(MainGameHandler.CreatureType.Plant))
        {
            //handle reproduction
            reproductionValue++;

            if (reproductionValue >= 250)
            {
                GameObject spore = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                spore.name = "Spore";
                spore.transform.position = transform.position;
                spore.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);

                Spore sporeScript = spore.AddComponent<Spore>();
                Rigidbody body = spore.AddComponent<Rigidbody>();
                body.mass = 0.035F;

                reproductionValue = 0;
            }

            //handle height gain
            height += 0.005F;
            gameObject.transform.localScale = new Vector3(2, height, 2);

            //handle energy usage/creation
            int sunMod = 1 - MainGameHandler.currentTimeOfDay / 360;
            if (MainGameHandler.waterLevel > 1)
            {
                MainGameHandler.waterLevel -= 0.0005F;
                energy += 1 + 1 * sunMod;
            }
            energy--;
            if (energy <= 40) gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            if (energy <= 0)
            {
                MainGameHandler.creatures.Remove(gameObject);
                Destroy(gameObject);
            }
        }
        else //handle if animal
        {
            transform.LookAt(targetPosition);
            Rigidbody body = transform.GetComponent<Rigidbody>();
            body.AddForce(new Vector3(0, 0, speed + body.mass), ForceMode.Force);
        }
	}
}
