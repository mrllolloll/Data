using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DB;

public class CreaterNew : ConexionDB {

	[Header("Target de Opciones")]
	public int FindInt=1;
	public GameObject Target;

	private void ManejoInfo(IEnumerable<Games> msg){
		foreach (var messege in msg) {
			Trasfornmer(messege.Mostrar ());
		}	
	}

	private void Trasfornmer(string[] msg){

		if (msg[3]=="3") {
			db.number = Int32.Parse(msg [2]);
			var OptB = db.ViewOptionInt();
			string[] Opt = ManejoInfoR (OptB,db.number.ToString()).Split('/');
			for (int i = 0; i < Opt.Length; i++) {
				
			}

		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
