using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para fazer com que um objeto qualquer siga a posição ou a rotação de outro objeto.
public class followPosRot : MonoBehaviour {

	public Transform target;
	public bool seguePosicao;
	public bool segueRotacao;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (seguePosicao) {

			transform.position = target.position;

		}

		if (segueRotacao) {

			transform.rotation = target.rotation;

		}

	}
}
