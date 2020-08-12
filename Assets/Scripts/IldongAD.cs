using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IldongAD : MonoBehaviour {

	public GameObject ildongADVideo = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator adPopUP(){
		ildongADVideo.SetActive (true);
		yield return new WaitForSeconds (20.1f);
		ildongADVideo.SetActive (false);
	}
}
