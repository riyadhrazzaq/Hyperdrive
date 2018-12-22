using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	private Vector3 playerposition;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	private int score;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		playerposition=  GameObject.Find("Main Camera").transform.position;
		if (restart)
		{
			
			if (Input.GetKeyDown (KeyCode.R))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);﻿			
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, playerposition.z+203.0f);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver)
			{
			restartText.text = "Press 'R' for Restart";

				break;
		}
		}
	}
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
		SceneManager.LoadScene ("Home");
		restart = true;
	}
}