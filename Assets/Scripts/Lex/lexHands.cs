using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Itens/Gadgets coletados pelo Lex

public class lexHands : MonoBehaviour {

	public GameObject lamp;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

		lamp.SetActive (lexBools.pegouLamp);
		
	}
}
