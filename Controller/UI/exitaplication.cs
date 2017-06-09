using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitaplication : MonoBehaviour {

	// Update is called once per frame
	public void update(){
		if( Input.GetKey( KeyCode.Escape ) )
		{
			Application.Quit();
		}
	}
	public void exitbutton () {
		Application.Quit(); 
	}
}
