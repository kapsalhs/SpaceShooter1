﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_By_Contact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private Game_Controller gameController;

	void Start(){

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<Game_Controller> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find GameController Script");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary") {
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);


	}
}
