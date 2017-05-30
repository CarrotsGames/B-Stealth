using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script pauses the game and stops time when the game is paused and starts time again when the game starts again

public class PauseGame : MonoBehaviour {
	//canvas is the canvas in the scene
	public Transform canvas;

	// Update()
	//Update happens in every frame
	//
	//Param:
	//			None
	//Return:
	//			Void
	void Update () {
		//this makes it so if the escape key is clicked then the pause void Pause will start
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Pause();
			}
		}
	// Pause()
	//the timescale of the level go to 0 and stop everything in the game and displays a text
	//
	//Param:
	//			None
	//Return:
	//			Void
	public void Pause() {
	//this checks if the the pause scene is up and if it is stop time 
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			//this checks if the pause screen is up if not then resume game speed
		}else {
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;
		}
	}
}