using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

	public GameObject gameLoseUI;
	bool gameIsOver;

	//if the player is spotted the Game Lose screen will appear
	void Start () {
		GuardVision.OnGuardHasSpottedPlayer += ShowgameLoseUI;
		
	}
	
	// thios makes it so if the player presses space when they lose they casn try again
	void Update () {
		if (gameIsOver) {
			if(Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene (0);
			}
			
		}
		
	}
	//this makes it so if the player is spotted the lose screen will appear
	void ShowgameLoseUI (){
		OnGameOver (gameLoseUI);
	}
	void OnGameOver(GameObject gameOverUI) {
		gameLoseUI.SetActive (true);
		gameIsOver = true;
		GuardVision.OnGuardHasSpottedPlayer -= ShowgameLoseUI;
	}
}
