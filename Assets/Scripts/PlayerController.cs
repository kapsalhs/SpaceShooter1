using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary{
	
	public float xMin,xMax,zMin,zMax,yMin,yMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float firerate;
	public float timeFuel;
	public float fuelCounter;
	public Slider sliderValue;

	private float nextFire;
	private float timer = 0.0f;

	void Update(){
		timer += Time.deltaTime;
		if (timer >= timeFuel) {
			fuelCounter -= 1;
			sliderValue.value -= 1;
			timer = 0.0f;
		}
		if (fuelCounter <= 0) {
			EmptyFuel ();
		}
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + firerate;
	//		GameObject clone = 
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play ();
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody> ().velocity = movement * speed;
		GetComponent<Rigidbody> ().position = new Vector3 (Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax), Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	void EmptyFuel(){
		//gameObject.GetComponent<Rigidbody> ().useGravity = true;
		//gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		gameObject.transform.Translate (-Vector3.up * speed * Time.deltaTime);
	}
}
