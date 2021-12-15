using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class virtuarstic : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bgImg;
    private Image joystickimg;
    private Vector3 inputvector;

    void Start()
    {
      bgImg = GetComponent<Image>();
      joystickimg = transform.GetChild(0).GetComponent<Image>();  
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            if(Mathf.Abs(pos.x)<Mathf.Abs(pos.y))
            {
                pos.x = 0;
                if(pos.y < 0) pos.y = -1;
                else if (pos.y >0) pos.y = 1; 
            }
            else
            {
                pos.y = 0;
                if(pos.x < 0) pos.x = -1;
                else if (pos.x > 0) pos.x = 1;
            }

            inputvector = new Vector3(pos.x*2, pos.y*2, 0);
            inputvector = (inputvector.magnitude > 1.0f)? inputvector.normalized : inputvector;

            joystickimg.rectTransform.anchoredPosition = 
            new Vector3(inputvector.x * (bgImg.rectTransform.sizeDelta.x/ 3)
            ,inputvector.y * (bgImg.rectTransform.sizeDelta.y /3));
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    
    public virtual void OnPointerUp(PointerEventData Ped)
    {
        inputvector = Vector3.zero;
        joystickimg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float GetHorizontalValue() // 플레이어 컨트롤 스크립트에서 x값
    {
        return inputvector.x;
    }
    public float GetVerticalValue() // 플레이어 컨트롤 스크립트에서 x값
    {
        return inputvector.y;
    }
}
