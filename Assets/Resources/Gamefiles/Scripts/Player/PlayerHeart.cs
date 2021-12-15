using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[HideInInspector]
public class PlayerHeart : MonoBehaviour
{
    public Image[] Player_HeartImage; // 체력 이미지
    public AudioSource audioSource;   // 체력사운드
    public Animator[] animator; // 체력애니메이터들의 집합체
    AnimatorClipInfo[] firstAnimatorClip; // 첫번째 애니메이터의 클립들
    void Start()
    {
        animator = GameObject.Find("HeartHUD").transform.GetComponentsInChildren<Animator>();
        Player_HeartImage = GameObject.Find("HeartHUD").transform.GetComponentsInChildren<Image>();
        StartCoroutine(Heartanimation());
        StartCoroutine(Health_recovery_Time());
    }
    void HeartLost(int i)
    {
        animator[i].SetBool("Lost", true);
    }

    void HeartIdle(int i)
    {
        AnimatorStateInfo anis; // 애니메이터의현재 실행정보를 담을 변수
        anis = animator[0].GetCurrentAnimatorStateInfo(0);    // 애니메이터의 에니메이션의 현재 상태를 찾는다.
        
        float timesk = anis.normalizedTime + Time.deltaTime;  // 현재 애니메이션 진행상태 + 첫번째 애니메이터의 클립의 길이를 더한다.
        // 애니메이터 동기화를 위한 장치.
        animator[i].Play("Player_Heart_Idle", 0, timesk);   // i들의 애니메이터를 동기화 시킨다. 현재 진행중인 0번의 애미네이터 길이만큼 동기화 시킨다.
        // 애니메이터 전환 bool.
        animator[i].SetBool("Lost", false);
    }
    //time = recovery time (재생시간) Hearth_recovery_num = 재생할떄 차는 체력 개수.
    IEnumerator Health_recovery_Time(int Health_recovery_num = 1)
    {
        for (int i = 0; i < Player_HeartImage.Length; i++)
            yield return new WaitUntil(() => animator[i].GetBool("Lost") == true);

        yield return new WaitForSeconds(DataManager.instance.heart_Recovery_Time);
        if (DataManager.instance.health != DataManager.instance.healthMax)
        {
            DataManager.instance.health += Health_recovery_num;
        }
        StartCoroutine(Health_recovery_Time());
    }
    IEnumerator Heartanimation()
    {
        // 현재 체력이 몇개인지 실시간으로 체크한다.
        for (int i = 0; i < Player_HeartImage.Length; i++)
        {
            if (i < DataManager.instance.health && animator[i].GetBool("Lost") == true)       // i보다 플레이어의 현재체력이 높을경우
            {
                HeartIdle(i);
            }
            else if (DataManager.instance.health != DataManager.instance.healthMax) // 현재 체력과 플레이어의 맥스체력이 다를경우
            {
                HeartLost(i);
            }
            // 플레이어 최대 체력치를 나타냄.
            // i의 갯수만큼 체력바를 증가시킴 표시함.
            if (i < DataManager.instance.healthMax)
                Player_HeartImage[i].enabled = true;
            else
                Player_HeartImage[i].enabled = false;
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Heartanimation());
    }
    public void stiks()
    {
        DataManager.instance.health -= 1;
    }
}
