using UnityEngine;
using System.Collections;

public class TargetMovementScript : MonoBehaviour {
	public float targetSpeed=9.0f; // Speed At Which the Object Should Move

	void Update () {
		transform.Translate (Input.GetAxis ("Horizontal")*Time.deltaTime*targetSpeed,Input.GetAxis ("Vertical")*Time.deltaTime*targetSpeed,0);

	}
}
