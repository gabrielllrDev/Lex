using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genioScript : MonoBehaviour {

	public GameObject genioOriginal;
	GameObject genio;
	public float alturaGenio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Ground") {

			//Debug.Log ("caiu");

			genio = Instantiate (genioOriginal);
			genio.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + alturaGenio, this.transform.position.z);
			genio.SetActive (true);
			Destroy (this.gameObject);
		}

	}
}
