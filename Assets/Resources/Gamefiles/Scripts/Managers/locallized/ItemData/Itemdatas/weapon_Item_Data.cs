using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class weapon_Item_Data
{
    [Header(" - 아이템 이름")]
    [Header(" - 이펙트가 있는가?")]
    public bool Effect;
    public string item_Name;   // 아이템 이름 (중복 가능)
    [Header("아이템 정보")]
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
    [Header(" - 공격 속도 : 기본 0.7~2.5")]
    public float attack_Speed; // 공격 속도를 정함. --> 공속 맥스 2.5~0.7.
    [Header(" - 공격 방식 : 기본 1 ~ 맥스 @")]
    public attackType attack_Range; // 공격 범위를 정함. --> 기본공격 범위 1. 공격 범위 아직 미정.
    //아이템 기초 정보
    [Header(" - 아이템 소지개수")]
    public int item_Count; // 아이템 소지 개수.
    [Header(" - 아이템 가격")]
    public int item_Price; // 아이템 가격
    [Header(" - 아이템 설명")]
    [TextArea]
    public string item_Ex; // 아이템 설명 내용

    public weapon_Item_Data()
    { }
    // 무기.
    public weapon_Item_Data(bool _Effect,info _info, bool _isEquip, ItemClass _itemClase, int _item_Numbers, string _item_Name, int _holy_Power, int _neutrality_Power, int _heresy_Power, int _damage, float _attack_Speed, attackType _attack_Range, int _item_Count, int _item_Price, string _item_Ex)
    {
        Effect = _Effect;
        info = _info;
        isEquip = _isEquip; // 장착 가능지에 대해.
        itemClass = _itemClase; // 아이템 등급
        item_Numbers = _item_Numbers; // 아아템 고유 번호
        item_Name = _item_Name; // 아이템 이름
        holy_Power = _holy_Power;  // 신성파워
        neutrality_Power = _neutrality_Power;   // 중립파워
        heresy_Power = _heresy_Power;   // 타락파워.
        damage = _damage; // 데미지
        attack_Speed = _attack_Speed; // 공격 속도
        attack_Range = _attack_Range; // 공격 범위
        item_Count = _item_Count;
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }
}