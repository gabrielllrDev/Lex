using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLex : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		float InputX = Input.GetAxisRaw ("Horizontal");
		float InputY = Input.GetAxisRaw ("Vertical");

		if (InputX != 0 || InputY != 0) {

			anim.SetBool ("Run", true);

		} 

		else {

			anim.SetBool ("Run", false);

		}

		if (InputX > 0 && InputY == 0) {

			transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, 90, 0), 5 * Time.deltaTime);

		}

		if (InputX < 0 && InputY == 0) {

			transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, -90, 0), 5 * Time.deltaTime);

		}

		if (InputY > 0) {

			transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, 0, 0), 5 * Time.deltaTime);

			if (InputX > 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, 45, 0), 5 * Time.deltaTime);

			}

			if (InputX < 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, -45, 0), 5 * Time.deltaTime);

			}

		}

		if (InputY < 0) {

			transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, 180, 0), 5 * Time.deltaTime);

			if (InputX > 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, -225, 0), 5 * Time.deltaTime);

			}

			if (InputX < 0) {

				transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.Euler (0, 225, 0), 5 * Time.deltaTime);

			}

		}
		
	}
}
