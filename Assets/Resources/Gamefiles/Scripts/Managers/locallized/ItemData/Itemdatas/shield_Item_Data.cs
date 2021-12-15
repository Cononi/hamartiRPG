using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class shield_Item_Data
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
    // 무기제외한 나머지 장비 공통사항.
    [Header(" - 피격시 무적 확률 : 체력이 달지않고 맥스 30%")]
    public int stance; // 높으면 피격시 일정확률로 피가 달지 않는다. --> 맥스 피격확률 30% 
    [Header(" - 넉백 면역 : 아이템 맥스 30% 패시브 20%")]
    public int push_Stance; // 일정 확률로 밀치기에 면역이 된다. --> 아이템 맥스 30%, 패시브 20%
    [Header(" - 경직 면역 : 아이템 맥스 30%, 패시브 20% ")]
    public int stiffen_Stance; // 일정 확률로 경직에 걸리지 않는다 --> 아이템 맥스 30%, 패시브 20%
                               //아이템 기초 정보
    [Header(" - 아이템 소지개수")]
    public int item_Count; // 아이템 소지 개수.
    [Header(" - 아이템 가격")]
    public int item_Price; // 아이템 가격
    [Header(" - 아이템 설명")]
    [TextArea]
    public string item_Ex; // 아이템 설명 내용
    public string imageName;

    public shield_Item_Data()
    { }
    // 방패
    public shield_Item_Data(bool _Effect,info _info, bool _isEquip, ItemClass _itemClase, int _item_Numbers, string _item_Name, int _holy_Power, int _neutrality_Power, int _heresy_Power, int _stance, int _push_Stance, int _stiffen_Stance, int _item_Count, int _item_Price, string _item_Ex)
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
        stance = _stance; // 높으면 피격시 일정확률로 피가 달지 않는다. --> 맥스 피격확률 30%
        push_Stance = _push_Stance; // 일정 확률로 밀치기에 면역이 된다. --> 아이템 맥스 50%, 패시브 20%
        stiffen_Stance = _stiffen_Stance; //일정 확률로 경직에 걸리지 않는다 --> 아이템 맥스 30%, 패시브 20%
        item_Count = _item_Count;
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }
}