using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour
{

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    public GameObject collidingObject { get; set; }
    public GameObject objectInHand { get; set; }
    public ControllerGrabObject otherHand;

    FireExtinguisher fe;
    

    // Use this for initialization
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.GetPress(Valve.VR.EVRButtonId.k_EButton_Grip))
        {     //그립 버튼 눌린중

            if (objectInHand != null)       //이쪽 손이 뭘 쥐고있다면
            {
                objectInHand.GetComponent<HoldableItem>().holding = true;
                objectInHand.GetComponent<Rigidbody>().useGravity = false;
                //return;
            }
            else if (collidingObject != null && collidingObject.GetComponent<HoldableItem>()) //이쪽 손이 뭔가에 닿았고 쥐는게 가능한 오브젝트면
            {
                GrabObject();       //충돌한걸 손에 쥐고 처음으로
                return;
            }
            else if(objectInHand == null && collidingObject == null)    //뭘 쥐고있지 않으면서 충돌하지 않았으면 아무것도 하지않음
            {
                return;
            }

            ///// 소화기
            fe = objectInHand.GetComponent<FireExtinguisher>();
            if (fe != null)     //쥐고있는게 소화기라면
            {
                if(fe.pin_off == false)     //안전핀이 제거가 안됐으면
                {
                    print("집어든 상태임");
                }
                else if(fe.pin_off == true && fe.shoting == false)  //안전핀은 제거됐지만 쏘는중이 아니면
                {
                    print("안전핀 제거상태로 집어든 상태임(쏘는 상황으로 전환)");
                    fe.shoting = true;
                }
                else if (fe.pin_off == true && fe.shoting == true)  //안전핀 제거하고 쏘는중이면
                {
                    /*print("안전핀 제거상태로 집어들어서 쏘는중임");*/
                }
                return;
            }


        }
        if (Controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
        {   //트리거 버튼 눌린중
            if (objectInHand != null)       //이쪽 손이 뭘 쥐고있다면
            {
                objectInHand.GetComponent<HoldableItem>().holding = true;
                objectInHand.GetComponent<Rigidbody>().useGravity = false;
                return;                     //충돌은 무시함
            }
            if (collidingObject)            //쥐고있지 않을때 충돌한 오브젝트가 있다면
            {
                if (otherHand.objectInHand == false)    //다른쪽 손이 뭘 쥐고있지 않다면
                {
                    if (collidingObject.GetComponent<HoldableItem>())   //쥐는게 가능한 오브젝트라면 충돌한걸 손에 쥐고 처음으로
                    {
                        GrabObject();
                        return;
                    }
                
                    //해당 오브젝트에 DoorLever가 있을경우
                    DoorLever lvr = collidingObject.GetComponent<DoorLever>();
                    if (lvr != null)
                    {
                        if (!lvr.cover)
                        {
                            lvr.cover = true;
                            lvr.plaingAnimation = true;
                        }
                        else if (lvr.cover && !lvr.turnOn)
                        {
                            lvr.turnOn = true;
                            lvr.plaingAnimation = true;
                        }
                        return;
                    }
                   
                    //해당 오브젝트에 LeftDoorExit가 있을경우
                    LeftDoorExit LDoor = collidingObject.GetComponent<LeftDoorExit>();
                    if (LDoor != null)
                    {
                        LDoor.DoorOpen();
                        return;
                    }
                    //해당 오브젝트에 RightDoorExit가 있을경우
                    RightDoorExit RDoor = collidingObject.GetComponent<RightDoorExit>();
                    if (RDoor != null)
                    {
                        RDoor.DoorOpen();
                        return;
                    }
                    //해당 오브젝트에 SOSButton이 있을경우
                    SOSButton sos = collidingObject.GetComponent<SOSButton>();
                    if (sos != null)
                    {
                        bool isAccidunt = GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().isTrainAccident;
                        if (!sos.buttonClicked && isAccidunt)
                        {
                            sos.buttonClicked = true;
                            sos.plaingAnimation = true;
                        }
                        return;
                    }
                    /*SOSButton sos = collidingObject.GetComponent<IldongAd>();
                    if (sos != null)
                    {
                        bool isAccidunt = GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().isTrainAccident;
                        if (!sos.buttonClicked && isAccidunt)
                        {
                            sos.buttonClicked = true;
                            sos.plaingAnimation = true;
                        }
                        return;
                    }
                    */
                }
                else if (otherHand.objectInHand == true)        //다른쪽 손이 뭘 쥐고있을때
                {
                    fe = collidingObject.GetComponent<FireExtinguisher>();
                    if (fe != null)                 // 쥐고있는게 소화기가 맞고 이쪽 손이 닿은 상태라면
                    {
                        if (fe.pin_off == false)    //핀이 제거가 안됐으면
                        {
                            print("안전핀제거");
                            fe.pin_off = true;
                        }/*
                        else if (fe.pin_off == true && fe.shoting == false)
                        {
                            print("안전핀 제거상태로 쏘고있는 상태는 아님");
                            fe.shoting = true;
                        }
                        else if(fe.pin_off == true && fe.shoting == true)
                        {
                            print("소화기 발사중");
                        }*/
                        return;
                    }
                    else if(fe == null)            //이쪽 손이 소화기에 안 닿은 상태라면
                    {
                        fe = otherHand.objectInHand.GetComponent<FireExtinguisher>();
                        if (fe != null)            //다른쪽 손이 소화기를 쥔게 맞는지 확인
                        {
                            if (fe.pin_off == true)
                            {
                                print("안전핀 제거했고 집어들어서 소화기 발사중(충돌)");
                            }/*
                            else if (fe.pin_off == false)
                            {

                            }*/
                        }
                    }
                }
            }
            else if (collidingObject == null)            //이쪽 손이 아무데도 안 닿은 상태라면
            {
                if (otherHand.objectInHand == true)        //다른쪽 손이 뭘 쥐고있을때
                {
                    fe = otherHand.objectInHand.GetComponent<FireExtinguisher>();
                    if (fe != null)            //다른쪽 손이 소화기를 쥔게 맞는지 확인
                    {
                        if (fe.pin_off == true)
                        {
                            print("안전핀 제거했고 집어들어서 소화기 발사중(비충돌)");
                            fe.shoting = true;
                            GameObject smoke = Instantiate(fe.smoke, transform.position, Quaternion.identity);
                            smoke.GetComponent<Rigidbody>().AddForce(transform.forward * 800f);
                            GameObject smokeEffectObj = Instantiate(fe.smokeEffect, transform.position, transform.rotation);
                            Destroy(smoke, 2f);
                            Destroy(smokeEffectObj, 2f);

                        }/*
                        else if (fe.pin_off == false)
                        {

                        }*/
                    }
                    
                }
            }
        }
        if (Controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_Grip))
        {       //그립 버튼 떼기	
            if (objectInHand)
            {
                if(fe != null)
                {
                    fe.shoting = false;
                    fe = null;
                    print("소화기 놓음1");
                }
                ReleaseObject();
            }
        }
        if (Controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
        {       //트리거 버튼 떼기	

            if (objectInHand)
            {
                if (fe != null)
                {
                    fe.shoting = false;
                    fe = null;
                    print("소화기 놓음2");
                }
                ReleaseObject();
            }

        }
    }
    void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {       //접촉 오브젝트가 있거나 충돌체가 리지드바디가 없는 경우 무시
            return;
        }

        collidingObject = col.gameObject;           //충돌한 오브젝트를 기억
    }

    private void OnTriggerEnter(Collider other)      //물체 접촉시작
    {
        if (!other.GetComponent<DoorLever>() && !other.GetComponent<LeftDoorExit>() && !other.GetComponent<RightDoorExit>() && !other.GetComponent<SOSButton>()
            && !other.GetComponent<HoldableItem>())
            //해당 컴포넌트가 모두 없으면 리턴
            return;

        SetCollidingObject(other);
    }
    private void OnTriggerStay(Collider other)      //물체 접촉중
    {
        if (!other.GetComponent<DoorLever>() && !other.GetComponent<LeftDoorExit>() && !other.GetComponent<RightDoorExit>() && !other.GetComponent<SOSButton>()
            && !other.GetComponent<HoldableItem>())
            //해당 컴포넌트가 모두 없으면 리턴
            return;

        SetCollidingObject(other);

    }
    private void OnTriggerExit(Collider other)      //물체 접촉마침
    {
        if (!collidingObject)                           //접촉한 물체가 없는 경우 무시
            return;

        if (!other.GetComponent<DoorLever>() && !other.GetComponent<LeftDoorExit>() && !other.GetComponent<RightDoorExit>() && !other.GetComponent<SOSButton>()
            && !other.GetComponent<HoldableItem>())
            //해당 컴포넌트가 모두 없으면 리턴
            return;

        collidingObject = null;
    }


    public void GrabObject()   //물체를 집었을때
    {
        objectInHand = collidingObject;
        collidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        joint.connectedBody.useGravity = false;
        joint.connectedBody.isKinematic = false;
        objectInHand.GetComponent<HoldableItem>().holding = true;
        objectInHand.GetComponent<BoxCollider>().isTrigger = true;
    }

    FixedJoint AddFixedJoint()  //
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    void ReleaseObject()    //물체를 놓았을때
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            objectInHand.GetComponent<Rigidbody>().useGravity = true;
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        objectInHand.GetComponent<HoldableItem>().holding = false;
        objectInHand.GetComponent<BoxCollider>().isTrigger = false;
        objectInHand = null;
    }


}
