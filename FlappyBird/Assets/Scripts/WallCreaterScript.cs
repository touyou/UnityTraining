using UnityEngine;
using System.Collections;

public class WallCreaterScript : MonoBehaviour {

	public GameObject wall;
	float timer = 0.0f;
	int interval = 3;

	void Update () {
		timer += Time.deltaTime;
		if (timer >= interval) {
			transform.position = new Vector3 (0, Random.Range (-1.0f, 2.0f), transform.position.z);
			Instantiate (wall, transform.position, transform.rotation);
			timer = 0;
		}
	}
}
