using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSoundsEfect : MonoBehaviour
{
    public enum LayerNameobj
    {
        // 기본상태
        Idle = 0,
        // 분수대
        Fountain = 1,
        // 플라시아 교단 앰블럼 깃발
        PlasiaEmblem = 2,
        //워터 레이어
        water = 3,
        //풍선 레이어
        bubble = 4,
        //하레스 엠블램
        HaresEmblem = 5,
        //캠프파이어
        CampFire = 6
    }
    AudioSource audioClip; // 오디오의 클립
    Animator anis; // 애니메이션
    public bool aniCtr; // 게임 시작시 애니메이션을 실행시킬것인가 아닐것인가?
    public string aniName; // 애니메이션 실핼될 이름
    public int aniInt; // 해당 레이어에 애니메이션이 실행될 번호
    public string aniObjtag; // 애니메이션이 실핼될 태그 구분
    public string layerNames; // 레이어 이름.
    LayerNameobj lsobj;
    void Start()
    {
        audioClip = GetComponent<AudioSource>();
        anis = GetComponent<Animator>();
    }
    void ObjEfectlayer()
    {
        switch (layerNames)
        {
            case "Idle":
                ActivateLayer(LayerNameobj.Idle);
                transform.GetComponent<Collider2D>().isTrigger = true;
                break;
            case "Fountain":
                ActivateLayer(LayerNameobj.Fountain);
                break;
            case "PlasiaEmblem":
                ActivateLayer(LayerNameobj.PlasiaEmblem);
                break;
            case "water":
                ActivateLayer(LayerNameobj.water);
                break;
            case "bubble":
                ActivateLayer(LayerNameobj.bubble);
                break;
            case "HaresEmblem":
                ActivateLayer(LayerNameobj.HaresEmblem);
                break;
            case "CampFire":
                ActivateLayer(LayerNameobj.CampFire);
                break;
        }

    }
    void OnTriggerEnter2D(Collider2D objs)
    {
        if (objs.CompareTag(aniObjtag))
        {
            if (aniInt == 0)
            {
                anis.SetBool(aniName, true);
            }
            else
            {
                anis.SetInteger(aniName, aniInt);
            }
            ObjEfectlayer();
        }
    }
    void OnTriggerExit2D(Collider2D objs)
    {
        if (objs.CompareTag(aniObjtag))
        {
            if (aniInt == 0)
            {
                anis.SetBool(aniName, false);
            }
            else
            {
                anis.SetInteger(aniName, -1);
            }
        }
    }

    public void ActivateLayer(LayerNameobj layerName)
    {
        // 모든 레이어의 무게값을 0 으로 만들어 줍니다.
        for (int i = 0; i < anis.layerCount; i++)
        {
            anis.SetLayerWeight(i, 0);
        }
        anis.SetLayerWeight((int)layerName, 1);
    }

}