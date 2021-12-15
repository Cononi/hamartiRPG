using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class slots : MonoBehaviour, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IEndDragHandler, IPointerClickHandler
{
    public info info; // 아이템 정보
    public float DropItemNumber;
    public int ItemCount;
    public int number;
    public LocalizationItemData item;
    public bool checkItem;
    public bool checkItemDrop;
    public bool checkItemEquip;
    public bool questItem;
    public Text ItemCountText;
    private RectTransform slots_Pivot;
    void Start()
    {
        slots_Pivot = transform.GetChild(0).GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData data)
    {
        if (checkItem != false)
        {
            if (transform.childCount > 0)
            {
                transform.GetChild(0).SetParent(Inventory.instance.draggingItem);
                slots_Pivot.pivot = new Vector2(1.001f, -0.001f);
                slots_Pivot.localScale = new Vector2(1.3f, 1.3f);
                Inventory.instance.enteredSlot = null;
            }
            Inventory.instance.draggingItem.GetChild(0).position = new Vector3(data.position.x, data.position.y, 0);
        }
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (info.Default != Inventory.instance.enteredSlot.info)
        {
            Inventory.instance.invenSlotInfo.SetActive(true);
            InvenInfoitem(info);
        }
    }
    public void InvenInfoitem(info info)
    {
        Inventory.instance.infonameSub.text = "";
        Inventory.instance.isEquip.ItemsClear();
        switch (info)
        {
            case info.HELMATS:
                Inventory.instance.infonameText.text = item.helmat_Item_Datas[0].item_Name;
                switch (item.helmat_Item_Datas[0].itemClass)
                {
                    case ItemClass.낡아빠진:
                        Inventory.instance.infonameSub.text = "<color=#777777>" + item.helmat_Item_Datas[0].itemClass.ToString() + " 투구</color>";
                        break;
                    case ItemClass.흔해빠진:
                        Inventory.instance.infonameSub.text = "<color=#DDDDDD>" + item.helmat_Item_Datas[0].itemClass.ToString() + " 투구</color>";
                        break;
                    case ItemClass.특별해진:
                        Inventory.instance.infonameSub.text = "<color=#3399FF>" + item.helmat_Item_Datas[0].itemClass.ToString() + " 투구</color>";
                        break;
                    case ItemClass.희귀해진:
                        Inventory.instance.infonameSub.text = "<color=#996699>" + item.helmat_Item_Datas[0].itemClass.ToString() + " 투구</color>";
                        break;
                    case ItemClass.전설적인:
                        Inventory.instance.infonameSub.text = "<color=#FFCC00>" + item.helmat_Item_Datas[0].itemClass.ToString() + " 투구</color>";
                        break;
                }
                Inventory.instance.infoText.text = (item.helmat_Item_Datas[0].holy_Power != 0 ? "신성 : " + item.helmat_Item_Datas[0].holy_Power.ToString() + "\n" : "") +
                                                    (item.helmat_Item_Datas[0].neutrality_Power != 0 ? "중립 : " + item.helmat_Item_Datas[0].neutrality_Power.ToString() + "\n" : "") +
                                                    (item.helmat_Item_Datas[0].heresy_Power != 0 ? "타락 : " + item.helmat_Item_Datas[0].heresy_Power.ToString() + "\n" : "") +
                                                      (item.helmat_Item_Datas[0].stance != 0 ? "회피 확률 : " + item.helmat_Item_Datas[0].stance.ToString() + "\n" : "") +
                                                        (item.helmat_Item_Datas[0].stiffen_Stance != 0 ? "스턴 면역 : " + item.helmat_Item_Datas[0].stiffen_Stance + "\n\n" : "\n\n") +
                                                         (item.helmat_Item_Datas[0].item_Price != 0 ? "가격 : " + item.helmat_Item_Datas[0].item_Price + "\n" : "");
                Inventory.instance.infoitemExp.text = item.helmat_Item_Datas[0].item_Ex;
                Inventory.instance.isEquip.itemData.helmat_Item_Datas.Add(item.helmat_Item_Datas[0]);
                break;
            case info.ARMORS:
                Inventory.instance.infonameText.text = item.armor_Item_Datas[0].item_Name;
                switch (item.armor_Item_Datas[0].itemClass)
                {
                    case ItemClass.낡아빠진:
                        Inventory.instance.infonameSub.text = "<color=#777777>" + item.armor_Item_Datas[0].itemClass.ToString() + " 갑옷</color>";
                        break;
                    case ItemClass.흔해빠진:
                        Inventory.instance.infonameSub.text = "<color=#DDDDDD>" + item.armor_Item_Datas[0].itemClass.ToString() + " 갑옷</color>";
                        break;
                    case ItemClass.특별해진:
                        Inventory.instance.infonameSub.text = "<color=#3399FF>" + item.armor_Item_Datas[0].itemClass.ToString() + " 갑옷</color>";
                        break;
                    case ItemClass.희귀해진:
                        Inventory.instance.infonameSub.text = "<color=#996699>" + item.armor_Item_Datas[0].itemClass.ToString() + " 갑옷</color>";
                        break;
                    case ItemClass.전설적인:
                        Inventory.instance.infonameSub.text = "<color=#FFCC00>" + item.armor_Item_Datas[0].itemClass.ToString() + " 갑옷</color>";
                        break;
                }
                Inventory.instance.infoText.text = (item.armor_Item_Datas[0].holy_Power != 0 ? "신성 : " + item.armor_Item_Datas[0].holy_Power.ToString() + "\n" : "") +
                                                    (item.armor_Item_Datas[0].neutrality_Power != 0 ? "중립 : " + item.armor_Item_Datas[0].neutrality_Power.ToString() + "\n" : "") +
                                                    (item.armor_Item_Datas[0].heresy_Power != 0 ? "타락 : " + item.armor_Item_Datas[0].heresy_Power.ToString() + "\n" : "") +
                                                     (item.armor_Item_Datas[0].Player_numOFHeart != 0 ? "최대 체력 증가 : " + item.armor_Item_Datas[0].Player_numOFHeart.ToString() + "\n" : "") +
                                                      (item.armor_Item_Datas[0].stance != 0 ? "회피 확률 : " + item.armor_Item_Datas[0].stance.ToString() + "\n" : "") +
                                                      (item.armor_Item_Datas[0].phoenix_Stance != 0 ? "죽음 면역 : " + item.armor_Item_Datas[0].phoenix_Stance + "\n" : "") +
                                                       (item.armor_Item_Datas[0].stiffen_Stance != 0 ? "스턴 면역 : " + item.armor_Item_Datas[0].stiffen_Stance + "\n\n" : "\n\n") +
                                                        (item.armor_Item_Datas[0].item_Price != 0 ? "가격 : " + item.armor_Item_Datas[0].item_Price + "\n" : "");
                Inventory.instance.infoitemExp.text = item.armor_Item_Datas[0].item_Ex;
                Inventory.instance.isEquip.itemData.armor_Item_Datas.Add(item.armor_Item_Datas[0]);
                break;
            case info.WEAPONS:
                Inventory.instance.infonameText.text = item.weapon_Item_Datas[0].item_Name;
                switch (item.weapon_Item_Datas[0].itemClass)
                {
                    case ItemClass.낡아빠진:
                        Inventory.instance.infonameSub.text = "<color=#777777>" + item.weapon_Item_Datas[0].itemClass.ToString() + " 무기</color>";
                        break;
                    case ItemClass.흔해빠진:
                        Inventory.instance.infonameSub.text = "<color=#DDDDDD>" + item.weapon_Item_Datas[0].itemClass.ToString() + " 무기</color>";
                        break;
                    case ItemClass.특별해진:
                        Inventory.instance.infonameSub.text = "<color=#3399FF>" + item.weapon_Item_Datas[0].itemClass.ToString() + " 무기</color>";
                        break;
                    case ItemClass.희귀해진:
                        Inventory.instance.infonameSub.text = "<color=#996699>" + item.weapon_Item_Datas[0].itemClass.ToString() + " 무기</color>";
                        break;
                    case ItemClass.전설적인:
                        Inventory.instance.infonameSub.text = "<color=#FFCC00>" + item.weapon_Item_Datas[0].itemClass.ToString() + " 무기</color>";
                        break;
                }
                Inventory.instance.infoText.text = (item.weapon_Item_Datas[0].damage != 0 ? "데미지 : " + item.weapon_Item_Datas[0].damage + "\n" : "") +
                                                    (item.weapon_Item_Datas[0].attack_Speed != 0 ? "공격속도 : " + item.weapon_Item_Datas[0].attack_Speed + "\n" : "") +
                                                    (item.weapon_Item_Datas.Count != 0 ? "공격 방식 : " + item.weapon_Item_Datas[0].attack_Range + "\n" : DataManager.instance.attack_Range + "") +
                                                    (item.weapon_Item_Datas[0].holy_Power != 0 ? "신성 : " + item.weapon_Item_Datas[0].holy_Power.ToString() + "\n" : "") +
                                                    (item.weapon_Item_Datas[0].neutrality_Power != 0 ? "중립 : " + item.weapon_Item_Datas[0].neutrality_Power.ToString() + "\n" : "") +
                                                    (item.weapon_Item_Datas[0].heresy_Power != 0 ? "타락 : " + item.weapon_Item_Datas[0].heresy_Power.ToString() + "\n\n" : "\n\n") +
                                                    (item.weapon_Item_Datas[0].item_Price != 0 ? "가격 : " + item.weapon_Item_Datas[0].item_Price + "\n" : "");
                Inventory.instance.infoitemExp.text = item.weapon_Item_Datas[0].item_Ex;
                Inventory.instance.isEquip.itemData.weapon_Item_Datas.Add(item.weapon_Item_Datas[0]);
                break;
            case info.SHIELDS:
                Inventory.instance.infonameText.text = item.shield_Item_Datas[0].item_Name;
                switch (item.shield_Item_Datas[0].itemClass)
                {
                    case ItemClass.낡아빠진:
                        Inventory.instance.infonameSub.text = "<color=#777777>" + item.shield_Item_Datas[0].itemClass.ToString() + " 방패</color>";
                        break;
                    case ItemClass.흔해빠진:
                        Inventory.instance.infonameSub.text = "<color=#DDDDDD>" + item.shield_Item_Datas[0].itemClass.ToString() + " 방패</color>";
                        break;
                    case ItemClass.특별해진:
                        Inventory.instance.infonameSub.text = "<color=#3399FF>" + item.shield_Item_Datas[0].itemClass.ToString() + " 방패</color>";
                        break;
                    case ItemClass.희귀해진:
                        Inventory.instance.infonameSub.text = "<color=#996699>" + item.shield_Item_Datas[0].itemClass.ToString() + " 방패</color>";
                        break;
                    case ItemClass.전설적인:
                        Inventory.instance.infonameSub.text = "<color=#FFCC00>" + item.shield_Item_Datas[0].itemClass.ToString() + " 방패</color>";
                        break;
                }
                Inventory.instance.infoText.text = (item.shield_Item_Datas[0].holy_Power != 0 ? "신성 : " + item.shield_Item_Datas[0].holy_Power.ToString() + "\n" : "") +
                                                    (item.shield_Item_Datas[0].neutrality_Power != 0 ? "중립 : " + item.shield_Item_Datas[0].neutrality_Power.ToString() + "\n" : "") +
                                                    (item.shield_Item_Datas[0].heresy_Power != 0 ? "타락 : " + item.shield_Item_Datas[0].heresy_Power.ToString() + "\n" : "") +
                                                    (item.shield_Item_Datas[0].stance != 0 ? "회피 확률 : " + item.shield_Item_Datas[0].stance.ToString() + "\n" : "") +
                                                    (item.shield_Item_Datas[0].push_Stance != 0 ? "슈퍼 아머 : " + item.shield_Item_Datas[0].push_Stance + "\n" : "") +
                                                    (item.shield_Item_Datas[0].stiffen_Stance != 0 ? "스턴 면역 : " + item.shield_Item_Datas[0].stiffen_Stance + "\n\n" : "\n\n") +
                                                    (item.shield_Item_Datas[0].item_Price != 0 ? "가격 : " + item.shield_Item_Datas[0].item_Price + "\n" : "");
                Inventory.instance.infoitemExp.text = item.shield_Item_Datas[0].item_Ex;
                Inventory.instance.isEquip.itemData.shield_Item_Datas.Add(item.shield_Item_Datas[0]);
                break;
            case info.GLOVES:
                Inventory.instance.infonameText.text = item.gloves_Item_Datas[0].item_Name;
                switch (item.gloves_Item_Datas[0].itemClass)
                {
                    case ItemClass.낡아빠진:
                        Inventory.instance.infonameSub.text = "<color=#777777>" + item.gloves_Item_Datas[0].itemClass.ToString() + " 장갑</color>";
                        break;
                    case ItemClass.흔해빠진:
                        Inventory.instance.infonameSub.text = "<color=#DDDDDD>" + item.gloves_Item_Datas[0].itemClass.ToString() + " 장갑</color>";
                        break;
                    case ItemClass.특별해진:
                        Inventory.instance.infonameSub.text = "<color=#3399FF>" + item.gloves_Item_Datas[0].itemClass.ToString() + " 장갑</color>";
                        break;
                    case ItemClass.희귀해진:
                        Inventory.instance.infonameSub.text = "<color=#996699>" + item.gloves_Item_Datas[0].itemClass.ToString() + " 장갑</color>";
                        break;
                    case ItemClass.전설적인:
                        Inventory.instance.infonameSub.text = "<color=#FFCC00>" + item.gloves_Item_Datas[0].itemClass.ToString() + " 장갑</color>";
                        break;
                }
                Inventory.instance.infoText.text = (item.gloves_Item_Datas[0].damage != 0 ? "데미지 : " + item.gloves_Item_Datas[0].damage + "\n" : "") +
                                                    (item.gloves_Item_Datas[0].attack_Speed != 0 ? "공격속도증가 : " + item.gloves_Item_Datas[0].attack_Speed + "\n" : "") +
                                                    (item.gloves_Item_Datas[0].holy_Power != 0 ? "신성 : " + item.gloves_Item_Datas[0].holy_Power.ToString() + "\n" : "") +
                                                    (item.gloves_Item_Datas[0].neutrality_Power != 0 ? "중립 : " + item.gloves_Item_Datas[0].neutrality_Power.ToString() + "\n" : "") +
                                                    (item.gloves_Item_Datas[0].heresy_Power != 0 ? "타락 : " + item.gloves_Item_Datas[0].heresy_Power.ToString() + "\n\n" : "\n\n") +
                                                    (item.gloves_Item_Datas[0].item_Price != 0 ? "가격 : " + item.gloves_Item_Datas[0].item_Price + "\n" : "");
                Inventory.instance.infoitemExp.text = item.gloves_Item_Datas[0].item_Ex;
                Inventory.instance.isEquip.itemData.gloves_Item_Datas.Add(item.gloves_Item_Datas[0]);
                break;
            case info.SHOES:
                Inventory.instance.infonameText.text = item.shoes_Item_Datas[0].item_Name;
                switch (item.shoes_Item_Datas[0].itemClass)
                {
                    case ItemClass.낡아빠진:
                        Inventory.instance.infonameSub.text = "<color=#777777>" + item.shoes_Item_Datas[0].itemClass.ToString() + " 신발</color>";
                        break;
                    case ItemClass.흔해빠진:
                        Inventory.instance.infonameSub.text = "<color=#DDDDDD>" + item.shoes_Item_Datas[0].itemClass.ToString() + " 신발</color>";
                        break;
                    case ItemClass.특별해진:
                        Inventory.instance.infonameSub.text = "<color=#3399FF>" + item.shoes_Item_Datas[0].itemClass.ToString() + " 신발</color>";
                        break;
                    case ItemClass.희귀해진:
                        Inventory.instance.infonameSub.text = "<color=#996699>" + item.shoes_Item_Datas[0].itemClass.ToString() + " 신발</color>";
                        break;
                    case ItemClass.전설적인:
                        Inventory.instance.infonameSub.text = "<color=#FFCC00>" + item.shoes_Item_Datas[0].itemClass.ToString() + " 신발</color>";
                        break;
                }
                Inventory.instance.infoText.text = (item.shoes_Item_Datas[0].eq_Speed != 0 ? "이동속도 : " + item.shoes_Item_Datas[0].eq_Speed + "\n" : "") +
                                                    (item.shoes_Item_Datas[0].move_Slow != 0 ? "이동속도 감소 면역 : " + item.shoes_Item_Datas[0].move_Slow + "\n" : "") +
                                                    (item.shoes_Item_Datas[0].holy_Power != 0 ? "신성 : " + item.shoes_Item_Datas[0].holy_Power.ToString() + "\n" : "") +
                                                    (item.shoes_Item_Datas[0].neutrality_Power != 0 ? "중립 : " + item.shoes_Item_Datas[0].neutrality_Power.ToString() + "\n" : "") +
                                                    (item.shoes_Item_Datas[0].heresy_Power != 0 ? "타락 : " + item.shoes_Item_Datas[0].heresy_Power.ToString() + "\n\n" : "\n\n") +
                                                    (item.shoes_Item_Datas[0].item_Price != 0 ? "가격 : " + item.shoes_Item_Datas[0].item_Price + "\n" : "");
                Inventory.instance.infoitemExp.text = item.shoes_Item_Datas[0].item_Ex;
                Inventory.instance.isEquip.itemData.shoes_Item_Datas.Add(item.shoes_Item_Datas[0]);
                break;
            case info.RINGS:
                Inventory.instance.infonameText.text = item.ring_Item_Datas[0].item_Name;
                switch (item.ring_Item_Datas[0].itemClass)
                {
                    case ItemClass.낡아빠진:
                        Inventory.instance.infonameSub.text = "<color=#777777>" + item.ring_Item_Datas[0].itemClass.ToString() + " 링</color>";
                        break;
                    case ItemClass.흔해빠진:
                        Inventory.instance.infonameSub.text = "<color=#DDDDDD>" + item.ring_Item_Datas[0].itemClass.ToString() + " 링</color>";
                        break;
                    case ItemClass.특별해진:
                        Inventory.instance.infonameSub.text = "<color=#3399FF>" + item.ring_Item_Datas[0].itemClass.ToString() + " 링</color>";
                        break;
                    case ItemClass.희귀해진:
                        Inventory.instance.infonameSub.text = "<color=#996699>" + item.ring_Item_Datas[0].itemClass.ToString() + " 링</color>";
                        break;
                    case ItemClass.전설적인:
                        Inventory.instance.infonameSub.text = "<color=#FFCC00>" + item.ring_Item_Datas[0].itemClass.ToString() + " 링</color>";
                        break;
                }
                Inventory.instance.infoText.text = (item.ring_Item_Datas[0].damage != 0 ? "데미지 : " + item.ring_Item_Datas[0].damage + "\n" : "") +
                                                    (item.ring_Item_Datas[0].attack_Vampire != 0 ? "체력 생성 확률 : " + item.ring_Item_Datas[0].attack_Vampire + "\n" : "") +
                                                    (item.ring_Item_Datas[0].heart_Recovery_Time != 0 ? "체력 재생 시간 : " + item.ring_Item_Datas[0].heart_Recovery_Time + "\n" : "") +
                                                    (item.ring_Item_Datas[0].heart_Stance != 0 ? "체력 소모 반감 : " + item.ring_Item_Datas[0].heart_Stance + "\n" : "") +
                                                    (item.ring_Item_Datas[0].holy_Power != 0 ? "신성 : " + item.ring_Item_Datas[0].holy_Power.ToString() + "\n" : "") +
                                                    (item.ring_Item_Datas[0].neutrality_Power != 0 ? "중립 : " + item.ring_Item_Datas[0].neutrality_Power.ToString() + "\n" : "") +
                                                    (item.ring_Item_Datas[0].heresy_Power != 0 ? "타락 : " + item.ring_Item_Datas[0].heresy_Power.ToString() + "\n\n" : "\n\n") +
                                                    (item.ring_Item_Datas[0].item_Price != 0 ? "가격 : " + item.ring_Item_Datas[0].item_Price + "\n" : "");
                Inventory.instance.infoitemExp.text = item.ring_Item_Datas[0].item_Ex;
                Inventory.instance.isEquip.itemData.ring_Item_Datas.Add(item.ring_Item_Datas[0]);
                break;
            case info.NECKLACES:
                Inventory.instance.infonameText.text = item.necklace_Item_Datas[0].item_Name;
                switch (item.necklace_Item_Datas[0].itemClass)
                {
                    case ItemClass.낡아빠진:
                        Inventory.instance.infonameSub.text = "<color=#777777>" + item.necklace_Item_Datas[0].itemClass.ToString() + " 목걸이</color>";
                        break;
                    case ItemClass.흔해빠진:
                        Inventory.instance.infonameSub.text = "<color=#DDDDDD>" + item.necklace_Item_Datas[0].itemClass.ToString() + " 목걸이</color>";
                        break;
                    case ItemClass.특별해진:
                        Inventory.instance.infonameSub.text = "<color=#3399FF>" + item.necklace_Item_Datas[0].itemClass.ToString() + " 목걸이</color>";
                        break;
                    case ItemClass.희귀해진:
                        Inventory.instance.infonameSub.text = "<color=#996699>" + item.necklace_Item_Datas[0].itemClass.ToString() + " 목걸이</color>";
                        break;
                    case ItemClass.전설적인:
                        Inventory.instance.infonameSub.text = "<color=#FFCC00>" + item.necklace_Item_Datas[0].itemClass.ToString() + " 목걸이</color>";
                        break;
                }
                Inventory.instance.infoText.text = (item.necklace_Item_Datas[0].damage != 0 ? "데미지 : " + item.necklace_Item_Datas[0].damage + "\n" : "") +
                                                    (item.necklace_Item_Datas[0].attack_Vampire != 0 ? "체력 생성 확률 : " + item.necklace_Item_Datas[0].attack_Vampire + "\n" : "") +
                                                    (item.necklace_Item_Datas[0].heart_Recovery_Time != 0 ? "체력 재생 시간 : " + item.necklace_Item_Datas[0].heart_Recovery_Time + "\n" : "") +
                                                    (item.necklace_Item_Datas[0].heart_Stance != 0 ? "체력 소모 반감 : " + item.necklace_Item_Datas[0].heart_Stance + "\n" : "") +
                                                    (item.necklace_Item_Datas[0].holy_Power != 0 ? "신성 : " + item.necklace_Item_Datas[0].holy_Power.ToString() + "\n" : "") +
                                                    (item.necklace_Item_Datas[0].neutrality_Power != 0 ? "중립 : " + item.necklace_Item_Datas[0].neutrality_Power.ToString() + "\n" : "") +
                                                    (item.necklace_Item_Datas[0].heresy_Power != 0 ? "타락 : " + item.necklace_Item_Datas[0].heresy_Power.ToString() + "\n\n" : "\n\n") +
                                                    (item.necklace_Item_Datas[0].item_Price != 0 ? "가격 : " + item.necklace_Item_Datas[0].item_Price + "\n" : "");
                Inventory.instance.infoitemExp.text = item.necklace_Item_Datas[0].item_Ex;
                Inventory.instance.isEquip.itemData.necklace_Item_Datas.Add(item.necklace_Item_Datas[0]);
                break;
            case info.CONSUMABLES:
                Inventory.instance.infonameText.text = item.consumable_Item_Datas[0].item_Name;
                switch (item.consumable_Item_Datas[0].itemClass)
                {
                    case ItemClass.낡아빠진:
                        Inventory.instance.infonameSub.text = "<color=#777777>" + item.consumable_Item_Datas[0].itemClass.ToString() + " 유물</color>";
                        break;
                    case ItemClass.흔해빠진:
                        Inventory.instance.infonameSub.text = "<color=#DDDDDD>" + item.consumable_Item_Datas[0].itemClass.ToString() + " 유물</color>";
                        break;
                    case ItemClass.특별해진:
                        Inventory.instance.infonameSub.text = "<color=#3399FF>" + item.consumable_Item_Datas[0].itemClass.ToString() + " 유물</color>";
                        break;
                    case ItemClass.희귀해진:
                        Inventory.instance.infonameSub.text = "<color=#996699>" + item.consumable_Item_Datas[0].itemClass.ToString() + " 유물</color>";
                        break;
                    case ItemClass.전설적인:
                        Inventory.instance.infonameSub.text = "<color=#FFCC00>" + item.consumable_Item_Datas[0].itemClass.ToString() + " 유물</color>";
                        break;
                }
                Inventory.instance.infoText.text = ((item.consumable_Item_Datas[0].damage != 0) ? "데미지 : " + item.consumable_Item_Datas[0].damage + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].attack_Speed != 0) ? "공격 속도 증가 : " + item.consumable_Item_Datas[0].attack_Speed + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].attack_Vampire != 0) ? "체력 생성 확률 : " + item.consumable_Item_Datas[0].attack_Vampire + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].heart_Recovery_Time != 0) ? "체력 재생 시간 : " + item.consumable_Item_Datas[0].heart_Recovery_Time + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].heart_Stance != 0) ? "체력 소모 반감 : " + item.consumable_Item_Datas[0].heart_Stance + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].stance != 0) ? "신속함 : " + item.consumable_Item_Datas[0].stance + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].push_Stance != 0) ? "슈퍼 아머 : " + item.consumable_Item_Datas[0].push_Stance + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].phoenix_Stance != 0) ? "죽음 면역 : " + item.consumable_Item_Datas[0].phoenix_Stance + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].stiffen_Stance != 0) ? "스턴 면역 : " + item.consumable_Item_Datas[0].stiffen_Stance + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].eq_Speed != 0) ? "이동속도 : " + item.consumable_Item_Datas[0].eq_Speed + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].move_Slow != 0) ? "이동속도 감소 면역 : " + item.consumable_Item_Datas[0].move_Slow + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].hpmax_Potion != 0) ? "체력 증가 : " + item.consumable_Item_Datas[0].hpmax_Potion + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].holy_Power != 0) ? "신성 : " + item.consumable_Item_Datas[0].holy_Power + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].neutrality_Power != 0) ? "중립 : " + item.consumable_Item_Datas[0].neutrality_Power + "\n" : "") +
                                                    ((item.consumable_Item_Datas[0].heresy_Power != 0) ? "타락 : " + item.consumable_Item_Datas[0].heresy_Power + "\n\n" : "") +
                                                    "가격 : " + item.consumable_Item_Datas[0].item_Price + "\n";
                Inventory.instance.infoitemExp.text = item.consumable_Item_Datas[0].item_Ex;
                break;
            case info.OTHERS:
                Inventory.instance.infonameText.text = item.other_Quest_Item_Datas[0].item_Name;
                Inventory.instance.infonameSub.text = (item.other_Quest_Item_Datas[0].item_style == type.ETC ?
                                                     "<color=#FFFFFF>기타 아이템</color>" : (item.other_Quest_Item_Datas[0].item_style == type.EXP) ? "<color=#6E88FF>소모 아이템</color>" : "<color=#D653FF>퀘스트 아이템</color>");
                Inventory.instance.infoText.text = "가격 : " + item.other_Quest_Item_Datas[0].item_Price;
                Inventory.instance.infoitemExp.text = item.other_Quest_Item_Datas[0].item_Ex;
                break;
        }
        if (info != info.Default && info != info.OTHERS && info != info.CONSUMABLES)
        {
            Inventory.instance.equipBtt.SetActive(true);
            Equipment.instance.unequipBtt.SetActive(false);
            Inventory.instance.isEquip.number = number;
        }
        else
        {
            Inventory.instance.equipBtt.SetActive(false);
            Equipment.instance.unequipBtt.SetActive(false);
            Inventory.instance.isEquip.number = -1;
        }
    }
    public void OnPointerEnter(PointerEventData data)
    {
        Inventory.instance.enteredSlot = this;
    }

    public void OnPointerExit(PointerEventData data)
    {
        Inventory.instance.enteredSlot = null;
    }
    public void OnEndDrag(PointerEventData data)
    {
        if (checkItem != false)
        {
            Inventory.instance.draggingItem.GetChild(0).SetParent(transform);
            transform.GetChild(0).localPosition = Vector3.zero;
            slots_Pivot.pivot = new Vector2(0.5f, 0.5f);
            slots_Pivot.localScale = new Vector2(1f, 1f);
            if (Inventory.instance.enteredSlot != null && Inventory.instance.enteredSlot.name != "ItemDelete")
            {
                LocalizationItemData tempItem = item;
                item = Inventory.instance.enteredSlot.item;
                Inventory.instance.enteredSlot.item = tempItem;
                if (Inventory.instance.enteredSlot.checkItem == true && this.checkItem == true && Inventory.instance.enteredSlot != null)
                {
                    // 아이템끼리 자리를 바꿀때
                    checkItem = true;
                    Inventory.instance.enteredSlot.checkItem = true;
                    //|| this.ItemCount >= Inventory.instance.enteredSlot.ItemCount)
                    // 아이템 갯수 체인지.
                    if ((this.info == info.OTHERS) && (Inventory.instance.enteredSlot.info == info.OTHERS) && this.DropItemNumber == Inventory.instance.enteredSlot.DropItemNumber
                     && (this.ItemCount <= Inventory.instance.enteredSlot.ItemCount || this.ItemCount >= Inventory.instance.enteredSlot.ItemCount) && this.ItemCount < 99 && Inventory.instance.enteredSlot.ItemCount < 99)
                    {
                        int otherCount = this.ItemCount + Inventory.instance.enteredSlot.ItemCount;
                        if (otherCount < 99)
                        {
                            Inventory.instance.enteredSlot.ItemCount = otherCount;
                            Inventory.instance.enteredSlot.ItemCountText.text = otherCount.ToString();
                            this.ItemCount = 0;
                            this.ItemCountText = null;
                            this.checkItem = false;
                        }
                        else
                        {
                            Inventory.instance.enteredSlot.ItemCount = 99;
                            Inventory.instance.enteredSlot.ItemCountText.text = "99";
                            this.ItemCount = otherCount - 99;
                            this.ItemCountText.text = (otherCount - 99).ToString();
                        }
                    }
                    else
                    {
                        if (this.info != info.OTHERS && Inventory.instance.enteredSlot.info != info.OTHERS)
                        {
                            int itemcounts = this.ItemCount;
                            this.ItemCount = Inventory.instance.enteredSlot.ItemCount;
                            Inventory.instance.enteredSlot.ItemCount = itemcounts;
                        }
                        // 아이템 타입 체인지
                        info infochan = this.info;
                        this.info = Inventory.instance.enteredSlot.info;
                        Inventory.instance.enteredSlot.info = infochan;
                        // 아이템 타입 체인지 끝
                        // 아이템 고유번호 체인지
                        float Dropnumtemp = this.DropItemNumber;
                        this.DropItemNumber = Inventory.instance.enteredSlot.DropItemNumber;
                        Inventory.instance.enteredSlot.DropItemNumber = Dropnumtemp;
                        // 아이템 고유번호 체인지 끝
                        int ItemCount = this.ItemCount;
                        this.ItemCountText.text = Inventory.instance.enteredSlot.ItemCount.ToString();
                        this.ItemCount = Inventory.instance.enteredSlot.ItemCount;
                        Inventory.instance.enteredSlot.ItemCountText.text = ItemCount.ToString();
                        Inventory.instance.enteredSlot.ItemCount = ItemCount;
                    }
                    // 아이템 갯수 체인지 끝.
                    Inventory.instance.ItemImageChange(this);
                    Inventory.instance.ItemImageChange(Inventory.instance.enteredSlot);
                }
                else
                {
                    // 아이템 위치변경할때
                    this.checkItem = false;
                    Inventory.instance.enteredSlot.checkItem = true;
                    Inventory.instance.enteredSlot.info = this.info;
                    this.info = info.Default;
                    Inventory.instance.enteredSlot.DropItemNumber = this.DropItemNumber;
                    this.DropItemNumber = 0;
                    Inventory.instance.enteredSlot.ItemCount = this.ItemCount;
                    Inventory.instance.enteredSlot.ItemCountText.text = this.ItemCount.ToString();
                    this.ItemCount = 0;
                    this.ItemCountText.text = null;
                    Inventory.instance.ItemImageChange(this);
                    Inventory.instance.ItemImageChange(Inventory.instance.enteredSlot);
                    transform.GetChild(0).GetComponent<Image>().sprite = null;
                    transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);
                }
            }
            else
            {
                if (Inventory.instance.enteredSlot != null && info != info.OTHERS)
                {
                    // 아이템 버릴때.
                    checkItemDrop = true;
                    item.weapon_Item_Datas.Clear();
                    item.shield_Item_Datas.Clear();
                    item.helmat_Item_Datas.Clear();
                    item.armor_Item_Datas.Clear();
                    item.gloves_Item_Datas.Clear();
                    item.shoes_Item_Datas.Clear();
                    item.ring_Item_Datas.Clear();
                    item.necklace_Item_Datas.Clear();
                    item.consumable_Item_Datas.Clear();
                    Inventory.instance.ItemImageChange(this);
                }
                else if (Inventory.instance.enteredSlot != null && info == info.OTHERS)
                {
                    Inventory.instance.OtherDrops(this);
                }
            }
        }
    }
}