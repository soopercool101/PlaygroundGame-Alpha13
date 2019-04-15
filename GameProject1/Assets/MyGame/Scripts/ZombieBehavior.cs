using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieBehavior : Physics2DObject {




	public float SightDistance = 10;
	public float FollowDistance = 15;

	private Vector2 direction;
	private Vector3 startingPoint;
	public float speed = 1f;

	bool foundTarget = false;
	bool isLured = false;

	GameObject mTarget;
	GameObject mPlayer1;
	GameObject mLure;
	float timer = 0;

	// Use this for initialization
	void Start () {
		startingPoint = transform.position;
		direction = Random.insideUnitCircle;
		mPlayer1 = GameObject.FindGameObjectWithTag ("Player");
		mTarget = mPlayer1;
	}
	
	// Update is called once per frame
	private void FixedUpdate()
	{
		rigidbody2D.AddForce(direction * speed);
		//rigidbody2D.MovePosition(Vector2.Lerp(transform.position, mTarget.transform.position, Time.fixedDeltaTime * speed));
	}

	private void Update(){
		SearchForTarget ();
		SearchForLure ();

		if (foundTarget == true && isLured == false) {
			Follow ();
			return;
		}
		if (isLured == true) {
			Lure ();
			return;
		}
		Wander ();
	}

	void Wander(){
		timer += Time.deltaTime;
		if (timer >= 3) {
			direction = Random.insideUnitCircle;
			timer = 0; 
		}
		float distanceFromStart = Vector2.Distance (startingPoint, transform.position);
		if (distanceFromStart > 1f + (speed *0.1f)){
			direction = (startingPoint - transform.position).normalized;
		}
	}

	void Lure(){
		direction = (mLure.transform.position - transform.position).normalized;
	}

	void Follow(){
		direction = (mPlayer1.transform.position - transform.position).normalized;
	}

	void SearchForTarget(){
		float distanceFromP1 = Vector2.Distance (transform.position, mPlayer1.transform.position);

		if (distanceFromP1 <= SightDistance) {
			foundTarget = true;
		}
		if (distanceFromP1 >= FollowDistance){
			foundTarget = false;
		}
			
	}

	void SearchForLure(){
		float lureCount = 0;
		foreach (GameObject lure in GameObject.FindGameObjectsWithTag("Lure")) {
			lureCount++;
		}
		if (lureCount > 0) {
			mLure = GameObject.FindGameObjectWithTag ("Lure");
			float distancefromLure = Vector2.Distance (mLure.transform.position, transform.position);
			if (distancefromLure <= 10) {
				isLured = true;
			}
		}
		else
			isLured = false;
	}
}
