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

	// Use this for initialization
	void Start () {
		
	}
	
	//update
	void FixedUpdate ()
    {
        //update labels

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
}
