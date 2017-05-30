using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script allows the player to exit from the pause menu while ingame

public class QuitInGame : MonoBehaviour {
	//reference to the player
	public Transform player;
	//	SaveGameSetting() 
	//checks the player position and exits the game
	//
	//Param:
	//			bool quit- sends player back to the Main Menu
	//Return:
	//			Void
	public void SaveGameSetting(bool Quit) {
		
		PlayerPrefs.SetFloat ("x", player.position.x);
		PlayerPrefs.SetFloat ("y", player.position.y);
		PlayerPrefs.SetFloat ("z", player.position.z);
		PlayerPrefs.SetFloat ("Cam_y", player.eulerAngles.y);
		if (Quit) {
			//the time scale is returned to 1 and the Start Menu is loaded
			Time.timeScale = 1;
			SceneManager.LoadScene ("Start Menu");
		}
	}

}
