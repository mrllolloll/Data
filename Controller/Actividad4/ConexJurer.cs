using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DB;

public class ConexJurer : ConexionDB {

	[Header("Numero a buscar en la base de datos")]
	public int FindInt;

	[Header("Contenedor de arriba Arriba")]
	public GameObject PanelArriba;

	[Header("Contenedor de abajo")]
	public GameObject Panelcont;

	[Header("Slot")]
	public GameObject PanelSlot;

	[Header("Imagen")]
	public GameObject Img;

	[Header("Texto")]
	public Text decir;

	[Header ("Score")]
	public Text Score;


	private int NumberSlot;
	private string Objetivo;
	private int ScoreSum=0;
	private int Cont=0;
	private void ManejoInfo(IEnumerable<Games> msg){
		foreach (var messege in msg) {
			ManejoInfo(messege.Mostrar ());
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

	private void ManejoInfo (string[] msg){
		if (msg[3]=="4") {
			db.number = Int32.Parse(msg [2]);
			var OptB = db.ViewOptionInt();
			string[] Opt = ManejoInfoR (OptB,db.number.ToString()).Split('_');
			ScoreSum= Ponit(OptB,db.number.ToString());
			reshuffle (Opt);
			for (int I = 0; I < Opt.Length; I++) {
				GameObject Slot = (GameObject)Instantiate(PanelSlot);
				GameObject instan = (GameObject)Instantiate (Img);
				Text Texto = (Text)Instantiate (decir);
				instan.name = "img" +I.ToString();
				Slot.name = "base"+I.ToString();
				Texto.name = "texto";
				Slot.transform.parent = Panelcont.transform;
				instan.transform.parent = Slot.transform;
				Texto.transform.parent = instan.transform;
				Texto.text = Opt[I] ;
				Debug.Log (ScoreSum.ToString());
			}
			NumberSlot = Opt.Length;
			db.number = Int32.Parse(msg [1]);
			var ObjT = db.ViewObjectiveInt ();
			Objetivo= ManejoInfoR(ObjT,db.number.ToString());
			string[] Obt = Objetivo.Split(' ');
			for (int i = 0; i < Obt.Length; i++) {
				GameObject Slot0 = (GameObject)Instantiate(PanelSlot);
				Slot0.transform.parent = PanelArriba.transform;
				Slot0.name = "slot"+i.ToString();
				Slot0.tag="Objetive";
			}

		}
	}
		
	private void DeleteGO(GameObject Var){	
		foreach (Transform children in Var.transform) {
			Destroy (children.gameObject);
		}
	}
	private void Reini(){
		db.number = FindInt;
		var InitGame = db.ViewGamesInt ();
		ManejoInfo (InitGame);
		Cont = 0;
	}


	void Start(){
		Reini ();
	}
		

	void Update(){
		string  Concurr="";
		for (int i = 0; i <NumberSlot ; i++) {
			GameObject Hol = GameObject.Find("slot" + i.ToString());
			if (Hol.transform.childCount != 0) {
				string mostr = Hol.transform.GetChild (0).GetComponentInChildren<UnityEngine.UI.Text> ().text;
				if (Concurr.IndexOf (" " + mostr) > 0) {
					Concurr.Replace (" " + mostr, "");
				}
				Concurr += " " + mostr;
				Cont++;
			} else {
				if (Cont != 0) {
					Cont--;
				}
			}
			Debug.Log (Concurr);
			Debug.Log (Objetivo);



			if (Concurr == " " + Objetivo | " " + Concurr == " " + Objetivo | Concurr == Objetivo | " " + Concurr == Objetivo | Concurr == Objetivo + " ") {	
				DeleteGO (PanelArriba);
				DeleteGO (Panelcont);
				Reini ();
				int suma = Int32.Parse (Score.text);
				suma = suma + ScoreSum;
				Debug.Log (ScoreSum.ToString ());
				Score.text = suma.ToString ();
				GameObject.Find ("EventSystem").GetComponent<Timer> ().StartTime = GameObject.Find ("EventSystem").GetComponent<Timer> ().StartTime + 10;
			}			
		}
	}
}