using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refuel : MonoBehaviour {

	public float giveFuel;
	public GameObject playerExplosion;
	private Slider sliderValue;

	void Awake(){
		sliderValue = GameObject.Find ("Slider").GetComponent<Slider> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<PlayerController> ().fuelCounter += giveFuel;
			sliderValue.value += giveFuel;
			Destroy (gameObject);
		} 
		else if(!other.gameObject.CompareTag ("Boundary")) {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
