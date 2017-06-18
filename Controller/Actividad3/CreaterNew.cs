using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using DB;

public class CreaterNew : ConexionDB {
	[Header("strike")]
	public  GameObject Strike;
	[Header("Target de Opciones")]
	public int FindInt=4;
	[Header("Text score")]
	public Text Score;
	[Header("Titulo de la pregunta")]
	public GameObject Infor;
	[Header("Opciones")]
	public GameObject Obj1;
	public GameObject Obj2;
	public GameObject Obj3;

	private string[] OpT;
	private string ObjT="";
	private int Suma =0;
	private int Point=0;

	private void StrikeM(){
		if (GameObject.Find ("strike").transform.childCount >= 3) {
			SceneManager.LoadScene("Perder");
		} else {
			GameObject Error=(GameObject)Instantiate (Strike);
			Error.transform.parent = GameObject.Find("strike").transform;
			Error.transform.position= GameObject.Find("strike").transform.position;
		}
	}

	private void ManejoInfo(IEnumerable<Games> msg){
		foreach (var messege in msg) {
			Trasfornmer(messege.Mostrar ());
		}	
	}
	private void reshuffle(string[] texts)
	{
		for (int t = 0; t < texts.Length; t++ )
		{
			string tmp = texts[t];
			int r = UnityEngine.Random.Range(t, texts.Length);
			texts[t] = texts[r];
			texts[r] = tmp;
		}
	}

	private void Trasfornmer(string[] msg){		
		if (msg[3]=="3") {
			db.number = Int32.Parse(msg [2]);
			var OptB = db.ViewOptionInt();
			Point = Ponit (OptB,db.number.ToString());
			string[] Opt = ManejoInfoR (OptB,db.number.ToString()).Split('/');
			 OpT = new string[]{ Opt[1],Opt[2],Opt[3]};
			Infor.transform.GetComponent<UnityEngine.UI.Text>().text = Opt [0];
			int yot = 0;

			reshuffle (OpT);

			Obj1.transform.GetComponent<UnityEngine.UI.Text>().text = OpT [0];
			Obj2.transform.GetComponent<UnityEngine.UI.Text>().text = OpT [1];
			Obj3.transform.GetComponent<UnityEngine.UI.Text>().text = OpT [2];

			db.number = Int32.Parse(msg [1]);
			var Objt = db.ViewObjectiveInt();
			ObjT = ManejoInfoR (Objt,db.number.ToString());

		}
	}

	public void evaluate(GameObject Eval){

		if (Eval.transform.GetComponent<UnityEngine.UI.Text> ().text == ObjT) {			
			Suma = Point + Int32.Parse(Score.text);
			Score.transform.GetComponent<Text> ().text = Suma.ToString ();
			GameObject.Find("EventSystem").transform.GetComponent<Timer>().StartTime+=10;
			Destroy (GameObject.FindWithTag("Destroystrike"));
		} else {
			if (Int32.Parse (Score.transform.GetComponent<Text> ().text) > 0) {
				Suma = Suma - 5;
				Score.transform.GetComponent<Text> ().text = Suma.ToString ();
			}
			StrikeM ();
			Handheld.Vibrate ();
		}
		Reini ();
	}


	private void Reini(){
		db.number = FindInt;
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
