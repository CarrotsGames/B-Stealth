using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this is the Main Menu script that loads Level 1 on start and closes the game if game if Qxit is pressed

public class MenuScript : MonoBehaviour {
	//quitMenu is the quit text
	public Canvas quitMenu;
	//startText is the start text if start is clicked
	public Button startText;
	//exitText is the exit text if exit is clicked
	public Button exitText;
	//--------------------------------------------------------------------------------------
	// Start()
	// Runs during initialisation
	//
	//Param:
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	void Start () {
		//this calls for the Quit text to appear on the screen
		quitMenu = quitMenu.GetComponent<Canvas> ();
		//this calls for the Start button to load on screen
		startText = startText.GetComponent<Button> ();
		//this calls for the exit button to load on screen
		exitText = exitText.GetComponent<Button> ();
		//this means the game won't load then exit stright away
		quitMenu.enabled = false;
	}
	//--------------------------------------------------------------------------------------
	// ExitPress () 
	//will make the game load a sub text
	//
	//Param:
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	public void ExitPress () {
		//if quit is available then start and exit will be unavilable
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		
	}
	//--------------------------------------------------------------------------------------
	//	NoPress () 
	//if no is pressed then close sub Menu
	//
	//Param:
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	public void NoPress () {
		//Quit is not available but start and exit are
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;

	}
	//--------------------------------------------------------------------------------------
	//	StartLevel () 
	// will load level 1
	//
	//Param:
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	public void StartLevel() {
		//this will load Level 1
		SceneManager.LoadScene ("Level-1");
	}
	//--------------------------------------------------------------------------------------
	//	ExitGame()
	// will close the game
	//
	//Param:
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	public void ExitGame() {
		//this will end the game and close the window
		Application.Quit ();
	}
}
