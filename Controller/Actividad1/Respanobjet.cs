using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using DB;

public class Respanobjet : ConexionDB {
	[Header("Strike")]
	public  GameObject Strike;

	[Header("Input field y button")]
	public InputField Field;

	[Header("text score")]
	public Text Score ;

	[Header("Empty generadores de modelos")]
	public GameObject ObjetoRespaw;

	// Use this for initialization
	[Header("objetos de juego a utilizar")]
	public GameObject ObjetoEnElJuego1;
	public GameObject ObjetoEnElJuego2;
	public GameObject ObjetoEnElJuego3;

	private string ObjetivoActual="";
	private int numberfind=3;
	private int Suma=0;
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

	private void Generate (GameObject obj){
		GameObject chul = (GameObject)Instantiate(obj);
		chul.transform.parent = ObjetoRespaw.transform;
		chul.transform.position= ObjetoRespaw.transform.position;
	}		

	private void Reini(){
		db.number = numberfind;
		var message = db.ViewGamesInt();
		ToMostrarMessege (message);
	}

	private void Genera(string[] msg){
		if (msg[3]=="1") {
			db.number = Int32.Parse(msg [1]);
			var ObtB = db.ViewObjectiveInt();
			string Obt = ManejoInfoR (ObtB,db.number.ToString());
			GameObject chull= null;
			Debug.Log (Obt);
			if (Obt=="Calculadora") {
				chull=ObjetoEnElJuego1;
			}else if (Obt=="Camara") {
				chull=ObjetoEnElJuego2;
			}else if(Obt=="it"){
				chull=ObjetoEnElJuego3;
			}
			Generate (chull);

			db.number = Int32.Parse(msg [2]);
			var Opn = db.ViewOptionInt();
			string OpnT= ManejoInfoR (Opn,db.number.ToString());
			Point = Ponit (Opn,db.number.ToString());
			ObjetivoActual = OpnT;
			Debug.Log (ObjetivoActual);
		}			
	}

	public void Evaluate(){
		if (ObjetivoActual==Field.text) {			
			Suma = Point + Int32.Parse(Score.text);
			Score.transform.GetComponent<Text> ().text = Suma.ToString ();
			GameObject.Find("EventSystem").transform.GetComponent<Timer>().StartTime+=10;
			Field.text = "";
			Reini ();
			
			Destroy (GameObject.FindWithTag ("Destroystrike"));	
			


		}else{
			if (Int32.Parse (Score.transform.GetComponent<Text> ().text) > 0) {
				Suma = Suma - 5;	
				Score.transform.GetComponent<Text> ().text = Suma.ToString ();
			}
			StrikeM();
			Field.text = "";
			Reini ();
		}
	}		

	public void Pasar(){		
		if (Int32.Parse(Score.transform.GetComponent<Text> ().text)>0) {
			Suma = Suma -5;	
			Score.transform.GetComponent<Text> ().text = Suma.ToString ();
		}
		Reini ();
	}

	void Start () {		
		Reini ();
	}	
}
