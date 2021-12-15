using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{

    public Image elementalText; // 표시할 텍스트 이미지파일
    public Camera camerA;   // 메인카메라를 기준으로하는 월드좌표를 스크린 좌표로 바꾸기위한 오브젝트 지정.
    public Transform target;    // 고정 타겟이 될 기준.
    public int npcXy;

    void FixedUpdate()
    {
        if (this.gameObject.activeSelf == true)
        {
            // screenPos에 타겟 오브젝트의 월드 좌표를 스크린 좌표로 변환후 저장한다.
            Vector3 screenPos = camerA.WorldToScreenPoint(this.target.position);
            // elemantalText란 이미지를 해당 오브젝트의 설정된 좌표로 새로 부여하여 고정시킨다.
            elementalText.transform.position = new Vector3(screenPos.x, screenPos.y, elementalText.transform.position.z);
        }
    }

}

