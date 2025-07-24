using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour {

	//public static bool parametroBool;
	public static float tempoAcao;
	public static float tempoAtual;

	public static void construtorDelay (float tempoAcao){

		//parametroBool = _parametroBool;
		//tempoAcao = _tempoAcao;
		//tempoAtual = 0f;

		if (tempoAcao != 0) {

			tempoAtual += Time.deltaTime;

			if (tempoAtual >= tempoAcao) {

				//CameraScript.seguePlayer = true;
				tempoAcao = 0;
				tempoAtual = 0;

			}

		}
			

	}

	// Use this for initialization
	void Start () {

		tempoAtual = 0f;
		tempoAcao = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}
}
