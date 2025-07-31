using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genioControl : MonoBehaviour {

	public Vector3 offset;
	public Vector3 offsetPlayer;
	public Transform Player;

	public float moveSpeed = 5f;
	bool comecouSeguir = false;
	bool primeiraSeguida;

	// Use this for initialization
	void Start () {

		primeiraSeguida = false;
		lexBools.temGenio = true;
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt (Player);
		transform.rotation = transform.rotation * Quaternion.Euler(offset);

		if (moveLex.Run) {

			if (!comecouSeguir) {

				Invoke ("followLex", 1.5f);

			} 

			else {

				transform.position = Vector3.Lerp (transform.position, Player.position + Player.TransformDirection(offsetPlayer), 4f * Time.deltaTime);

			}


			//followLex ();

			/////moduloDelay (1.5f, followLex);
		} 

		else {

			CancelInvoke ("followLex");
			comecouSeguir = false;

			if (transform.position != Player.position + Player.TransformDirection (offsetPlayer) && primeiraSeguida) {

				transform.position = Vector3.Lerp (transform.position, Player.position + Player.TransformDirection (offsetPlayer), 2f * Time.deltaTime);
			} 

		}

	}

	void LateUpdate(){



	}

	void followLex(){

		comecouSeguir = true;
		primeiraSeguida = true;

	}
}
