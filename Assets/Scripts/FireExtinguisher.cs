using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour {
    [SerializeField] HoldableItem item;
    [SerializeField] GameObject pin;
    public GameObject smoke;
    public GameObject smokeEffect;
    public bool holding;        // 쥐고있는지 여부
    public bool pin_off;        // 안전핀 제거여부
    public bool shoting;        // 발사중 여부

    // Use this for initialization
    void Start () {
        if(item == null)
            item = GetComponent<HoldableItem>();
	}
	
	// Update is called once per frame
	void Update () {
        holding = item.holding; //쥔상태 체크

        //CheckState();

        if (pin_off)
            Pin_OFF();
        if(!holding)
            shoting = false;
    }

    void CheckState()
    {
        /*
        if (holding && pin_off)     //쥐고있고 핀이 제거되면
        {
            shoting = true;         //사용가능
        }
        else                        //그외엔 사용불가
        {
            shoting = false;
        }
        */
    }
    public void Pin_OFF()
    {
        pin.GetComponent<Rigidbody>().useGravity = true;
        pin.GetComponent<Rigidbody>().isKinematic = false;
        pin.transform.parent = GameObject.Find("Train_Animated").transform;
    }
    
}
