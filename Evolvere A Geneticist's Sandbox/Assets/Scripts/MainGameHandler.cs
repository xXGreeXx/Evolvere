﻿using System.Collections;
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

    //define global variables
    List<GameObject> creatures = new List<GameObject>();
    int simulationDays = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
