using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidSmoke : MonoBehaviour {

	public bool isHeTouchSmoke = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "SmokeCollider") {
			isHeTouchSmoke = true;
			print ("Hit");
		} 
	}
}
