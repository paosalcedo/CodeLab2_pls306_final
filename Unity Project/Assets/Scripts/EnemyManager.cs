using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	public List<GameObject> enemies = new List<GameObject>();
	public int maxEnemies;

	MapGenerator mapGenerator;
	// Use this for initialization
	public void Start () {
		mapGenerator = FindObjectOfType<MapGenerator>();
		maxEnemies = Random.Range(10,30);
		for(int i = 0; i<maxEnemies; i++){
			GameObject food = Instantiate(Resources.Load("food"), new Vector3 (i+Random.Range(0, 50), -4, i+Random.Range(0,50)), Quaternion.identity) as GameObject;
			enemies.Add(food);
		}
	}

	void Update(){
		if(enemies.Count <= 0){
			mapGenerator.GenerateMap();
			maxEnemies = Random.Range(10,30);
			for(int i = 0; i<maxEnemies; i++){
				GameObject food = Instantiate(Resources.Load("food"), new Vector3 (i+Random.Range(0, 50), -4, i+Random.Range(0,50)), Quaternion.identity) as GameObject;
				enemies.Add(food);
			}		
		}
	}
	
	// Update is called once per fram
}
