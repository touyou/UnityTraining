using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FinalController : MonoBehaviour{

	[SceneName]
	public string Start;

	public int Hscore;

	public void Awake(){
		Hscore = PlayerPrefs.GetInt("highscore",0);
	}
	
	void Update(){
		if (Hscore <= 30000){
		     GameObject player = GameObject.FindGameObjectWithTag("Player");
		     if (player){
			     StartCoroutine(LoadNextLevel());
			     enabled = false;
		     }
		}
	}

	private IEnumerator LoadNextLevel(){
		var player = GameObject.FindGameObjectWithTag ("Player");

		if (player) {
			player.SendMessage ("TimeOver", SendMessageOptions.DontRequireReceiver);
		}
		
		yield return new WaitForSeconds (1.65f);
		Application.LoadLevel (Start);
	}		
}

