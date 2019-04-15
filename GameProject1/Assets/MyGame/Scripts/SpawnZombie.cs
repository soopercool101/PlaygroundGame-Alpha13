using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour {

	//public PlayerHealth mHealth;
	public GameObject mZombiePrefab;
	public float ZOMBIE_SPAWN_TIMER = 0f;
	public float ZOMBIE_SPAWN_RATE = 5f;

	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {
		Spawn ();
	}

	void Spawn(){
		int mZCount = 0;
		foreach (GameObject z in GameObject.FindGameObjectsWithTag("Zombie")) {
			mZCount++;		
		}
		if (mZCount >= 50) {
			ZOMBIE_SPAWN_TIMER = 0;
			return;
		}

		ZOMBIE_SPAWN_TIMER += Time.deltaTime;
		if (ZOMBIE_SPAWN_TIMER >= ZOMBIE_SPAWN_RATE) {
			//spawn
			GameObject mZombie = Instantiate(mZombiePrefab) as GameObject;
			Vector3 position = new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0);
			mZombie.transform.localPosition = position;

			ZOMBIE_SPAWN_TIMER = 0;
		}
	}
}
