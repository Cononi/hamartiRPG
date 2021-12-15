using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class shoes_Item_Data
{
    [Header("아이템 정보")]
    [Header(" - 이펙트가 있는가?")]
    public bool Effect;
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
    // 신발.
    [Header(" - 이동 속도 감소 면역 : 아이템 맥스 3")]
    public float move_Slow; // 이동 속도 감소효과를 줄여준다 --> 아이템 맥스 3;
    [Header(" - 이동 속도 : 아이템 맥스 +4")]
    public float eq_Speed; // 높으면 이동 속도가 빨라진다. --> 이속 맥스 +4
    //아이템 기초 정보
    [Header(" - 아이템 소지개수")]
    public int item_Count; // 아이템 소지 개수.
    [Header(" - 아이템 가격")]
    public int item_Price; // 아이템 가격
    [Header(" - 아이템 설명")]
    [TextArea]
    public string item_Ex; // 아이템 설명 내용

    public shoes_Item_Data()
    { }
    //신발
    public shoes_Item_Data(bool _Effect,info _info, bool _isEquip, ItemClass _itemClase, int _item_Numbers, string _item_Name, int _holy_Power, int _neutrality_Power, int _heresy_Power, float _eq_Speed, float _move_Slow, int _item_Count, int _item_Price, string _item_Ex)
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
        eq_Speed = _eq_Speed; // 이동 속도.
        move_Slow = _move_Slow; // 슬로우 감소 면역력.
        item_Count = _item_Count;
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }
}