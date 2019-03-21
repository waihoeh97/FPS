using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FPSMoveController : MonoBehaviour, IDragHandler, IEndDragHandler {

	[SerializeField] FPSCharacter fpsCharacter;
	RectTransform rect;
	Vector3 originPos;
	Vector3 direction;
	Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		rect = GetComponent<RectTransform>();
		originPos = this.rect.position;
	}

	public void OnDrag (PointerEventData eventData) 
	{
		//print ("Drag");
		rect.position = eventData.position;
		direction = this.rect.position - originPos;
		direction.Normalize();
	}

	public void OnEndDrag (PointerEventData eventData) 
	{
		rect.position = originPos;
		direction = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {
		moveDirection.x = direction.x;
		moveDirection.z = direction.y;
		fpsCharacter.Move(this.moveDirection);
	}
}
