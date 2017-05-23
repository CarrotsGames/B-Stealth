using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {

	public Transform player;

	void Awake () {
	//	player.position = new Vector3 (PlayerPrefs.GetFloat ("x"), PlayerPrefs.GetFloat ("y"), PlayerPrefs.GetFloat ("z"));
	//	player.eulerAngles = new Vector3 (0, PlayerPrefs.GetFloat ("Cam_y"), 0);
	}

	public void SaveGameSetting(bool Quit) {
		
		PlayerPrefs.SetFloat ("x", player.position.x);
		PlayerPrefs.SetFloat ("y", player.position.y);
		PlayerPrefs.SetFloat ("z", player.position.z);
		PlayerPrefs.SetFloat ("Cam_y", player.eulerAngles.y);
		if (Quit) {
			
			Time.timeScale = 1;
			SceneManager.LoadScene ("Start Menu");
		}
	}

}
