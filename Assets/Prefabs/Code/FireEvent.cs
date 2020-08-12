using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEvent : MonoBehaviour {

	public GameObject Playerlocation = null;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Playerlocation.transform.position.z > 150) {
			gameObject.SetActive(true);
		}
	}
}