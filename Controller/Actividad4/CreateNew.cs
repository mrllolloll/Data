using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DB;
using UnityEngine.SceneManagement;

public class CreateNew : ConexionDB {
	[Header("Objetivo titulo")]
	public GameObject AO;

	[Header("Texto generado")]
	public GameObject Texto;

	[Header("Panel que servira para respan")]
	public GameObject Respan;

	[Header("text field generado")]
	public InputField Field;
	[Header("Texto de puntos")]
	public GameObject puntos;
	[Header("strike")]
	public GameObject Strike;

	public int Numberfind;
	private string ObjetiveT;
	private string[] Option;
	private int Point=0;
	private void ToMostrarMessege(IEnumerable<Games> msg){
		foreach (var messege in msg) {

			Genera(messege.Mostrar());

		}
	}

	private void StrikeM(){
		if (GameObject.Find ("strike").transform.childCount >= 3) {
			SceneManager.LoadScene("Perder");
		} else {
			GameObject Error=(GameObject)Instantiate (Strike);
			Error.transform.parent = GameObject.Find("strike").transform;
			Error.transform.position= GameObject.Find("strike").transform.position;
		}
	}

	private void Genera (string[] msg){
		if (msg [3] == "4") {
			db.number = Int32.Parse(msg [2]);
			var OptB = db.ViewOptionInt();
			Point= Ponit (OptB,db.number.ToString());
			string[] Opt = ManejoInfoR (OptB,db.number.ToString()).Split('/');
			AO.GetComponent<Text>().text = Opt [0];
			Option = Opt;
			int Z = Opt.Length - 1;
			for (int I = 0; I < Z; I++) {
				int O = 1+I;
				GameObject Tex = (GameObject)Instantiate(Texto);
				Tex.transform.parent = Respan.transform;
				Tex.GetComponent<Text>().text=Opt[O];
				Tex.name="Text"+I.ToString ();

				if (Opt [O].IndexOf ("-") < 0) {
					InputField Fil = (InputField)Instantiate (Field);
					Fil.name = "Input"+I.ToString ();
					Fil.transform.parent = Respan.transform;
				} else {
					Tex.GetComponent<Text>().text=Opt[O].Replace("-","");
				}					
			}
			db.number = Int32.Parse(msg [1]);
			var ObtB = db.ViewObjectiveInt();
			string Obt = ManejoInfoR (ObtB,db.number.ToString());
			ObjetiveT = Obt+" ";
		}
	}

	public void Evaluate(){
		string evaluate = "";
		for (int I = 0; I < GameObject.FindGameObjectsWithTag("Objetive").Length; I++) {			
			GameObject Fiel= GameObject.Find ("Input"+I.ToString ());
			evaluate += Fiel.GetComponent<InputField> ().text+" ";
		}
		if (evaluate == ObjetiveT) {			
			GameObject.Find("EventSystem").transform.GetComponent<Timer>().StartTime+=10;
			int suma = Int32.Parse (puntos.GetComponent<Text> ().text) + Point;
			puntos.GetComponent<Text> ().text = suma.ToString();
			Destroy (GameObject.FindWithTag ("Destroystrike"));
			Destroyerd ();
			Reini ();
		} else {
			Handheld.Vibrate ();
			Destroyerd ();
			Reini ();
			StrikeM ();			
		}
	}

	private void Destroyerd(){
		int Z = Option.Length - 1;
		for (int I = 0; I < Z; I++) {
			int O = 1 + I;
			GameObject Fiel= GameObject.Find ("Input"+I.ToString ());
			GameObject text= GameObject.Find ("Text"+I.ToString ());
			Destroy (Fiel);
			Destroy (text);
		}
	}

	private void Reini(){
		db.number = Numberfind;
		var message = db.ViewGamesInt();
		ToMostrarMessege (message);
	}
	// Use this for initialization
	void Start () {
		Reini ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
