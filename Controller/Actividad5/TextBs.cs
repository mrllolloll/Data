using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DB;
using UnityEngine.SceneManagement;

public class TextBs : ConexionDB {
	[Header("score text")]
	public Text Score;
	[Header("Texto objetivo")]
	public Text TextObjetivo;
	[Header("button generado")]
	public GameObject ButtonG;
	[Header("Panel")]
	public GameObject Panel;
	[Header("numero a buscar")]
	public int  FindInt;
	[Header("game object de strike")]
	public GameObject Strike;

	private string Objetivo;
	private int Suma=0;
	private int Point;
	private string[] Option= new string[100];
	private void ManejoInfo(IEnumerable<Games> msg){
		foreach (var messege in msg) {
			CambioText(messege.Mostrar ());
		}	
	}


	private void CambioText(string[] msg){

		if(msg[3]=="5"){
			db.number = Int32.Parse(msg [2]);
			var OptB = db.ViewOptionInt();
			string[] Opt = ManejoInfoR (OptB,db.number.ToString()).Split('/');
			Point = Ponit (OptB,db.number.ToString());
			int	Z = Opt.Length - 1;
			TextObjetivo.text = Opt [0];
			for (int i = 0; i < Z; i++) {
				int O = i+ 1;
				GameObject button = (GameObject)Instantiate(ButtonG);
				button.name = "but" + i;
				button.GetComponent<Button>().onClick.AddListener(delegate{evaluate(button);});
				button.transform.parent = Panel.transform;
				button.transform.GetChild(0).GetComponent<Text> ().text = Opt [O];
				Option [i] = Opt [O];
			}
			db.number = Int32.Parse(msg [1]);
			var ObtB = db.ViewObjectiveInt();
			Objetivo = ManejoInfoR (ObtB,db.number.ToString());
			Debug.Log (ManejoInfoR (ObtB,db.number.ToString()));
		}
	}

	public void evaluate(GameObject but){
		if (Objetivo == but.transform.GetChild(0).GetComponent<Text>().text) {
			Suma = Point + Int32.Parse(Score.text);
			Score.transform.GetComponent<Text> ().text = Suma.ToString ();
			GameObject.Find("EventSystem").transform.GetComponent<Timer>().StartTime+=10;
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

	private void StrikeM(){
		if (GameObject.Find ("strike").transform.childCount >= 3) {
			SceneManager.LoadScene("Perder");
		} else {
			GameObject Error=(GameObject)Instantiate (Strike);
			Error.transform.parent = GameObject.Find("strike").transform;
			Error.transform.position= GameObject.Find("strike").transform.position;
		}
	}

	private void Destroyerd(){		
		for (int I = 0; I < Option.Length; I++) {
			int O = 1 + I;
			GameObject butt= GameObject.Find ("but"+I.ToString ());
			Destroy (butt);
		}
	}

	private void Reini(){
		Debug.Log (Objetivo);
		db.number = UnityEngine.Random.Range(10,18);
		var InitGame = db.ViewGamesInt ();
		ManejoInfo (InitGame);
	}


	// Use this for initialization
	void Start () {
		Reini ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
