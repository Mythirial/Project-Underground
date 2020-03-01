using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshEditor : MonoBehaviour {

	Mesh mesh;
	MeshCollider coll;

	public Vector3[] vertices; 

	void Start() {
		mesh = GetComponent<MeshFilter> ().mesh;
		coll = GetComponent<MeshCollider> ();
		vertices = mesh.vertices;
	}

	public void EditOnPoint(Vector3 point, Vector3 direction, float effectRadius, float strength) {
		Debug.Log (point);
		for (int i = 0; i < vertices.Length; i++) {
			if (Vector3.Distance (point, transform.TransformPoint(vertices[i])) < effectRadius) {
				vertices[i] += transform.InverseTransformPoint(direction) * strength;
			}
		}

		mesh.vertices = vertices;
		mesh.RecalculateBounds ();

		coll.sharedMesh = null;
		coll.sharedMesh = mesh;
	}
}
