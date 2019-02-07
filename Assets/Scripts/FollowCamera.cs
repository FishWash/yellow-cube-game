using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

	[SerializeField] GameObject followTarget = null;
	[SerializeField] Vector3 offsetVector = new Vector3(0, 0, -10f);
	[SerializeField] float lerpRatio = 0.3f;

	// Use this for initialization
	void Start () {
		// Instantly move behind followTarget
		if (followTarget == null) {
			Debug.Log(this.name + ": No followTarget selected");
		}
		if (followTarget != null) {
			transform.position = followTarget.transform.position + offsetVector;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Move smoothly toward destination behind followTarget
		if (followTarget == null) {
			Debug.Log(this.name + ": No followTarget selected");
		}
		if (followTarget != null) {
			Vector3 _destinationPosition = followTarget.transform.position + offsetVector;
			transform.position = Vector3.Lerp(transform.position, _destinationPosition, lerpRatio);
		}
	}
}
