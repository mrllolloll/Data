using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text TimerText;
	private float StartTime;
	// Use this for initialization
	void Start () {
		StartTime = 60;
	}
	
	// Update is called once per frame
	void Update () {
		float t = StartTime - Time.time;
		string Minutos =((int)t /60).ToString();
		string Segundos =((int)t % 60).ToString("f0");
		TimerText.text = Minutos + ":" + Segundos;

	}
}
