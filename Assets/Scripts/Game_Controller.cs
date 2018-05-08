using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour {

	public GameObject hazard;
	public GameObject fuel;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;
	private int randomTimeFuel;

	void Start(){
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update(){
		if (GameObject.FindGameObjectsWithTag ("Player").Length == 0) {
			GameOver ();
		}
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {

				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
	}

	IEnumerator SpawnWaves(){
		
		yield return new WaitForSeconds (startWait);
		while (true) {
			randomTimeFuel = Random.Range (0, hazardCount);
			for (int i = 0; i <= hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
					if (i == randomTimeFuel) {
					yield return new WaitForSeconds (spawnWait);
					Instantiate (fuel, spawnPosition, spawnRotation);
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {

				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue){

		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void GameOver(){

		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
