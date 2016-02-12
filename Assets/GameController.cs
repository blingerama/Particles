using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text label;
	public GameObject enemy;
	public int numPerWave;
	public float waveTimer;
	public float startWait;
	public float spawnWait;
	public int maxiEnemies;
	private int numEnemies = 1;

	// Use this for initialization
	void Start () {
	
		StartCoroutine (SpawnWaves ());

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Return) || Input.GetKey ("enter")) {

			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

		}
	
	}

	IEnumerator SpawnWaves(){

		yield return new WaitForSeconds (startWait);

		while (numEnemies < maxiEnemies) {

			for (int i = 0; i < numPerWave; i++) {

				Vector3 spawnPosition = new Vector3 (13, 8, 0);
				Instantiate (enemy, spawnPosition, Quaternion.identity);
				numEnemies++;
				yield return new WaitForSeconds (spawnWait);

			}

			yield return new WaitForSeconds (waveTimer);
		}

		if (label.text  == "")
		label.text = "You won! Press Enter to restart."; 

	}
}
