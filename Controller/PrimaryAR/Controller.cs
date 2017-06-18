using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DB;
using UnityEngine.SceneManagement;

public class Controller : ConexionDB {

	public void Evaluate(){

		if (Input.GetMouseButton(0)==true) {

			Debug.Log ("sasdadasdsa");

		}

	}

	void Update () {
		Evaluate ();
	}
}
