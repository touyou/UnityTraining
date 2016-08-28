using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
	public int boost = 3;
	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (boost > 0) {
				GetComponent<Rigidbody> ().AddForce (0, -5000, 0);
				boost--;
			}
		}
		text.text = "Boost : " + boost.ToString ();
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.transform.parent.name == "breakable") {
			Destroy (other.gameObject);
		}
	}
}
