using UnityEngine;
using System.Collections;

public class WakeupScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Rigidbody> ()) {
			GetComponent<Rigidbody> ().WakeUp ();
		}
	}
}
