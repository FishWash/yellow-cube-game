using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public new Rigidbody rigidbody = null;

	[SerializeField] float forwardForce = 2000f;
	[SerializeField] float sideForce = 500f;

	// Use this for initialization
	void Start() {
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		float _forwardInput = Input.GetAxis("Vertical");
		float _sideInput = Input.GetAxis("Horizontal");

		rigidbody.AddForce(Vector3.forward * _forwardInput * forwardForce * Time.deltaTime);
		rigidbody.AddForce(Vector3.right * _sideInput * sideForce * Time.deltaTime);
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, 100f);
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Win Zone")) {
			GameController.Win();
		}
	}
}
