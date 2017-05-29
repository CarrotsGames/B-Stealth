using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script is for the game over screen that will happen when the player is spotted

public class GameUI : MonoBehaviour {
	//the gameover screen
	public GameObject gameLoseUI;
	//the game over count
	bool gameIsOver;

	//Start happens on start of game, if the player is spotted the Game Lose screen will appear
	void Start () {
		EnemyVision.OnEnemyHasSpottedPlayer += ShowgameLoseUI;
		
	}
	
	//Update happens every frame, this makes it so if the player presses space when they lose they casn try again
	void Update () {
		if (gameIsOver) {
			//if space is pushed after game over then load main menu
			if(Input.GetKeyDown (KeyCode.Space)) {
				//load main menu
				SceneManager.LoadScene (1);
			}
			
		}
		
	}
	//ShowLoseUI will makes it so if the player is spotted the lose screen will appear
	void ShowgameLoseUI (){
		OnGameOver (gameLoseUI);
	}
	//OnGameOver makes it so the game will end and the gameover text will appaer
	void OnGameOver(GameObject gameOverUI) {
		if (gameLoseUI) {
			gameLoseUI.SetActive (true);
			gameIsOver = true;
			EnemyVision.OnEnemyHasSpottedPlayer -= ShowgameLoseUI;
		}
	}
}
