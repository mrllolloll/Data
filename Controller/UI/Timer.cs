using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {

	public Text TimerText;
	public float StartTime;
	// Use this for initialization
	void Start () {

		StartTime = 20;

	}
	
	// Update is called once per frame
	void Update () {
		if (TimerText.text != "0") {
			StartTime = StartTime - 1 * Time.deltaTime;
			TimerText.text = "" + StartTime.ToString ("f0");	
		} else {
			SceneManager.LoadScene ("Perder");
		}

	}
}
