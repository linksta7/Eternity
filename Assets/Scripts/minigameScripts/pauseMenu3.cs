using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu3 : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {/*
			if (gameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}*/
			openMenu ();
		}
	}

	public void openMenu () {
		if (gameIsPaused) {
			Resume ();
		} else {
			Pause ();
		}
	}

	public void Resume () {
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	void Pause () {
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

	public void QuitGame() {
		Debug.Log ("Load Exit Scene here");
		Time.timeScale = 1f;
		//SceneManager.LoadScene ("Scene Here");
		//Application.Quit();
	}

	public void Restart() {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("minigame3");
	}
}
