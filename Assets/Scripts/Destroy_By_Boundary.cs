﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_By_Boundary : MonoBehaviour {

	void OnTriggerExit(Collider other){
		if (!other.gameObject.CompareTag ("Player")) {
			Destroy (other.gameObject);
		} else {
			Destroy (other.gameObject, 3.0f);
		}
	}

}
