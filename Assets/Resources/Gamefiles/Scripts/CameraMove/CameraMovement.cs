using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target; // 기준점이 될 타겟.
    public float smoothing; // 카메라의 이동시 얼마나 부드럽게 할지.
    public Vector2 minPosition; // 최소가 될 맵의 좌표
    public Vector2 maxPosition; // 최대가 될 맵의 좌표


    // Use this for initialization
    void Start()
    {

    }

    // 스크립트가 켜져있을때 매 프레임마다 호출됩니다.
    // 스크립트 실행순서를 정할때 도움이 됩니다.
    void LateUpdate()
    {
        // 이 Object.position이 Target.position과 다를경우 실행
        if (transform.position != target.position)
        {
            // Vector3 targetPosition  Local variable 선언후 new Vector3로 새로 정의함.
            Vector3 targetPosition = new Vector3(target.position.x,
                                                 target.position.y,
                                                 transform.position.z);
            // targetPosition.x의 좌표를 Mathf.Clamp하여 잠군다.
            // 기준순서는 현재값,최대값,최소값으로 현재값이 최대 최소값이내라면 현재값을 반환한다.
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                           minPosition.x,
                                           maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                           minPosition.y,
                                           maxPosition.y);

            /*
             선형 보간법이란 끝점의 값이 주어졌을 때 그 사이에 위치한 값을 추정하기 위하여
             직선 거리에 따라 선형적으로 계산하는 방법이다.
             단순하게 " 어떤 수치에서 어떤 수치로 값이 변경되는데 한 번에 변경되지 않고
             부드럽게 변경되게 하고싶다. 할 때"
             Mathf.Lerp - > 숫자 간의 선형 보간
             Vector2.Lerp - > vector2 간의 선형 보간
             Vector3.Lerp - > vector3 간의 선형 보간
             Quaternion.Lerp - > quaternion.Lerp 간의 선형 보간 (회전)
             */
             // Vector3.Lerp(위치1,위치2,0~1사이의 실수)
             // 위치1에서 위치2로 이동하는데 얼마만큼의 속도로 갈것인가.
            transform.position = Vector3.Lerp(transform.position,
                                              targetPosition, smoothing);
                                            
        }
    }
}
