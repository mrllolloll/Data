using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Movimientoycollisones : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler {
	public static GameObject drager;
	Vector3 PositionStart;
	Transform starparet;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		drager = gameObject;
		PositionStart = transform.position;
		starparet = transform.parent;

		GetComponent<CanvasGroup>().blocksRaycasts = false;

		drager.GetComponent<LayoutElement>().ignoreLayout = true;	

		drager.transform.SetParent(drager.transform.parent.parent);
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
			transform.position = Input.mousePosition;			
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		drager = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if(transform.parent == starparet){
			transform.position = PositionStart;
		}

		drager.GetComponent<LayoutElement> ().ignoreLayout = false;
	
	}

	#endregion



}
