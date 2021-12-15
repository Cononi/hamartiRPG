using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Other_Quest_Item_Data
{
    public info info;
    [Header("아이템 정보")]
    [Header(" - 아이템 이름")]
    public string item_Name;   // 아이템 이름 (중복 가능)
    [Header(" - 아이템 정보")]
    public type item_style;   // 아이템 종류
    [Header(" - 장착 가능 아이템인지")]
    public bool isEquip; // 장착 가능한 아이템인가 체크.
    [Header(" - 아이템 등급")]
    public ItemClass itemClass;
    [Header(" - 소모성 아이템인지")]
    public bool isConsumable; // 소모성 아이템인가 체크.
    [Header(" - 아이템 고유번호")]
    public int item_Numbers; //아이템 고유 번호(중복 불가)
    //아이템 기초 정보
    [Header(" - 아이템 소지개수")]
    public int item_Count; // 아이템 소지 개수.
    [Header(" - 아이템 가격")]
    public int item_Price; // 아이템 가격
    [Header(" - 아이템 설명")]
    [TextArea]
    public string item_Ex; // 아이템 설명 내용

    // 기타, 퀘스트 아이템
    public Other_Quest_Item_Data(info _info, bool _isConsumable, ItemClass _itemClase, bool _isEquip, int _item_Numbers, string _item_Name, type _item_Style, int _item_Count, int _item_Price, string _item_Ex)
    {
        info = _info;
        isConsumable = _isConsumable; // 소모성 아이템인가?
        itemClass = _itemClase; // 아이템 등급
        isEquip = _isEquip; // 장비 아이템인가?
        item_Numbers = _item_Numbers; // 아아템 고유 번호
        item_Name = _item_Name; // 아이템 이름
        item_style = _item_Style; // 아이템 종류
        item_Count = _item_Count; // 아이템 맥스 소지개수
        item_Price = _item_Price; // 아이템 가격
        item_Ex = _item_Ex; // 아이템 설명.
    }
}
