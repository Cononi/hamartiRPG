using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
//직렬화 가능한 클래스임을 명시함.
//객체를 '연속적인 데이터'로 변환하는 것. 반대과정은 역직렬화
//[NonSerialized] 직렬화를 하지 않을때.
//오브젝트 직렬화 클래스.


[Serializable]
public enum info
{
    Default,
    WEAPONS, // 무기목록
    SHIELDS, // 보조목록
    HELMATS, // 헬맷목록
    ARMORS, // 갑옷목록
    GLOVES, // 장갑목록
    SHOES, // 신발목록
    RINGS, // 반지목록
    NECKLACES, // 목걸이목록
    CONSUMABLES, // 소비아이템목록
    OTHERS // 오더목록

}
[Serializable]
public enum ItemClass
{
    낡아빠진,
    흔해빠진,
    특별해진,
    희귀해진,
    전설적인
}
[Serializable]
public enum type
{
    ETC,
    QUEST,
    EXP
}
[Serializable]
public enum attackType
{
    무방비,
    공격형,
    방어형,
    버프형
}
[Serializable]
// 내용물의 집합체 클래스.
public class LocalizationItemData
{
    public List<weapon_Item_Data> weapon_Item_Datas;
    public List<shield_Item_Data> shield_Item_Datas;
    public List<helmat_Item_Data> helmat_Item_Datas;
    public List<armor_Item_Data> armor_Item_Datas;
    public List<gloves_Item_Data> gloves_Item_Datas;
    public List<shoes_Item_Data> shoes_Item_Datas;
    public List<ring_Item_Data> ring_Item_Datas;
    public List<necklace_Item_Data> necklace_Item_Datas;
    public List<Consumable_Item_Data> consumable_Item_Datas;
    public List<Other_Quest_Item_Data> other_Quest_Item_Datas;
}

