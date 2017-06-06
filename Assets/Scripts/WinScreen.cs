using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {
	//calls the canvus in the scene
	public Canvas youWin;
	// calls the main menu button
	public Button mainmenu;

	//--------------------------------------------------------------------------------------
	//	MainMenuPressed () 
	// loads start menu
	//
	//Param:
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	
	public void MainMenuPressed () {
		SceneManager.LoadScene ("Start Menu");
	}
}
