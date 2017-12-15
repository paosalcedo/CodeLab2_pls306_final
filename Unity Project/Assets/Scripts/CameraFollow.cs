using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	float t;
	Camera camera;
	FPSController player;
	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
		player = FindObjectOfType<FPSController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(camera.WorldToScreenPoint(player.transform.position).x < Screen.width * 0.49f 
		|| camera.WorldToScreenPoint(player.transform.position).x > Screen.width * 0.51f
		|| camera.WorldToScreenPoint(player.transform.position).y < Screen.height * 0.49f
		|| camera.WorldToScreenPoint(player.transform.position).y > Screen.height * 0.51f
		){
			t += 0.002f * Time.deltaTime;
			transform.position = new Vector3(Mathf.Lerp(transform.position.x, player.transform.position.x, t), transform.position.y, Mathf.Lerp(transform.position.z, player.transform.position.z, t));
		}
	}
}
