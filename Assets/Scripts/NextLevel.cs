using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script loads the next scene

public class NextLevel : MonoBehaviour {
	
	// OnTriggerEnter
	//player enters the objects trigger something will happen
	//
	//Param:
	//			None
	//Return:
	//			Void
	public void OnTriggerEnter () {
		//this makes it so the nect level will load and the player will load in
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