/* [Serializable]
public class LocalizationItemDataT
{
    public info info;
    [Header("아이템 정보")]
    [Header(" - 장착 가능 아이템인지")]
    public bool isEquip; // 장착 가능한 아이템인가 체크.
    [Header(" - 소모성 아이템인지")]
    public bool isConsumable; // 소모성 아이템인가 체크.
    [Header(" - 아이템 고유번호")]
    public int item_Numbers; //아이템 고유 번호(중복 불가)
    [Header(" - 아이템 이름")]
    public string item_Name;   // 아이템 이름 (중복 가능)
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
    [Header(" - 공격 범위 : 기본 1 ~ 맥스 @")]
    public Vector2 attack_Range; // 공격 범위를 정함. --> 기본공격 범위 1. 공격 범위 아직 미정.
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
    [Header(" - 아이템 최대 소지 개수")]
    //아이템 기초 정보
    public int item_Max_Count; // 아이템 소지 개수.
    [Header(" - 아이템 가격")]
    public int item_Price; // 아이템 가격
    [Header(" - 아이템 설명")]
    [TextArea]
    public string item_Ex; // 아이템 설명 내용

    // 무기.
    public LocalizationItemDataT(bool _isEquip, int _item_Numbers, string _item_Name, int _holy_Power, int _neutrality_Power, int _heresy_Power, int _damage, float _attack_Speed, Vector2 _attack_Range, int _item_Price, string _item_Ex)
    {
        isEquip = _isEquip; // 장착 가능지에 대해.
        item_Numbers = _item_Numbers; // 아아템 고유 번호
        item_Name = _item_Name; // 아이템 이름
        holy_Power = _holy_Power;  // 신성파워
        neutrality_Power = _neutrality_Power;   // 중립파워
        heresy_Power = _heresy_Power;   // 타락파워.
        damage = _damage; // 데미지
        attack_Speed = _attack_Speed; // 공격 속도
        attack_Range = _attack_Range; // 공격 범위
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }
    // 투구, 방패
    public LocalizationItemDataT(bool _isEquip, int _item_Numbers, string _item_Name, int _holy_Power, int _neutrality_Power, int _heresy_Power, int _stance, int _push_Stance, int _item_Price, string _item_Ex)
    {
        isEquip = _isEquip; // 장착 가능지에 대해.
        item_Numbers = _item_Numbers; // 아아템 고유 번호
        item_Name = _item_Name; // 아이템 이름
        holy_Power = _holy_Power;  // 신성파워
        neutrality_Power = _neutrality_Power;   // 중립파워
        heresy_Power = _heresy_Power;   // 타락파워.
        stance = _stance; // 높으면 피격시 일정확률로 피가 달지 않는다. --> 맥스 피격확률 50%
        push_Stance = _push_Stance; // 일정 확률로 밀치기에 면역이 된다. --> 아이템 맥스 50%, 패시브 20%
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }
    // 갑옷.
    public LocalizationItemDataT(bool _isEquip, int _item_Numbers, string _item_Name, int _holy_Power, int _neutrality_Power, int _heresy_Power, int _stance, int _stiffen_Stance, int _phoenix_Stance, int _item_Price, string _item_Ex)
    {
        isEquip = _isEquip; // 장착 가능지에 대해.
        item_Numbers = _item_Numbers; // 아아템 고유 번호
        item_Name = _item_Name; // 아이템 이름
        holy_Power = _holy_Power;  // 신성파워
        neutrality_Power = _neutrality_Power;   // 중립파워
        heresy_Power = _heresy_Power;   // 타락파워.
        stance = _stance; // 높으면 피격시 일정확률로 피가 달지 않는다. --> 맥스 피격확률 50%
        stiffen_Stance = _stiffen_Stance; // 일정 확률로 경직에 걸리지 않는다 --> 아이템 맥스 50%, 패시브 20%
        phoenix_Stance = _phoenix_Stance; // 체력이 0이되어도 일정확률로 죽지 않고 살아난다 --> 아이템 맥스 10%, 패시브 맥스 10%.
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }
    //신발
    public LocalizationItemDataT(bool _isEquip, int _item_Numbers, string _item_Name, int _holy_Power, int _neutrality_Power, int _heresy_Power, float _eq_Speed, float _move_Slow, int _item_Price, string _item_Ex)
    {
        isEquip = _isEquip; // 장착 가능지에 대해.
        item_Numbers = _item_Numbers; // 아아템 고유 번호
        item_Name = _item_Name; // 아이템 이름
        holy_Power = _holy_Power;  // 신성파워
        neutrality_Power = _neutrality_Power;   // 중립파워
        heresy_Power = _heresy_Power;   // 타락파워.
        eq_Speed = _eq_Speed; // 이동 속도.
        move_Slow = _move_Slow; // 슬로우 감소 면역력.
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }
    // 장갑
    public LocalizationItemDataT(bool _isEquip, int _item_Numbers, string _item_Name, int _holy_Power, int _neutrality_Power, int _heresy_Power, float _eq_Speed, float _move_Slow, int _damage, float _attack_Speed, int _item_Price, string _item_Ex)
    {
        isEquip = _isEquip; // 장착 가능지에 대해.
        item_Numbers = _item_Numbers; // 아아템 고유 번호
        item_Name = _item_Name; // 아이템 이름
        holy_Power = _holy_Power;  // 신성파워
        neutrality_Power = _neutrality_Power;   // 중립파워
        heresy_Power = _heresy_Power;   // 타락파워.
        damage = _damage; // 데미지.
        attack_Speed = _attack_Speed;  // 공격 속도
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }
    // 링, 목걸이
    public LocalizationItemDataT(bool _isEquip, int _item_Numbers, string _item_Name, int _holy_Power, int _neutrality_Power, int _heresy_Power, int _damage, int _attack_Vampire, float _heart_Recovery_Time, int _heart_Stance, int _item_Price, string _item_Ex)
    {
        isEquip = _isEquip; // 장착 가능지에 대해.
        item_Numbers = _item_Numbers; // 아아템 고유 번호
        item_Name = _item_Name; // 아이템 이름
        holy_Power = _holy_Power;  // 신성파워
        neutrality_Power = _neutrality_Power;   // 중립파워
        heresy_Power = _heresy_Power;   // 타락파워.
        damage = _damage; // 데미지
        attack_Vampire = _attack_Vampire; // 일정확률 체력 생성 능력
        heart_Recovery_Time = _heart_Recovery_Time; // 체력 재생 시간
        heart_Stance = _heart_Stance;   // 스킬 사용시 일정확률 체력 감소 반감.
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }
    // 소모아이템.
    public LocalizationItemDataT(bool _isConsumable, int _item_Numbers, string _item_Name, int hpmax_Potion, int _item_Price, string _item_Ex)
    {
        isConsumable = _isConsumable; // 소모성 아이템인가?
        item_Numbers = _item_Numbers; // 아아템 고유 번호
        item_Name = _item_Name; // 아이템 이름
        hpmax_Potion = _item_Numbers; // 맥스 체력포션.
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }
    // 퀘스트아이템.
    public LocalizationItemDataT(bool _isConsumable, bool _isEquip, int _item_Numbers, string _item_Name, int _item_Price, string _item_Ex)
    {
        isConsumable = _isConsumable; // 소모성 아이템인가?
        isEquip = _isEquip;
        item_Numbers = _item_Numbers; // 아아템 고유 번호
        item_Name = _item_Name; // 아이템 이름
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    } 
}*/
