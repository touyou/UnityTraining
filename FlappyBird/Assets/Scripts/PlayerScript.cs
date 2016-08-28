using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
	public static int score = 0;
	public Text scoreText;
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 6, 0);
			GetComponent<AudioSource> ().Play ();
		}
		scoreText.text = "Score : " + score.ToString ();
	}

	void OnCollisionEnter(Collision other) {
		SceneManager.LoadScene ("result");
	}

	void OnTriggerExit(Collider other) {
		score++;
	}
}
