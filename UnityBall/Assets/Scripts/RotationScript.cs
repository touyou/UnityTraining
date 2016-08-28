using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour{
	public Transform target;
	public float angle = 200f;
	
	// Use this for initialization
	void Start ()  {

	}
	
	// Update is called once per frame
	void Update (){
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.RotateAround (target.position, -transform.forward, angle * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.RotateAround (target.position, transform.forward, angle * Time.deltaTime);
		}
	}
}
