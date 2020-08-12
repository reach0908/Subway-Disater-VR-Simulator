using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuideText : MonoBehaviour {

	private Text naviText;
	// Use this for initialization
	void Start () {
		naviText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().firstGuideInfo == true) {
			naviText.text = "안녕하세요, 저는 지하철 화시 당신을 도와드릴 안 가이드입니다.";
		}
		if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().secondGuideInfo==true)
		{
			naviText.text = "우선 유독가스를 피하기위해 몸을 낯추어 이동하세";
		}
		if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().callGuide == true)
		{
			naviText.text = "비상 통화 장치를 이용해 긴급상황임을 알리세요!";
		}
		if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().fireControlGuideInfo==true)
		{
			naviText.text = "불을 끄기 위해 소화기를 사용하세요!";
		}
		if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().fireOffGuideInfo == true)
		{
			naviText.text = "컨트롤러의 트리거 버튼으로 소화기의 핀을 뽑으세요!";
		}
		if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().fifthGuideInfo == true)
		{
			naviText.text = "트리거 버튼으로 비상개폐장치의 커버를 열고 돌리세요!";
		}
		if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().fifthGuideInfo == true)
		{
			naviText.text = "트리거 버튼으로 비상개폐장치의 커버를 열고 돌리세요!";
		}
		if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().isDoorLeverOpen == true)
		{
			naviText.text = "이제 양손으로 문을 강제로 여세요!";
		}
		if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().IsHeGoOut == true)
		{
			naviText.text = "열차에서 탈출해 플랫폼을 향해 달리세요!";
		}
	}
	}
}
