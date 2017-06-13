using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DB;
public class TextBs : ConexionDB {

	public Text TextOject; 
	public int  FindInt;

	private void ManejoInfo(IEnumerable<Games> msg){
		foreach (var messege in msg) {
			CambioText(messege.Mostrar ());
		}	
	}


	public void CambioText(string[] msg){

		if(msg[3]=="5"){
			db.number = Int32.Parse(msg [1]);
			var OptB = db.ViewObjectiveInt();
			string Opt = ManejoInfoR (OptB,db.number.ToString());
			TextOject.text = Opt;

		}
	}

	// Use this for initialization
	void Start () {
		db.number = FindInt;
		var InitGame = db.ViewGamesInt ();
		ManejoInfo (InitGame);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
