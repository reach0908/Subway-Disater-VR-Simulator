using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BillBoard : MonoBehaviour {

    private Text naviText;
    
	
	void Start () {
        naviText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        naviText.text = "아직 사고 전";
        transform.LookAt(Camera.main.transform);
        if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().isTrainAccident == true) {
            naviText.text = "안녕하세요, 저는 당신을 도와드릴 가이드입니다.";
        }
        if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().firstGuideInfo==true)
        {
            naviText.text = "몸을 낮추어 연기를 피하세요!";
        }
        if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().callGuide == true)
        {
            naviText.text = "비상 통화 장치를 이용해 긴급상황임을 알리세요!";
        }
        if (GameObject.Find("Railcar_Wagon (1)").GetComponent<TrainSitu>().fireControlGuideInfo==true)
        {
            naviText.text = "소화기를 컨트롤러의 그립버튼으로 잡아보세요!";
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
