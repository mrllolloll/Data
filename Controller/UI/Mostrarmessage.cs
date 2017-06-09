using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mostrarmessage : MonoBehaviour {

	[Header("Titulo")]
	public Text TextObjTitulo;//titulo
	[Header("Cuerpo de texto")]
	public Text TextObjCuepoDeTexto;//cuerpo de texto
	[Header("id de la noticia que se va a mostrar")]
	public int numberfind;//ID a buscar de mensajes
	[Header("La ventana que se esta utilizando")]
	public GameObject ventana;//y la ventana que se esta usando
	[Header("Opcion para no mostrar ventana en el juego despues de haber mostrado su mensaje")]
	public bool MostrarVentana;
	private DataService db = new DataService();

	void Start () {		
		//inicializando la base de datos
		//busqueda en la base de la base de datos (ID)
		db.number = numberfind;
		var message = db.ViewInfoint();
		ToMostrarMessege (message);

	}

	private void ToMostrarMessege(IEnumerable<Messegaealert> msg){
		foreach (var messege in msg) {			
			ToMostrarMessege(messege.Mostrar());
		}
	}

	private void ToMostrarMessege(string[] msg){
		
		if (msg [4] == "1") {
			TextObjCuepoDeTexto.text = "";
			TextObjTitulo.text = "";
			TextObjTitulo.text += msg [2];
			TextObjCuepoDeTexto.text += msg [3];
			Debug.Log (msg);
			int y;
			int.TryParse(msg[1], out y);
			Debug.Log (y);

			if (MostrarVentana == true) {
				db.Updatemessege (numberfind,y, msg [2], msg [3], 0);
			}

		} else {
			ventana.SetActive (false);
		}

	}

	public void CerrarVentana(){

		ventana.SetActive (false);

	}

}
	