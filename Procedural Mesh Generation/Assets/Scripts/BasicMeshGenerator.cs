using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMeshGenerator : MonoBehaviour {
	Mesh mesh;
	Vector3[] myVertices;
	[SerializeField] float speed = 90f;
	// Use this for initialization
	void Start () {
		mesh = new Mesh();
		//assign points

		Vector3[] vertices = new Vector3[3];
		vertices[0] = new Vector3(-1, -1, 0);
		vertices[1] = new Vector3(0, 0.8f, 0);
		vertices[2] = new Vector3(1, -1, 0);
		mesh.vertices = vertices;

		int[] triangles =  new int[3] {0, 1, 2};
		mesh.triangles = triangles;

		GetComponent<MeshFilter>().mesh = mesh; 

		Vector3[] normals = new Vector3[3];
		normals[0] = Vector3.back; 
		normals[1] = Vector3.back; 
		normals[2] = Vector3.back;
		mesh.normals = normals;
		myVertices = vertices;
	}
	
	// Update is called once per frame
	void Update () {
		// GenerateTriangles();
		
 	}

	void GenerateTriangles(){
		int width = 1;
		int[] triangles_ = new int[(width - 1) * (width-1) * 6];
		int triangleIndex = 0;
		for (int x = 0; x < width - 1; x++){
			for (int y = 0; y < width - 1; y++)
			{
				int vertexIndex = x * width + y;
				
				triangles_[triangleIndex + 0] = vertexIndex;
				triangles_[triangleIndex + 1] = vertexIndex + width;
				triangles_[triangleIndex + 2] = vertexIndex + width + 1;
				triangles_[triangleIndex + 3] = vertexIndex; 
				triangles_[triangleIndex + 4] = vertexIndex + width + 1;
				triangles_[triangleIndex + 5] = vertexIndex + 1;

				triangleIndex += 6;
			}
		}

		mesh.triangles = triangles_;
	}
}
