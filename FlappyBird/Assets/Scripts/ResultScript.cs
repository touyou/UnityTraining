using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour {
	public Text scoreText;

	void Start () {
		scoreText.text = PlayerScript.score.ToString ();
	}
	

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			PlayerScript.score = 0;
			SceneManager.LoadScene ("main");
		}
	}
}
