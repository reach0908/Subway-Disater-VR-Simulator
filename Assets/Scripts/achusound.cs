using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achusound : MonoBehaviour {


    AudioSource achuSound;
    bool isHeTouchSmoke = false;

	// Use this for initialization
	void Start () {
        achuSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        isHeTouchSmoke = GameObject.Find("SmokeCollisionCheck").GetComponent<AvoidSmoke>().isHeTouchSmoke;
        if (isHeTouchSmoke==true) { StartCoroutine(soundPlay()); }
		
	}
    IEnumerator soundPlay() {
        achuSound.Stop();
        achuSound.Play();
        yield return new WaitForSeconds(2f);
    }
}
