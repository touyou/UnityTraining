using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour{
	
	public int playerLIFE;
	public Text LIFE;	
	[SceneName]
	public string nextLevel;
	public Transform playerPosition;
	public float DeadYLine = -15.0f;
	
	public void LossLife(){
		if (playerLIFE >= 1 ) {
			playerLIFE -= 1;
		} 
		else {
			playerLIFE = 0;
		}
		LIFE.text = playerLIFE.ToString ("00");
	}

	public void BigLossLife(){
		playerLIFE = 0;
		LIFE.text = playerLIFE.ToString ("00");
	}

	void Update(){
		if (playerLIFE == 0){
		     GameObject player = GameObject.FindGameObjectWithTag("Player");
		     if (player){
			     StartCoroutine(LoadNextLevel());
			     enabled = false;
		     }
		}
		if (playerPosition.position.y < DeadYLine) {
			BigLossLife();
		}
	}

	private IEnumerator LoadNextLevel(){
		var player = GameObject.FindGameObjectWithTag ("Player");
		yield return new WaitForSeconds (0.18f);

		if (player) {
			player.SendMessage ("TimeOver", SendMessageOptions.DontRequireReceiver);
		}
		
		yield return new WaitForSeconds (1.65f);
		Application.LoadLevel (nextLevel);
	}		

	private static LifeController l_instance;
	
	public static LifeController instance{
		get{
			if (l_instance == false){
				l_instance = FindObjectOfType<LifeController>();
			}
			return l_instance;
		}
	}
}

