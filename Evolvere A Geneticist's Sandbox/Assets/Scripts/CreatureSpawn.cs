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
            //create creature GO
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = "Creature";
            go.transform.position = this.transform.position + new Vector3(0, 5, 0);
            go.transform.localScale = new Vector3(5, 5, 5);

            Rigidbody body = go.AddComponent<Rigidbody>();
            body.mass = 5000;

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
