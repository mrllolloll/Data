using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivDesactiv : MonoBehaviour {

	[Header("tablon de mensajes")]
	public GameObject ObjetoDeJuego;

	public bool NoIniciarElemento;

	void Start () {
	
		if(NoIniciarElemento == true){
			this.Desactive ();
		}


	}


	public void ADtive(){
		if (ObjetoDeJuego.activeSelf) {
			this.Desactive();
		} else {
			this.Active ();
		}	
	}

	public void Active(){
		ObjetoDeJuego.SetActive (true);
	}

	public void Desactive(){
		ObjetoDeJuego.SetActive (false);
	}


}
