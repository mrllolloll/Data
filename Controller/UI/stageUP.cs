using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stageUP : MonoBehaviour {

	public void Cambiostage(string scene){
		SceneManager.LoadScene(scene);
	}

}
