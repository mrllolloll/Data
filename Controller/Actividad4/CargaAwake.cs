using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaAwake : MonoBehaviour {

	public string WingEvent;

	void Awake() {		
		DontDestroyOnLoad (gameObject);
	}		

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Lose")==null) {

		}
	}
}
