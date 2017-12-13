using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour {

	public SquareGrid squareGrid;

	public void GenerateMesh(int[,] map, float squareSize){
		squareGrid = new SquareGrid(map, squareSize);
	}
	public class SquareGrid{
		public Square[,] squares;
		public SquareGrid(int[,] map, float squareSize){
			int nodeCountX = map.GetLength(0);
			int nodeCountY = map.GetLength(1);
			float mapWidth = nodeCountX * squareSize;
			float mapHeight = nodeCountY * squareSize; 
		}
	}
	public class Square {
		public ControlNode topLeft, topRight, bottomRight, bottomLeft;
		public Node centerTop, centerRight, centerBottom, centerLeft;

		public Square (ControlNode _topLeft,ControlNode _topRight,ControlNode _bottomRight,ControlNode _bottomLeft){
			topLeft = _topLeft;
			topRight = _topRight;
			bottomRight = _bottomRight;
			bottomLeft = _bottomLeft;

			centerTop = topLeft.right;
		}
	}
	public class Node {
		public Vector3 position;
		public int vertexIndex = -1;
		public Node(Vector3 _pos){
			position = _pos;
		}
	}

	public class ControlNode : Node {
		public bool active;
		public Node above, right;
		
		public ControlNode(Vector3 _pos, bool _active, float squareSize) : base(_pos){
			active = _active;
			above = new Node(position + Vector3.forward * squareSize/2f);
			right = new Node (position + Vector3.right * squareSize/2);
		}
	}
	
}
