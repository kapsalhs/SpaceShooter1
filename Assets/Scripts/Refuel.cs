using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refuel : MonoBehaviour {

	public float giveFuel;
	public GameObject playerExplosion;
	public GameObject take_fuel;
	private Slider sliderValue;
	private GameObject remove_tank;
	private float sec = 0.5f;

	void Awake(){
		sliderValue = GameObject.Find ("Slider").GetComponent<Slider> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<PlayerController> ().fuelCounter = 20;
			sliderValue.value = 20;
			Instantiate (take_fuel, other.transform.position, other.transform.rotation);
			Destroy (gameObject);

		} 
		else if(!other.gameObject.CompareTag ("Boundary")) {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}

}
