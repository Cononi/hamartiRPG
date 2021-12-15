using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public static Equipment instance;

    public LocalizationItemData item;
    public GameObject unequipBtt;
    public info equipInfo;
    [SerializeField]
    private Text[] playerstateText;
    public bool Eqbool;

    public GameObject weaponObj;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        PlayerState();
    }
    public void PlayerState()
    {
        //HP
        playerstateText[0].text = (DataManager.instance.health + 0.0331f + " / " + ((item.armor_Item_Datas.Count != 0) ? "<color=#FF0000>" + (item.armor_Item_Datas[0].Player_numOFHeart + DataManager.instance.health + 0.0331f) + "</color>" : "" + Mathf.Round(DataManager.instance.healthMax)));
        //DAMAGE
        playerstateText[1].text = (DataManager.instance.damage - 1.0331f != 0 ? "<color=#FF0000>" + (DataManager.instance.damage - 1.0331f).ToString() + "</color>" : (DataManager.instance.damage - 1.0331f).ToString());
        //MOVE SPEED
        playerstateText[2].text = (DataManager.instance.speed - 0.0331f) + (item.shoes_Item_Datas.Count != 0 ? "<color=#FF0000> (" + item.shoes_Item_Datas[0].eq_Speed + ")</color>" : "");
        //ATTACK SPEED
        playerstateText[3].text = (DataManager.instance.attack_Speed - 1.0331f != 0 ? "<color=#FF0000>" + (DataManager.instance.attack_Speed - 0.0331f).ToString() + "</color>" : (DataManager.instance.attack_Speed - 0.0331f).ToString());
        //MOVE SPEED
        //ATTACK RANGE
        playerstateText[4].text = (item.weapon_Item_Datas.Count != 0 ?
                                  ("<color=#FF0000>" + (item.weapon_Item_Datas[0].attack_Range) + "</color>")
                                  : "" + DataManager.instance.attack_Range);
        //HORY
        playerstateText[5].text = (DataManager.instance.holy_Power - 0.0331f != 0) ? "<color=#FF0000>" + (DataManager.instance.holy_Power - 0.0331f).ToString() + "</color>" : (DataManager.instance.holy_Power - 0.0331f).ToString();
        //NEUTRALITY
        playerstateText[6].text = (DataManager.instance.neutrality_Power - 0.0331f != 0) ? "<color=#FF0000>" + (DataManager.instance.neutrality_Power - 0.0331f).ToString() + "</color>" : (DataManager.instance.neutrality_Power - 0.0331f).ToString();
        //HERESY
        playerstateText[7].text = (DataManager.instance.heresy_Power - 0.0331f != 0) ? "<color=#FF0000>" + (DataManager.instance.heresy_Power - 0.0331f).ToString() + "</color>" : (DataManager.instance.heresy_Power - 0.0331f).ToString();
        //Avoid
        playerstateText[8].text = (DataManager.instance.stance - 0.0331f != 0) ? "<color=#FF0000>" + (DataManager.instance.stance - 0.0331f).ToString() + "</color>" : (DataManager.instance.stance - 0.0331f).ToString();
        //Stanc
        playerstateText[9].text = (DataManager.instance.push_Stance - 0.0331f != 0) ? "<color=#FF0000>" + (DataManager.instance.push_Stance - 0.0331f).ToString() + "</color>" : (DataManager.instance.push_Stance - 0.0331f).ToString();
        //Phoenix
        playerstateText[10].text = (DataManager.instance.phoenix_Stance - 0.0331f != 0) ? "<color=#FF0000>" + (DataManager.instance.phoenix_Stance - 0.0331f).ToString() + "</color>" : (DataManager.instance.phoenix_Stance - 0.0331f).ToString();
        //Stiffen
        playerstateText[11].text = (DataManager.instance.stiffen_Stance - 0.0331f != 0) ? "<color=#FF0000>" + (DataManager.instance.stiffen_Stance - 0.0331f).ToString() + "</color>" : (DataManager.instance.stiffen_Stance - 0.0331f).ToString();
        //HealthRecovery
        playerstateText[12].text = (DataManager.instance.attack_Vampire - 0.0331f != 0) ? "<color=#FF0000>" + (DataManager.instance.attack_Vampire - 0.0331f).ToString() + "</color>" : (DataManager.instance.attack_Vampire - 0.0331f).ToString();
        //HealthStacne
        playerstateText[13].text = (DataManager.instance.heart_Stance - 0.0331f != 0) ? "<color=#FF0000>" + (DataManager.instance.heart_Stance - 0.0331f).ToString() + "</color>" : (DataManager.instance.heart_Stance - 0.0331f).ToString();
        //HealthRecoveryTime
        playerstateText[14].text = (DataManager.instance.heart_Recovery_Time - 0.0331f < 20) ? "<color=#FF0000>" + (DataManager.instance.heart_Recovery_Time - 0.0331f).ToString() + "</color>" : (DataManager.instance.heart_Recovery_Time - 0.0331f).ToString();
        //MoveSlow
        playerstateText[15].text = (DataManager.instance.move_Slow - 0.0331f != 0) ? "<color=#FF0000>" + (DataManager.instance.move_Slow - 0.0331f).ToString() + "</color>" : (DataManager.instance.move_Slow - 0.0331f).ToString();
    }
    /*                                     "데미지 : " + (DataManager.instance.damage - 0.0331f) + "\n" +
                                    "도 : " + (DataManager.instance.attack_Speed - 0.0331f) + "\n" +
                                    "공격 범위 : " + (item.weapon_Item_Datas.Count != 0 ? "<color=#FF0000>" + DataManager.instance.attack_Range + "</color>" : "" + DataManager.instance.attack_Range) + "\n" +
                                    "이동 속도 : " + (DataManager.instance.speed - 0.0331f) + (item.shoes_Item_Datas.Count != 0 ? "<color=#FF0000>(" + item.shoes_Item_Datas[0].eq_Speed + ")</color>" : "") + "\n" +
                                    "신성 : " + (DataManager.instance.holy_Power - 0.0331f) + "\n" +
                                    "중립 : " + (DataManager.instance.neutrality_Power - 0.0331f) + "\n" +
                                    "타락 : " + (DataManager.instance.heresy_Power - 0.0331f) + "\n" +
                                    "체력 생성 확률 : " + (DataManager.instance.attack_Vampire - 0.0331f) + "\n" +
                                    "체력 소모 반감 : " + (DataManager.instance.heart_Stance - 0.0331f) + "\n" +
                                    "체력 재생 시간 : " + (DataManager.instance.heart_Recovery_Time - 0.0331f) + "\n" +
                                    "신속함 : " + (DataManager.instance.stance - 0.0331f) + "\n" +
                                    "슈퍼 아머 : " + (DataManager.instance.push_Stance - 0.0331f) + "\n" +
                                    "죽음 면역 : " + (DataManager.instance.phoenix_Stance - 0.0331f) + "\n" +
                                    "스턴 면역 : " + (DataManager.instance.stiffen_Stance - 0.0331f) + "\n" +
                                    "이동속도 감소 면역 : " + (DataManager.instance.move_Slow - 0.0331f) + "\n"; */
    public void InvenInfoitem(info info)
    {
        Inventory.instance.infonameSub.text = "";
        Inventory.instance.equipBtt.SetActive(false);
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
                break;
            case info.Default:
                Inventory.instance.invenSlotInfo.SetActive(false);
                break;
        }
    }
}
