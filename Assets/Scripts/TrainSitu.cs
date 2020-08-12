using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainSitu : MonoBehaviour
{

    public bool isTrainAccident = false;
    public bool EmergencyCall = false;
    public bool EmergencyDoor = false;

    public bool infoNavi = false;


    //guide bool
    public bool firstGuideInfo = false;
    public bool secondGuideInfo = false;
    public bool callGuide = false;
    public bool GasInfo = false;
    public bool thirdGuideInfo = false;
    public bool fourthGuideInfo = false;
    public bool fireControlGuideInfo = false;
    public bool fireOffGuideInfo = false;
    public bool fireComplementInfo = false;
    public bool fifthGuideInfo = false;

    //player action bool
    public bool callComplete = false;
    public bool isHeGrapFireExting = false;
    public bool isHeCall = false;
    public bool isHeOffFire = false;
    public bool isDoorLeverOpen;
    public bool isDoorLeverOpen2;
    public bool isHeTouchSmoke;
    public bool isHeOpenRightDoor = false;
    public bool isHeOpenWrongDoor = false;
    public bool IsHeGoOut = false;
    public bool IsHeEscape = false;


    //audioclip
    public AudioClip fireinfo;
    public AudioClip guide1;
    public AudioClip guide2;
    public AudioClip guide3;
    public AudioClip guide4;
    public AudioClip guide5;
    public AudioClip callguide;
    public AudioClip fireControlVoiceGuide;
    public AudioClip fireOffVoiceGuide;
    public AudioClip ComplementVoice;
    public AudioClip DoorVoiceGuide;
    public AudioClip EmergencyDoorGuide;
    public AudioClip WrongDoorGuide;
    public AudioClip RightDoorGuide;
    public AudioClip ChooseDoorGuide;
    public AudioClip LastGuide;


    //evnet object
    public GameObject fireEvent = null;
    public GameObject Explosion = null;
    public GameObject popUpParticle = null;
    public GameObject GuideRobot = null;
    public GameObject SmokeEffect = null;

    //questMark
    public GameObject CallQuestMark = null;
    public GameObject ExtingQuestMark = null;
    public GameObject LeverQuestMark = null;

    //navi text
   

    AudioSource MainSound;



    float Timer;

    // Use this for initialization
    void Start()
    {
        Timer = 0;
        MainSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Timer += Time.deltaTime;
        if (Timer % 10 == 0) { print(Timer); }
        if (Timer >= 80f && isTrainAccident == false)
        {
            Explosion.SetActive(true);
            isTrainAccident = true;
            print("Train is in the Accident");
        }
        if (Timer >= 90f && firstGuideInfo == false && isTrainAccident == true)
        {
            fireEvent.SetActive(true);
            StartCoroutine(GasEvent(5f));
            RobotPopup();
            print("Robot pop Up");
            MakeAnnouncementInsideTrain(guide1);
           
            print("First Guide End");
            firstGuideInfo = true;
        }

        if (Timer >= 105f&& firstGuideInfo == true&&secondGuideInfo==false)
        {
            isHeTouchSmoke = GameObject.Find("SmokeCollisionCheck").GetComponent<AvoidSmoke>().isHeTouchSmoke;
            if (isHeTouchSmoke == true && secondGuideInfo == false)
            {
                MakeAnnouncementInsideTrain(guide2);
                print("Second Guide End");
                secondGuideInfo = true;
            }
        }
        if (Timer >= 120f&& callGuide == false && secondGuideInfo == true)
        {
            MakeAnnouncementInsideTrain(callguide);
            CallQuestMark.SetActive(true);
            print("Call Guide End");
            callGuide = true;
        }
        if (Timer >= 135f && callComplete == false && callGuide == true)
        {
            if (GameObject.Find ("SOSButton").GetComponent<SOSButton> ().callComplete == true) {
                MakeAnnouncementInsideTrain(fireinfo);
                print("Announce Fire info");
                CallQuestMark.SetActive(false);
                callComplete = true;
            }
        }
        if (Timer >= 155f && callComplete == true && infoNavi == false)
        {
            MakeAnnouncementInsideTrain(guide3);
            print("Guide3 End");
            infoNavi = true;
        }
        if (Timer >= 175f && infoNavi == true && thirdGuideInfo == false)
        {
            MakeAnnouncementInsideTrain(fireControlVoiceGuide);
            print("Fire control voice End");
            ExtingQuestMark.SetActive(true);
            thirdGuideInfo = true;
            
        }
		if (Timer >= 185f && thirdGuideInfo == true && isHeGrapFireExting == false && fireOffGuideInfo==false)
        {
            isHeGrapFireExting = GameObject.Find("fire extinguisher").GetComponent<FireExtinguisher>().holding;
            print("He grap Fire exting");
            if (isHeGrapFireExting == true)
            {
                ExtingQuestMark.SetActive(false);
                MakeAnnouncementInsideTrain(fireOffVoiceGuide);
                print("Fire Off Guide End");
                fireOffGuideInfo = true;
            }
        }
        if (Timer >= 205f&& fireOffGuideInfo == true && fireComplementInfo == false)
        {
            isHeOffFire = GameObject.Find("SmallFires").GetComponent<FireOff>().isFireOff;
            if (isHeOffFire == true)
            {
                SmokeEffect.SetActive(false);
                MakeAnnouncementInsideTrain(ComplementVoice);
                print("He Off The Fire");
				GasOffEvent (3f);
                fireComplementInfo = true;
            }
        }
        if (Timer >= 220f && fireComplementInfo == true && fifthGuideInfo == false)
        {
            MakeAnnouncementInsideTrain(DoorVoiceGuide);
            LeverQuestMark.SetActive(true);
            print("How to open the door guide end");
            fifthGuideInfo = true;
        }
        //현재완료지점
        if (Timer >= 240f && fifthGuideInfo == true && EmergencyDoor == false)
        {
            isDoorLeverOpen2 = GameObject.Find("DoorLever").GetComponent<DoorLever>().cover;
            isDoorLeverOpen = GameObject.Find("DoorLever (1)").GetComponent<DoorLever>().cover;
            if (isDoorLeverOpen == true || isDoorLeverOpen2 == true)
            {
                LeverQuestMark.SetActive(false);
                MakeAnnouncementInsideTrain(EmergencyDoorGuide);
                print("He open the rever");
                EmergencyDoor = true;
            }
            

        }
        if (Timer >= 255f && EmergencyDoor == true&&IsHeGoOut == false)
        {
            isHeOpenRightDoor = GameObject.Find("DoorLever (1)").GetComponent<DoorLever>().turnOn;
            isHeOpenWrongDoor = GameObject.Find("DoorLever").GetComponent<DoorLever>().turnOn;
            if (isHeOpenRightDoor == true)
            {
                
                MakeAnnouncementInsideTrain(RightDoorGuide);
                print("He success");
                IsHeGoOut = true;
            }
            /*if (isHeOpenRightDoor == false && isHeOpenWrongDoor == true)
            {
                MakeAnnouncementInsideTrain(WrongDoorGuide);
                print("He open the wrong door");
            }
            if (isHeOpenRightDoor == true && isHeOpenWrongDoor == true)
            {
                MakeAnnouncementInsideTrain(ChooseDoorGuide);
            }*/
        }
        if (Timer >= 275f&& isHeOpenRightDoor == true && IsHeEscape == false)
        {
            MakeAnnouncementInsideTrain(LastGuide);
        }
    }
    IEnumerator GasEvent(float second)
    {

        yield return new WaitForSeconds(second);
        SmokeEffect.SetActive(true);

	} IEnumerator GasOffEvent(float second)
	{

		yield return new WaitForSeconds(second);
		SmokeEffect.SetActive(false);

	}
    IEnumerator timepausemode(float second)
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(second);
        Time.timeScale = 1;
    }
    public void MakeAnnouncementInsideTrain(AudioClip current)
    {
        MainSound.Stop();
        MainSound.clip = current;
        MainSound.Play();

    }
    public void RobotPopup()
    {

        Instantiate(popUpParticle, GuideRobot.transform.position, Quaternion.identity);
        GuideRobot.SetActive(true);
        Destroy(popUpParticle, 1f);
    }
    
}
