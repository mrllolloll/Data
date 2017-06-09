using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respanobjet : MonoBehaviour {

	[Header("Empty generadores de modelos")]
	public GameObject ObjetoRespaw;
	public GameObject ObjetoRespaw1;
	public GameObject ObjetoRespaw2;
	// Use this for initialization
	[Header("objetos de juego a utilizar")]
	public GameObject ObjetoEnElJuego1;
	void Start () {
		//creando un objeto de juego que tiene como padre un empty
		GameObject chul = (GameObject)Instantiate (ObjetoEnElJuego1);
		chul.transform.parent = ObjetoRespaw.transform;
		chul.transform.position= ObjetoRespaw.transform.position;
		//.....
	}
	
	// Update is called once per frame
	void Update () {

	}
		

}
