using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genioControl : MonoBehaviour {

	public Vector3 offset; //Corrige a Rotação
	public Vector3 offsetPlayer; //Corrige Posição em relação ao Player
	public Transform Player;

	public float moveSpeed = 5f;
	bool comecouSeguir = false;
	bool primeiraSeguida;

	public Transform rotacaoCamera;
	float rotacaoLimitada;

	float anguloZ;

	// Use this for initialization
	void Start () {

		primeiraSeguida = false;
		lexBools.temGenio = true;
		CameraScript.genioPos = this.transform;

		
	}
	
	// Update is called once per frame
	void Update () {

		float InputX = Input.GetAxisRaw ("Horizontal");
		float InputY = Input.GetAxisRaw ("Vertical");

		float horizontalInput = Input.GetAxis ("Mouse X") * 500f * Time.deltaTime;
		anguloZ += horizontalInput;

		anguloZ = Mathf.Clamp (anguloZ, -90, 90);

		if (!lexBools.genioControl) {

			transform.LookAt (Player);
			transform.rotation = transform.rotation * Quaternion.Euler (offset);

			if (moveLex.Run) {

				if (!comecouSeguir) {

					Invoke ("followLex", 1.5f);

				} else {

					transform.position = Vector3.Lerp (transform.position, Player.position + Player.TransformDirection (offsetPlayer), 4f * Time.deltaTime);

				}


				//followLex ();

				/////moduloDelay (1.5f, followLex);
			} else {

				CancelInvoke ("followLex");
				comecouSeguir = false;

				if (transform.position != Player.position + Player.TransformDirection (offsetPlayer) && primeiraSeguida) {

					transform.position = Vector3.Lerp (transform.position, Player.position + Player.TransformDirection (offsetPlayer), 2f * Time.deltaTime);
				} 

			}

		} 

		else {

			//Controle de movimentação do Genio
			if (moveLex.Run) {

				transform.position = transform.position + transform.TransformDirection(Vector3.forward * moveSpeed * Time.deltaTime);

			}

			if (Input.GetKey (KeyCode.Space)) {

				transform.position = transform.position + Vector3.up * moveSpeed * Time.deltaTime;

			}

			if (Input.GetKey (KeyCode.LeftShift)) {

				transform.position = transform.position - Vector3.up * moveSpeed * Time.deltaTime;

			}

			if (Input.GetKeyDown (KeyCode.LeftControl)) {

				moveSpeed += 10;

			}

			if (Input.GetKeyUp (KeyCode.LeftControl)) {

				moveSpeed -= 10;

			}

			if (Input.GetKey (KeyCode.LeftControl) && InputY > 0 && InputX == 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (rotacaoCamera.transform.eulerAngles.x, rotacaoCamera.transform.eulerAngles.y, -anguloZ), 5 * Time.deltaTime);

			}

			if (Mathf.Abs(horizontalInput) < 0.01f) {
				
				anguloZ = Mathf.Lerp(anguloZ, 0, 5f * Time.deltaTime);

			}

			if ((transform.localEulerAngles.z > 45 || transform.localEulerAngles.z < -45)  && InputX != 0 && InputY != 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y, -anguloZ), 5 * Time.deltaTime);

			}


			if (InputX > 0 && InputY == 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y + 90, -anguloZ), 5 * Time.deltaTime);

			}

			if (InputX < 0 && InputY == 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y - 90, -anguloZ), 5 * Time.deltaTime);

			}

			if (InputY > 0) {

				if (InputX == 0) {

					transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y, -anguloZ), 5 * Time.deltaTime);

				}

				if (InputX > 0) {

					transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y + 45, -anguloZ), 5 * Time.deltaTime);

				}

				if (InputX < 0) {

					transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y - 45, -anguloZ), 5 * Time.deltaTime);

				}

			}

			if (InputY < 0) {

				if (InputX == 0) {

					transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y + 180, -anguloZ), 5 * Time.deltaTime);

				}

				if (InputX > 0) {

					transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y - 225, 0), 5 * Time.deltaTime);

				}

				if (InputX < 0) {

					transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y + 225, 0), 5 * Time.deltaTime);

				}

			}

			if (InputY == 0 && InputX == 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (rotacaoCamera.transform.eulerAngles.x, rotacaoCamera.transform.eulerAngles.y, 0), 5 * Time.deltaTime);

			}


		}

		if (Input.GetKeyDown (KeyCode.C)) {

			lexBools.genioControl = !lexBools.genioControl;

		}


	}

	void LateUpdate(){



	}

	void followLex(){

		comecouSeguir = true;
		primeiraSeguida = true;

	}
}
