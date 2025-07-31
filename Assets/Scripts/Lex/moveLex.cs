using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLex : MonoBehaviour {

	public Transform rotacaoCamera;

	GameObject spawnGen;

	Animator anim;

	public static bool Run;

	void lancaLampada(){

		spawnGen = Instantiate (GetComponent<lexHands> ().lamp, GetComponent<lexHands> ().lamp.transform.position, GetComponent<lexHands> ().lamp.transform.rotation, null);
		spawnGen.transform.localScale = new Vector3 (11.48698f, 11.48698f, 11.48698f);
		lexBools.pegouLamp = false;

		spawnGen.SetActive (true);
		//spawnGen.transform.parent = null;
		spawnGen.GetComponent<Rigidbody> ().isKinematic = false;
		spawnGen.GetComponent<BoxCollider> ().enabled = true;

		spawnGen.GetComponent<Rigidbody> ().AddForce (transform.forward * 20 + transform.up * 5, ForceMode.Impulse);

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

		if (lexBools.pegouLamp && Input.GetMouseButtonDown (0) && !lexBools.temGenio) {

			anim.SetBool ("Throw", true);
			Invoke ("lancaLampada", 0.32f);

			//Time.timeScale = 0.05f;

		}

		if (Input.GetKey(KeyCode.LeftControl)) {

			anim.SetBool ("Stealth", Run);

			if (Run) {

				anim.SetBool ("Run", !Run);
				lexBools.isStealth = true;

			} 

			else {

				anim.SetBool ("Run", Run);
				lexBools.isStealth = false;
			}
				

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
