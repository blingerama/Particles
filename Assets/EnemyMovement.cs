using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float moveSpeed;
    public Collider2D me;
	public AudioClip sound;
	public float xDir;
    public float yDir;
	private AudioSource source;
    public Collisions methodCall;

	// Use this for initialization
	void Start () {

		source = GetComponent<AudioSource> ();

		//generate random trajectory
		float angle = Random.Range (0.0f, 90.0f);
		int x = Random.Range (0, 1), y = Random.Range (0, 1);

		if (x > 0)
			xDir = Mathf.Cos (angle);
		else
			xDir = -1 * Mathf.Cos (angle);

		if (y > 0)
			yDir = Mathf.Sin (angle);
		else
			yDir = Mathf.Sin (angle);
	
	}

	// Update is called once per frame
	void Update () {

		//MOVE
		transform.Translate(new Vector2(xDir, yDir) * moveSpeed * Time.deltaTime);
	
	}
    
    void OnTriggerEnter2D(Collider2D hit) {
        Debug.Log(hit.gameObject.tag);

		source.PlayOneShot (sound); 

		// if a wall was hit, move away from wall
		if (hit.gameObject.tag == "yWall") { yDir = yDir * -1.03f;	xDir = xDir *1.03f;	}
		else if (hit.gameObject.tag == "xWall") { xDir = xDir * -1.03f; yDir = yDir * 1.03f; }
        else {

            methodCall.calc(me, hit);

	    }

    }
}

