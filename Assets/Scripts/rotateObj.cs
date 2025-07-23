using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObj : MonoBehaviour {

	public float rotationSpeed = 0.5f;

	float inicialHeigh, minHeigh, maxHeigh;
	public float velocidadeFlutuar = 5f;
	public float offsetConstant;
	float floatingPos;
	public float lambda, xLambda;
	bool trocaMove;

	// Use this for initialization
	void Start () {

		inicialHeigh = transform.position.y;
		minHeigh = inicialHeigh - offsetConstant;
		maxHeigh = inicialHeigh + offsetConstant;
		lambda = 0.5f;
	}

	// Update is called once per frame
	void Update () {

		//Debug.Log (lambda);

		transform.Rotate (0, 0, rotationSpeed * Time.deltaTime);

		lambda = Mathf.Clamp (lambda, 0, 1);
		xLambda = Mathf.Lerp (minHeigh, maxHeigh, lambda);

		if (trocaMove) {

			lambda = lambda + velocidadeFlutuar * Time.deltaTime;

		} 

		else {

			lambda = lambda - velocidadeFlutuar * Time.deltaTime;

		}

		if (lambda >= 1) {

			lambda = 0.99f;
			trocaMove = !trocaMove;

		} 

		if (lambda <= 0) {

			lambda = 0.11f;
			trocaMove = !trocaMove;

		}

		transform.position = new Vector3 (transform.position.x, xLambda, transform.position.z);
		
	}
}
