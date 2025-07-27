using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampScript : MonoBehaviour {

	public float moveSpeed = 5f;

	public bool aprox;

	// Use this for initialization
	void Start () {

		aprox = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (aprox == true && !lexBools.isStealth) {

			transform.position += transform.right * moveSpeed * Time.deltaTime;

		}
		
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player") {

			lexBools.pegouLamp = true;
			lexBools.pegouLamp = true;
			Destroy (transform.parent.gameObject);

		}

	}
}
