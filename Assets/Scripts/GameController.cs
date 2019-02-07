using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController Instance = null;

	[SerializeField] Player player = null;
	[SerializeField] Transform playerSpawnTransform = null;
	[SerializeField] float deathZoneY = -50;
	[SerializeField] Text velocityText = null;
	[SerializeField] Text winText = null;

	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (
			player.transform.position.y <= deathZoneY
			|| Input.GetButtonDown("Restart")
		) {
			Restart();
		}

		velocityText.text = "SPEED: " + Mathf.Max((int)player.rigidbody.velocity.z, 0);
	}

	public void Restart() {
		player.transform.position = playerSpawnTransform.position;
		player.transform.rotation = Quaternion.identity;
		player.rigidbody.velocity = Vector3.zero;
		player.rigidbody.angularVelocity = Vector3.zero;
		winText.enabled = false;
	}

	public static void Win() {
		//Instance.Invoke("Restart", 5);
		Instance.winText.enabled = true;
	}
}
