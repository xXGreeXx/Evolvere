using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawn : MonoBehaviour {

    bool colliding = false;

    //update
    void FixedUpdate()
    {
        //spawn creatures
        if (Random.Range(0, 10001) < MainGameHandler.creatureSpawnRate && !colliding)
        {
            //decide whether creature is plant or animal
            MainGameHandler.CreatureType type = MainGameHandler.CreatureType.Plant;
            if (Random.Range(1, 3) == 1) type = MainGameHandler.CreatureType.Animal;

            //create creature GO
            GameObject go = type.Equals(MainGameHandler.CreatureType.Animal) ? GameObject.CreatePrimitive(PrimitiveType.Cube) : GameObject.CreatePrimitive(PrimitiveType.Capsule);
            go.name = "Creature";
            go.transform.position = this.transform.position + new Vector3(0, 5, 0);
            go.transform.localScale = new Vector3(5, 5, 5);
            go.GetComponent<Renderer>().material.color = Color.yellow;

            Rigidbody body = go.AddComponent<Rigidbody>();
            body.mass = 5000;
            CreatureBehaviorScript script = go.AddComponent<CreatureBehaviorScript>();

            if (type.Equals(MainGameHandler.CreatureType.Plant))
            {
                go.transform.localScale = new Vector3(2, 2, 2);
                go.GetComponent<Renderer>().material.color = Color.green;
            }

            //add creature to main creature list
            MainGameHandler.creatures.Add(go);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        colliding = true;
    }

    void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }
}
