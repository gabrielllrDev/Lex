using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour {

	public Transform posicaoParaSeguir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	void LateUpdate(){

		transform.position = posicaoParaSeguir.transform.position;

	}
}
