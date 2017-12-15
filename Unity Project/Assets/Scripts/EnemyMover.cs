using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {
	Rigidbody rb;
	EnemyManager enemyManager;
	int direction;
	Vector3 randomDir;
	int[] directions = {-1, 1};
	// Use this for initialization
	void Start () {
		enemyManager = FindObjectOfType<EnemyManager>();
		direction = directions[Random.Range(0,2)];
		randomDir = new Vector3(Random.insideUnitCircle.x,0,Random.insideUnitCircle.y);
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// rb.AddForce(transform.forward * 100f * Time.deltaTime);
		transform.position += transform.forward * 3 * direction * Time.deltaTime;
		if(transform.position.y < -100){
			enemyManager.enemies.Remove(this.gameObject);
			this.gameObject.SetActive(false);
		}
	}

	void OnCollisionEnter(Collision coll){
		Debug.Log(coll.gameObject.name);
		// if(!coll.gameObject.name.Contains("Map")){
		direction *= -1;
		transform.eulerAngles = new Vector3(0, Random.Range(45,90),0);
		// }
 	}
}
