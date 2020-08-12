using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOSButton : MonoBehaviour {
    
    public bool buttonClicked;  //버튼 누름여부
    public bool plaingAnimation;    //애니메이션을 플레이중인지 여부
    public bool callComplete;
    Animator animator;
    

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        buttonClicked = false;
        plaingAnimation = false;

    }
	
	// Update is called once per frame
	void Update () {
        if(buttonClicked && plaingAnimation)
        {
            ButtonClick();
        }
	}
    
    public void ButtonClick()
    {
        animator.SetTrigger("ButtonClick");
        plaingAnimation = false;
        StartCoroutine(Calling());
    }

    IEnumerator Calling()
    {
        callComplete = true;
        yield return new WaitForSeconds(5f);
        /* 후에 진행경과 추가 */
    }

}
