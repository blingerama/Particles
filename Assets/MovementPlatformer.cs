using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour{
	
	public float moveSpeed;
	public float jumpSpeed;
	public Rigidbody2D physics;
	public Collider2D characterColl, Platform1, floor, Platform2, Platform3, Platform4, Platform5, Platform6, Goal;

	void Start(){}

	void Update() {
		
		//Next two if statements are for moving left and right
		if (Input.GetKey(KeyCode.D))
			transform.Translate (new Vector2 (1, 0) * moveSpeed * Time.deltaTime);

		if (Input.GetKey(KeyCode.A))
			transform.Translate (new Vector2 (-1, 0) * moveSpeed * Time.deltaTime); 

		if ((Input.GetKeyDown(KeyCode.W))  && (characterColl.IsTouching(floor) || characterColl.IsTouching(Platform1) || characterColl.IsTouching(Platform2) || characterColl.IsTouching(Platform3) || characterColl.IsTouching(Platform4) || characterColl.IsTouching(Platform5) || characterColl.IsTouching(Platform6) || characterColl.IsTouching(Goal)))
			physics.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);

		if ((Input.GetKeyDown (KeyCode.S)))
			physics.AddForce (new Vector2 (0f, -(jumpSpeed * 2)), ForceMode2D.Impulse);
	}
	/*
	//Used for checking if the player is touching the ground 
	void OnCollisionStay2D(Collision2D coll ){

		if ((coll.gameObject.tag == "floor" || coll.gameObject.tag == "Platform1") && (Input.GetKeyDown(KeyCode.W)))
			physics.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);

	}*/
}