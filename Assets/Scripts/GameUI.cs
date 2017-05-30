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
	//	--------------------------------------------------------------------------------------
	//	Start()
	//Runs durimg initialisation
	//when player is spotted then the Lose game screen will show
	//Param:
	//			None
	//Return:
	//			Void
	//
	//  --------------------------------------------------------------------------------------
	void Start () {
		EnemyVision.OnEnemyHasSpottedPlayer += ShowgameLoseUI;
		
	}
	//   --------------------------------------------------------------------------------------
	//		Update()
	//Runs every frame,
	//if the space bar is clicked when the Lose game screen is up then restart from level 1
	//Param:
	//			None
	//Return:
	//			Void
	//  --------------------------------------------------------------------------------------
	void Update () {
		if (gameIsOver) {
			//if space is pushed after game over then load main menu
			if(Input.GetKeyDown (KeyCode.Space)) {
				//load level 1
				SceneManager.LoadScene (1);
			}
			
		}
		
	}
	//  --------------------------------------------------------------------------------------
	//		ShowLoseUI ()
	//runs when player is found
	//shows the game over screen
	//
	//Param:
	//			None
	//Return:
	//			Void
	//  --------------------------------------------------------------------------------------

	//ShowLoseUI will makes it so if the player is spotted the lose screen will appear
	void ShowgameLoseUI (){
		OnGameOver (gameLoseUI);
	}
	//  --------------------------------------------------------------------------------------
	// OnGameOver ()
	// will loads the game over screen
	//
	//Param:
	//			GameObject- A reference to the game over UI text
	//Return:
	//			Void
	//  --------------------------------------------------------------------------------------
	//OnGameOver makes it so the game will end and the gameover text will appaer
	void OnGameOver(GameObject gameOverUI) {
		if (gameLoseUI) {
			gameLoseUI.SetActive (true);
			gameIsOver = true;
			EnemyVision.OnEnemyHasSpottedPlayer -= ShowgameLoseUI;
		}
	}
}
