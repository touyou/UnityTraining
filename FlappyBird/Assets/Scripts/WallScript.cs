using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
	private float speed = 2;

	void Start () {
		Destroy (gameObject, 10);
	}

	void Update () {
		transform.position += transform.forward * speed * Time.deltaTime;
	}
}
