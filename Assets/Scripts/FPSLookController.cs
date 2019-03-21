using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FPSLookController : MonoBehaviour, IDragHandler, IEndDragHandler {

	RectTransform rect;
	Vector3 originPos;
	Vector3 direction;
	float viewAngle = 0f;

	public Transform rootTransform;
	public Transform camTransform;

	// Use this for initialization
	void Start () {
		rect = this.GetComponent<RectTransform>();
		originPos = rect.position;
	}

	public void OnDrag (PointerEventData eventData)
	{
		this.rect.position = eventData.position;
		direction = rect.position - originPos;
		direction.Normalize();
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		this.rect.position = originPos;
		direction = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		// Convert x direction to y rotation
		rootTransform.Rotate(Vector3.up * direction.x * Time.deltaTime * 120f, Space.World);

		// Vertical look rotations
		viewAngle += -direction.y * Time.deltaTime * 90f;
		viewAngle = Mathf.Clamp(viewAngle, -40f, 30f);
		camTransform.localEulerAngles = new Vector3 (viewAngle, 0f, 0f);
	}
}
