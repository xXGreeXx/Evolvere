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

            MainGameHandler.CreateCreature(type, this.transform.position);
        }
    }

    //on collider enter
    void OnCollisionEnter(Collision collision)
    {
        colliding = true;
    }

    //on collider exit
    void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }
}
