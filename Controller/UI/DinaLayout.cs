using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DinaLayout : MonoBehaviour
{
	public int col, row;
	// Use this for initialization
	void Start ()
	{
		RectTransform parent = gameObject.GetComponent<RectTransform> ();
		GridLayoutGroup grid = gameObject.GetComponent<GridLayoutGroup> ();	

		if (Screen.width==480&Screen.height==320) {
			grid.spacing = new Vector2 (80,40);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

