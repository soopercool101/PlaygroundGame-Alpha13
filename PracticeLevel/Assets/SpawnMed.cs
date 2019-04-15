using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMed : MonoBehaviour {

	public GameObject mMedPrefab;
	public float MED_SPAWN_TIMER = 0f;
	public float MED_SPAWN_RATE = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Spawn ();
	}

	void Spawn(){
		MED_SPAWN_TIMER += Time.deltaTime;
		if (MED_SPAWN_TIMER >= MED_SPAWN_RATE) {
			int mMedCount = 0;
			foreach (GameObject med in GameObject.FindGameObjectsWithTag("Med")) {
				mMedCount++;
			}
			if (mMedCount >= 3)
				return;
			
			//spawn
			GameObject mMed = Instantiate(mMedPrefab) as GameObject;
			Vector3 position = new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0);
			mMed.transform.localPosition = position;

			MED_SPAWN_TIMER = 0;
		}
	}

}
