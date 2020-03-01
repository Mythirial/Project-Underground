//I found this on the internet :3
using UnityEngine;
using System.Collections.Generic;
 
public class TerrainGen : MonoBehaviour {
	 
	// Reference to the mesh we will generate
	private Mesh mesh = null;
	 
	// The terrain points along the top of the mesh
	private Vector3[] points = null;
	 
	// Mutable lists for all the vertices and triangles of the mesh
	private List<Vector3> vertices = new List<Vector3>();
	private List<int> triangles = new List<int>();
	 
	void Start () {
		 
		// Get a reference to the mesh component and clear it
		MeshFilter filter = GetComponent<MeshFilter>();
		mesh = filter.mesh;
		mesh.Clear();
		 
		// Generate 4 random points for the top 
		points = new Vector3[4];
		for (int i = 0; i < points.Length; i++) {            
			points[i] = new Vector3(0.5f * (float)i, Random.Range(1f, 2f), 0f);
			AddTerrainPoint(points[i]);    
		}
		 
		// Assign the vertices and triangles to the mesh
		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
	}
	 
	void AddTerrainPoint(Vector3 point) {
		// Create a corresponding point along the bottom
		vertices.Add(new Vector3(point.x, 0f, 0f));
		// Then add our top point
		vertices.Add(point);
		if (vertices.Count >= 4) {
			// We have completed a new quad, create 2 triangles
			int start = vertices.Count - 4;
			triangles.Add(start + 0);
			triangles.Add(start + 1);
			triangles.Add(start + 2);
			triangles.Add(start + 1);
			triangles.Add(start + 3);
			triangles.Add(start + 2);    
		}
	}
}