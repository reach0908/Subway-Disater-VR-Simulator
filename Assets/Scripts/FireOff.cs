using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOff : MonoBehaviour {
    [SerializeField] int hp = 100;
	public bool isFireOff=false;

    [SerializeField] GameObject[] fireObjects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "FireExtinguisher") {
            if (hp > 0)
                hp--;
            else if (hp <= 0)
            {
                isFireOff = true;
                foreach(GameObject off in fireObjects)
                {
                    off.SetActive(false);
                }
                //this.gameObject.SetActive(false);
            }
		}		
	}
}
