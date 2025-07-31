using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moduloDelay : MonoBehaviour {

	public static float tempo; //Tempo/intervalo/delay para a execução de alguma ação
	public static bool boleana; //Boleana que será invertida ao termino do intervalo determinado
	float contagemSegundos = 0f; //Segundos desde que o código começou a rodar
	public static GameObject instanciaAcao; //\instancia de um game object responsável por executar o delay para a ação demandada

	public static void construtorDelay(float _tempo, bool _boleana, GameObject _instanciaAcao){

		tempo = _tempo;
		boleana = _boleana;
		instanciaAcao = Instantiate (_instanciaAcao);
			
	}

	IEnumerator Contador(){

		yield return new WaitForSeconds (1);
		contagemSegundos++;
		StartCoroutine (Contador ());

	}

	// Use this for initialization
	void Start () {

		StartCoroutine (Contador ());
		
	}
	
	// Update is called once per frame
	void Update () {

		if (contagemSegundos >= tempo) {

			//tempo = contagemSegundos; *Ative essa linha somente se quiser criar um loop e desative a linha 42
			boleana = !boleana;
			Destroy (this.gameObject);

		}
		
	}
}
