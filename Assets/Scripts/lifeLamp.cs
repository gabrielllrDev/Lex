using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeLamp : MonoBehaviour {

	public Rigidbody rbLamp;
	public Vector3 force;
	BoxCollider thisCollidder;

	public GameObject pai;

	// Use this for initialization
	void Start () {

		thisCollidder = GetComponent<BoxCollider> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	void OnTriggerStay(Collider other){

		if (other.gameObject.tag == "Player") {

			//rbLamp.AddForce (force, ForceMode.Impulse);

			if (!lexBools.isStealth) {

				rbLamp.AddTorque (force, ForceMode.Impulse);
				rbLamp.isKinematic = false;

			} 

			else {

				rbLamp.isKinematic = true;

			}

			if (pai.GetComponentInChildren<lampScript>() != null) {

				pai.GetComponentInChildren<lampScript>().aprox = true;

			}

			Invoke ("desativaCollider", 0.025f);

		}

	}

	void desativaCollider(){

		thisCollidder.enabled = false;

	}
}
