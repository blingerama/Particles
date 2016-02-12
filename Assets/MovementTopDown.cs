using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovementTopDown : MonoBehaviour {

    public float moveSpeed;
	public Text label;

	// Use this for initialization
	void Start () {
	
		//label = GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.D) && transform.position.x < 24.6f)
			transform.Translate (new Vector2 (1, 0) * moveSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.A) && transform.position.x > 1.4f)
			transform.Translate (new Vector2 (-1, 0) * moveSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.S) && transform.position.y > 1.5f)
			transform.Translate (new Vector2 (0, -1) * moveSpeed * Time.deltaTime);

		if (Input.GetKey (KeyCode.W) && transform.position.y < 12.5f)
			transform.Translate (new Vector2 (0, 1) * moveSpeed * Time.deltaTime);

    }

	void OnTriggerEnter2D(Collider2D hit){

		if (hit.gameObject.tag == "IAMANENEMY" && label.text == "") {


			label.text = "Congratulations! You failed. Press Enter to reset the level.";
			Destroy (transform.gameObject);

		}

	}
}
