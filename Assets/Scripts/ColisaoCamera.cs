using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoCamera : MonoBehaviour {

	public Transform target; //Objeto vazio, pai, que é responsável pelo controle de rotação da câmera
	RaycastHit hit = new RaycastHit();

	int layermask;

	public float ajusteCamera; //Sensibilidade de ajuste da câmera ao colidir com algum obstáculo
	public float distCam; //Distância da câmera ao target/boneco
	//public Vector3 offset; //Ajuste da altura da câmera

	Camera essaCamera;
	Vector3 informacoes; //Armazena o valor do zoom, e os offsets x e y (respectivamente)
	public float zoomVelocity = 5;

	// Use this for initialization
	void Start () {

		essaCamera = GetComponent<Camera> ();
		informacoes = new Vector3 (60f, 0f, 2.3f);
		//PlayerScript.Mira = 0;
		layermask = ~(1 << LayerMask.NameToLayer ("Player"));
		
	}
	
	// Update is called once per frame
	void Update () {

		essaCamera.fieldOfView = informacoes.x;
		//offset.x = informacoes.y;
		//offset.y = informacoes.z;

		//if (PlayerScript.Mira != 0) {

			//if (PlayerScript.isDead == false && PlayerScript.canRotate == true) {

				//if (PlayerScript.armaSelecionada == 1) {

					//informacoes = Vector3.Lerp(informacoes, new Vector3 (35f, 5.22f, 4.56f), zoomVelocity * Time.deltaTime);

				//}

				//if (PlayerScript.armaSelecionada == 2) {

					//informacoes = Vector3.Lerp(informacoes, new Vector3 (20f, 2.22f, 4.56f), zoomVelocity * Time.deltaTime);

				//}

				//if (PlayerScript.armaSelecionada == 3) {

				//	informacoes = Vector3.Lerp(informacoes, new Vector3 (20f, 3.22f, 4.56f), zoomVelocity * Time.deltaTime);

				//}

			//}


		//} 

		//if(moveLex.Run == true){

		//	informacoes = Vector3.Lerp(informacoes, new Vector3 (80f, 0f, 0f), zoomVelocity * Time.deltaTime);

		//}

		//else {

			informacoes = Vector3.Lerp(informacoes, new Vector3 (60f, 0f, 2.3f), zoomVelocity * Time.deltaTime);

		//}


	}

	void LateUpdate(){

		//Se nenhuma colisão for detectada, a posição da câmera será essa
		//transform.forward equivale ao eixo z (para frente/trás)
		//A Câmera estará a uma distância distCam atrás do personagem/alvo
		//transform.up equivale ao eixo Y, offset ajusta/corrige a altura da câmera em relação ao personagem
		//transform.righ equivale ao eixo x (direita/esquerda), este offset irá mudar quando o player estiver mirando
		transform.position = target.position - transform.forward * distCam;

		//transform.position = target.position - transform.forward * distCam + transform.up * offset.y + transform.right * offset.x;


		if (Physics.Linecast (target.position, transform.position, out hit, layermask)) {

			transform.position = hit.point + transform.forward * ajusteCamera;

		}

	}
}
