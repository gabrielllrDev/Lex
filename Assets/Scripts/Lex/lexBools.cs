﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Propriedades Booleanas do Player, acessíveis a outros scripts

public class lexBools : MonoBehaviour {

	public static bool pegouLamp;
	public static bool isStealth;
	public static bool temGenio;

	public static bool genioControl;

	// Use this for initialization
	void Start () {

		pegouLamp = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
