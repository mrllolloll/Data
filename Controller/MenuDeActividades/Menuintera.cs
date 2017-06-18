using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DB;
public class Menuintera : ConexionDB {



	private void ToMostrarMessege(IEnumerable<Activities> msg){
		foreach (var messege in msg) {
			
			Genera(messege.Mostrar());

		}
	}

	private void Genera (string[] msg){

		GameObject Nivel= GameObject.Find (msg[1]);
		if (msg [2] == "1") {
			Nivel.GetComponent<Button> ().interactable = true;
		} else {
			Nivel.GetComponent<Button> ().interactable = false;
		}

	}
		

	// Use this for initialization
	void Start () {
		var message = db.ViewActivitiesAll();
		ToMostrarMessege (message);
	}

}
