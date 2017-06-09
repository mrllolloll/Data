using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sol : MonoBehaviour {
	public GameObject sol;
	public bool Switch;
	public float Intensity;
	// Use this for initialization
	void Start () {
		sol.SetActive(Switch);
	}

}
