using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Consumable_Item_Data
{
    public info info;
    [Header("아이템 정보")]
    [Header(" - 아이템 이름")]
    public string item_Name;   // 아이템 이름 (중복 가능)
    [Header(" - 소모성 아이템인지")]
    public bool isConsumable; // 소모성 아이템인가 체크.
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
    // 반지, 목걸이
    [Header(" - 체력 생성 확률 : 체력 생성 확률 맥스 10%")]
    public int attack_Vampire; // 공격시 일정확률로 체력 생성함. --> 맥스 체력 생성 확률 10%
    [Header(" - 스킬 소모도 감소 확률 : 감소 확률 맥스 50%")]
    public int heart_Stance; // 높은면 일정 확률로 스킬사용시 체력소모가 반으로 줄어든다. --> 맥스 소모 확률 50%
    [Header(" - 체력 재생 시간 감소 : 맥스 3초")]
    public float heart_Recovery_Time; // 체력 재생시간을 줄여준다. --> 맥스 3초
    // 무기제외한 나머지 장비 공통사항.
    [Header(" - 피격시 무적 확률 : 체력이 달지않고 맥스 30%")]
    public int stance; // 높으면 피격시 일정확률로 피가 달지 않는다. --> 맥스 피격확률 30% 
    [Header(" - 넉백 면역 : 아이템 맥스 30% 패시브 20%")]
    public int push_Stance; // 일정 확률로 밀치기에 면역이 된다. --> 아이템 맥스 30%, 패시브 20%
    [Header(" - 죽음의 면역 : 일정 확률로 죽지않는다 아이템 맥스 : 10%, 패시브 맥스 : 10%")]
    public int phoenix_Stance; // 체력이 0이되어도 일정확률로 죽지 않고 살아난다 --> 아이템 맥스 10%, 패시브 맥스 10%.
    [Header(" - 경직 면역 : 아이템 맥스 30%, 패시브 20% ")]
    public int stiffen_Stance; // 일정 확률로 경직에 걸리지 않는다 --> 아이템 맥스 30%, 패시브 20%
    // 장갑 신발.
    [Header(" - 이동 속도 감소 면역 : 아이템 맥스 3")]
    public float move_Slow; // 이동 속도 감소효과를 줄여준다 --> 아이템 맥스 3;
    [Header(" - 이동 속도 : 아이템 맥스 +4")]
    public float eq_Speed; // 높으면 이동 속도가 빨라진다. --> 이속 맥스 +4
    // 소모성 아이템
    [Header(" - 맥스 체력 : 체력 한계치.")]
    public int hpmax_Potion; // 체력 한계치를 늘려준다. //맥스 20개.

    //아이템 기초 정보
    [Header(" - 아이템 소지개수")]
    public int item_Count; // 아이템 소지 개수.
    [Header(" - 아이템 가격")]
    public int item_Price; // 아이템 가격
    [Header(" - 아이템 설명")]
    [TextArea]
    public string item_Ex; // 아이템 설명 내용

    // 소모아이템.
    public Consumable_Item_Data(info _info, bool _isConsumable, ItemClass _itemClase, int _item_Numbers, string _item_Name, int _holy_Power, int _neutrality_Power, int _heresy_Power, int _damage, float _attack_Speed,
    int _attack_Vampire, int _heart_Stance, float _heart_Recovery_Time, int _stance, int _push_Stance, int _phoenix_Stance, int _stiffen_Stance, float _move_Slow, float _eq_Speed, int hpmax_Potion, int _item_Count, int _item_Price, string _item_Ex)
    {
        info = _info; // 아이템 종류
        isConsumable = _isConsumable; // 소모성 아이템인가?
        itemClass = _itemClase; // 아이템 등급
        item_Numbers = _item_Numbers; // 아아템 고유 번호
        item_Name = _item_Name; // 아이템 이름
        holy_Power = _holy_Power;
        neutrality_Power = _neutrality_Power;
        heresy_Power = _heresy_Power;
        damage = _damage;
        attack_Speed = _attack_Speed;
        attack_Vampire = _attack_Vampire;
        heart_Stance = _heart_Stance;
        heart_Recovery_Time = _heart_Recovery_Time;
        stance = _stance;
        push_Stance = _push_Stance;
        phoenix_Stance = _phoenix_Stance;
        stiffen_Stance = _stiffen_Stance;
        move_Slow = _move_Slow;
        eq_Speed = _eq_Speed;
        hpmax_Potion = _item_Numbers; // 맥스 체력포션.
        item_Count = _item_Count;
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }

}