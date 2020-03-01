using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {

	public Camera cam;
	[Range(1, 10)]public float hitRange;

	void Update () {
		if (Input.GetMouseButton (0)) {
			RaycastHit hit;
			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, hitRange, 1 << 8)) {
				MeshEditor editor = hit.transform.GetComponent<MeshEditor> ();
				editor.EditOnPoint (hit.point, cam.transform.forward, 0.2f, 2f);
				Debug.Log (hit.collider);
			}
			Debug.DrawRay (cam.transform.position, cam.transform.forward * hitRange, Color.red);
		}
		Debug.DrawRay (cam.transform.position, cam.transform.forward * hitRange, Color.white);
	}
}
