//Resumo: Script para rotacionar a câmera a partir de um target. Um objeto vazio segue a posição do player
//mas tem uma rotação própria, determinada pelo input do mouse. A câmera é um objeto filho do target, rotacionando
//junto com ele.

//O Script pode ser adicionado na própria câmera para sistemas de primeira pessoa. Mas, como na maioria dos meus
//projetos eu prefiro que a câmera orbite ao redor do personagem, fazemos da forma descrita inicialmente.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esse script é aplicado à um GameObject vazio, que deve manter a posição do player
//A rotação do GameObject é ajustada de acordo com o valor lido pelo mouse
//A câmera em si é associada ao GameObject vazio como um objeto filho, fazendo com que ela siga sua rotação

public class CameraScript : MonoBehaviour {

	//public static bool seguePlayer;


	public float RotationSpeed = 500f; //Velocidade de rotação
	public Transform playerPos; //Posição do player
	public static Transform genioPos; //Posição do genio

	public Vector3 offset; //Ajusta a posição da câmera no eixo y
	public Vector3 offsetGenio;

	//Valores máximos e mínimos para o ângulo de rotação ao olhar para cima/baixo
	public float minY = -50;
	public float maxY = 50;

	//Ângulos de rotação
	float anguloX;
	float anguloY;

	bool comecouSeguir = false;

	void cameraFollow(Transform playerTransform, Vector3 offset){

		if (moveLex.Run == true) {

			//delay para seguir o jogador

			if (!comecouSeguir) {

				Invoke ("seguePlayer", 1f);

			} else {

				transform.position = Vector3.Lerp (transform.position, playerTransform.position + offset, 5f * Time.deltaTime);

			}

			//Delay.construtorDelay (1f);



		} else {

			CancelInvoke ("seguePlayer");
			comecouSeguir = false;

			if (transform.position != playerTransform.position + offset) {

				transform.position = Vector3.Lerp (transform.position, playerTransform.position + offset, 2f * Time.deltaTime);

			} 


		}

	}

	// Use this for initialization
	void Start () {

		transform.position = playerPos.position + offset;
		//seguePlayer = false;

	}
	
	// Update is called once per frame
	void Update () {

		//Desativa o cursor e fixa-o no meio da tela
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		if (!lexBools.genioControl) {

			cameraFollow (playerPos, offset);

		} 

		else {

			cameraFollow (genioPos, offsetGenio);


		}
			

	}


	//Movimentação de câmera SEMPRE na void LateUpate, caso contrário, o player pode acabar se movimentando antes da câmera e a movimentação fica travada
	//A Late Update garante que todos os comandos da Update (neste e outros scripts) sejam executados para que não entrem em conflito com a rotação da câmera
	void LateUpdate(){

		//Perceba que esses valores não são do ângulo em si, mas sim incrementos. Por isso não pode-se utilizá-los diretamente no Quaternion.Euler
		//Ao lê-los com Debug.Log, podemos obsevar valores entre 0 e 4, baseados no movimento do mouse
		//Sempre que o mouse se movimenta um novo valor, que independe do anterior, é definido (os valores não são acumulados)
		//É como se fossem a força da rotação
		float verticalInput = Input.GetAxis ("Mouse Y") * RotationSpeed * Time.deltaTime;
		float horizontalInput = Input.GetAxis ("Mouse X") * RotationSpeed * Time.deltaTime;

		//Ângulos de rotação, serão sempre o valor que apresentam no momento com o acrescimo da força de rotação
		anguloY -= verticalInput; //O valor do verticalInput é invertido para que o jogador olhe para cima ao movimentar o mouse para baixo e vice/versa
		anguloX += horizontalInput;


		//A movimentação para cima/baixo é limitada, os valores-limite dos ângulos de rotação dependem do player estar mirando ou não

		//if (PlayerScript.Mira != 0) {

			//if (PlayerScript.isDead == false  && PlayerScript.canRotate == true) {

				//if (PlayerScript.armaSelecionada == 1) {

					//minY = -25;
					//maxY = 25;

				//} else {

					//minY = -4;
					//maxY = 4;

				//}


			//}
		//} 

		//else {

			minY = -50;
			maxY = 50;

		//}

		anguloY = Mathf.Clamp(anguloY, minY, maxY);

		transform.rotation = Quaternion.Euler (anguloY, anguloX, 0);

		//Fazer algo como abaixo não se demonstrou viável
		//Primeiramente, porque não seria possível limitar o ângulo, já que a rotação é incrementada de forma direta por verticalInput e horizontalInput, sem que os ângulos sejam definidos de forma absoluta
		//Em segundo lugar, esse trecho apresenta um comportamento distinto, já que em Quaternion.Euler o eixo y é sempre paralelo ao chão

		//transform.Rotate(Vector3.right, -verticalInput);
		//transform.Rotate(Vector3.up, horizontalInput); uma forma de solucionar o segundo ponto seria utilizando transform.Rotate(Vector3.right, -verticalInput, Space.Word);

		//Outra forma de revolver seria travando z em zero, adicionando as duas linhas comentadas abaixo,

		//Vector3 currentRotation = transform.eulerAngles;
		//transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);

		//Quanto ao primeiro ponto, é possível resolve-lo adicionando currentRotation.x = Mathf.Clamp(anguloY, minY, maxY); antes da ultima linha

		//Perceba que, solucionando o segundo ponto ao utilizar Space.Word, não seria necessário travar z em 0, pois o eixo y se manteria paralelo ao chão sem a necessidade disso
		//então a ultima linha ficaria

		//transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, current.rotation.z);

		//Mas eu só encontrei essas soluções agora, enquanto comentava esse código, então deixa como está... de qualquer forma, fica como uma alternativa ao código final :P



		//else {

			//seguePlayer = false;

		//}

		//Debug.Log (seguePlayer);

		//if (seguePlayer == true) {

			//transform.position = Vector3.Lerp(transform.position, playerPos.position + offset, 0.2f);

		//}

		//transform.position = playerPos.position + offset; //Não podemos esquecer que esse objeto vazio deverá seguir a posição do jogador. O único motivo para não utilizarmos o script diretamente no
		//player é o fato de que precisamos mudar sua rotação



	}

	void seguePlayer(){

		comecouSeguir = true;
		//transform.position = Vector3.Lerp(transform.position, playerPos.position + offset, 0.04f * Time.deltaTime);

	}


}
