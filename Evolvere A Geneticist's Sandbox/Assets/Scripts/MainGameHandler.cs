using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameHandler : MonoBehaviour {
    //enums
    public enum WeatherTypes 
    {
        Warm,
        Hot,
        Dreary,
        Sunny,
        Rainy,
        Snowy,
    }

    public enum CreatureType
    {
        Plant,
        Animal
    }

    //define global variables
    public static List<GameObject> creatures = new List<GameObject>();
    int simulationDays = 0;

    public static int creatureSpawnRate = 15;

    public static WeatherTypes currentWeather = WeatherTypes.Sunny;
    public static int currentTimeOfDay = 0;
    public static float waterLevel = 93;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	//update
	void FixedUpdate ()
    {
        //update labels

        //update water level
        GameObject.Find("Water").transform.position = new Vector3(265.5F, waterLevel, 152.39F);

        //weather stuff
        if (currentWeather.Equals(WeatherTypes.Rainy))
        {
            GameObject rainObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            rainObject.transform.position = new Vector3(Random.Range(20, 480), 400, Random.Range(20, 480));
            rainObject.transform.localScale = new Vector3(2, 2, 2);
            rainObject.name = "RainDrop";
            rainObject.GetComponent<Renderer>().material.color = Color.blue;
            rainObject.AddComponent<RainScript>();
            rainObject.AddComponent<Rigidbody>().useGravity = false;
        }
	}

    //create creature
    public static void CreateCreature(CreatureType type, Vector3 pos)
    {
        //create creature GO
        GameObject go = type.Equals(CreatureType.Animal) ? GameObject.CreatePrimitive(PrimitiveType.Cube) : GameObject.CreatePrimitive(PrimitiveType.Capsule);
        go.name = "Creature";
        go.transform.position = pos + new Vector3(0, 5, 0);
        go.transform.localScale = new Vector3(5, 5, 5);
        go.GetComponent<Renderer>().material.color = Color.yellow;

        Rigidbody body = go.AddComponent<Rigidbody>();
        body.mass = 5000;
        CreatureBehaviorScript script = go.AddComponent<CreatureBehaviorScript>();
        script.creatureType = type;

        if (type.Equals(CreatureType.Plant))
        {
            go.transform.localScale = new Vector3(2, 2, 2);
            go.GetComponent<Renderer>().material.color = Color.green;

            BoxCollider boxCol = go.AddComponent<BoxCollider>();
            boxCol.center = new Vector3(0, -0.9F, 0);
            boxCol.size = new Vector3(1, 0.15F, 1);
        }

        //add creature to main creature list
        creatures.Add(go);
    }
}
