using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class necklace_Item_Data
{
    [Header("아이템 정보")]
    [Header(" - 아이템 이름")]
    public string item_Name;   // 아이템 이름 (중복 가능)
    public info info;
    [Header(" - 장착 가능 아이템인지")]
    public bool isEquip; // 장착 가능한 아이템인가 체크.
    [Header(" - 아이템 등급")]
    public ItemClass itemClass;
    [Header(" - 아이템 고유번호")]
    public int item_Numbers; //아이템 고유 번호(중복 불가)
    [Header(" - 신성한힘")]
    public int holy_Power; // 신성 파워.
    [Header(" - 원초적인힘")]
    public int neutrality_Power; // 중립 파워.
    [Header(" - 타락한힘")]
    public int heresy_Power; // 타락 파워.
    // 무기
    [Header(" - 데미지")]
    public int damage; // 데미지
    // 반지, 목걸이
    [Header(" - 체력 생성 확률 : 체력 생성 확률 맥스 10%")]
    public int attack_Vampire; // 공격시 일정확률로 체력 생성함. --> 맥스 체력 생성 확률 10%
    [Header(" - 스킬 소모도 감소 확률 : 감소 확률 맥스 50%")]
    public int heart_Stance; // 높은면 일정 확률로 스킬사용시 체력소모가 반으로 줄어든다. --> 맥스 소모 확률 50%
    [Header(" - 체력 재생 시간 감소 : 맥스 3초")]
    public float heart_Recovery_Time; // 체력 재생시간을 줄여준다. --> 맥스 3초
                                      //아이템 기초 정보
    [Header(" - 아이템 소지개수")]
    public int item_Count; // 아이템 소지 개수.
    [Header(" - 아이템 가격")]
    public int item_Price; // 아이템 가격
    [Header(" - 아이템 설명")]
    [TextArea]
    public string item_Ex; // 아이템 설명 내용

    public necklace_Item_Data()
    { }
    // 링, 목걸이
    public necklace_Item_Data(info _info, bool _isEquip, ItemClass _itemClase, int _item_Numbers, string _item_Name, int _holy_Power, int _neutrality_Power, int _heresy_Power, int _damage, int _attack_Vampire, float _heart_Recovery_Time, int _heart_Stance, int _item_Count, int _item_Price, string _item_Ex)
    {
        info = _info;
        isEquip = _isEquip; // 장착 가능지에 대해.
        itemClass = _itemClase; // 아이템 등급
        item_Numbers = _item_Numbers; // 아아템 고유 번호
        item_Name = _item_Name; // 아이템 이름
        holy_Power = _holy_Power;  // 신성파워
        neutrality_Power = _neutrality_Power;   // 중립파워
        heresy_Power = _heresy_Power;   // 타락파워.
        damage = _damage; // 데미지
        attack_Vampire = _attack_Vampire; // 일정확률 체력 생성 능력
        heart_Recovery_Time = _heart_Recovery_Time; // 체력 재생 시간
        heart_Stance = _heart_Stance;   // 스킬 사용시 일정확률 체력 감소 반감.
        item_Count = _item_Count;
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }
}