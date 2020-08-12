using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLever : MonoBehaviour {

    public bool cover;      //커버 열림여부
    public bool turnOn;     //래버 돌림여부
    public bool plaingAnimation;    //애니메이션을 플레이중인지 여부
    Animator animator;

    [SerializeField] GameObject leftDoor;   //좌측문
    [SerializeField] GameObject rightDoor;  //우측문

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        cover = false;
        turnOn = false;
        plaingAnimation = false;

    }
	
	// Update is called once per frame
	void Update () {
        if(turnOn && plaingAnimation)
        {
            TurnOn();
        }
		else if(cover && plaingAnimation)
        {
            CoverOpen();
        }
	}

    public void CoverOpen()
    {
        animator.SetTrigger("Open");
        plaingAnimation = false;
    }

    public void TurnOn()
    {
        animator.SetTrigger("TurnOn");
        plaingAnimation = false;
        leftDoor.GetComponent<LeftDoorExit>().openok = true;    //각 문에 열림허용
        rightDoor.GetComponent<RightDoorExit>().openok = true;
    }




}
