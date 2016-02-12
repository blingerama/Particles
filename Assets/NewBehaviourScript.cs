using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (0, -1) * moveSpeed * Time.deltaTime);
	}
}
