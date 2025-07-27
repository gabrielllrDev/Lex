using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLex : MonoBehaviour {

	public Transform rotacaoCamera;

	Animator anim;

	public static bool Run;

	void lancaLampada(){

		lexBools.pegouLamp = false;
		anim.SetBool ("Throw", false);

	}

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		float InputX = Input.GetAxisRaw ("Horizontal");
		float InputY = Input.GetAxisRaw ("Vertical");

		if (lexBools.pegouLamp && Input.GetMouseButtonDown (0)) {

			anim.SetBool ("Throw", true);
			Invoke ("lancaLampada", 0.32f);

			//Time.timeScale = 0.05f;

		}

		if (Input.GetKey(KeyCode.LeftControl)) {

			anim.SetBool ("Stealth", Run);
			lexBools.isStealth = true;

		} 

		else {

			anim.SetBool ("Stealth", false);
			anim.SetBool ("Run", Run);
			lexBools.isStealth = false;

		}
			

		if (InputX != 0 || InputY != 0) {

			Run = true;

		} 

		else {

			Run = false;

		}

		if (InputX > 0 && InputY == 0) {
			
			transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y + 90, 0), 5 * Time.deltaTime);

		}

		if (InputX < 0 && InputY == 0) {

			transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y - 90, 0), 5 * Time.deltaTime);

		}

		if (InputY > 0) {

			transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y , 0), 5 * Time.deltaTime);

			if (InputX > 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y + 45, 0), 5 * Time.deltaTime);

			}

			if (InputX < 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y - 45, 0), 5 * Time.deltaTime);

			}

		}

		if (InputY < 0) {

			transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y + 180, 0), 5 * Time.deltaTime);

			if (InputX > 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y - 225, 0), 5 * Time.deltaTime);

			}

			if (InputX < 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, rotacaoCamera.transform.eulerAngles.y  + 225, 0), 5 * Time.deltaTime);

			}

		}
		
	}
}
