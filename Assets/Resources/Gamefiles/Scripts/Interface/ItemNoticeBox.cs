using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemNoticeBox : MonoBehaviour
{
    public Text text;
    public void ItemNumPlay(int i, info info)
    {
        switch (info)
        {
            case info.OTHERS:
                switch (info)
                {
                    case info.HELMATS:
                        StartCoroutine(ItemNameCo("<color=#E7A406>" + ItemDatabase.instance.helmats[i].item_Name + " </color> 이 필요해..."));
                        break;
                    case info.ARMORS:
                        StartCoroutine(ItemNameCo("<color=#E7A406>" + ItemDatabase.instance.armors[i].item_Name + " </color> 이 필요해..."));
                        break;
                    case info.WEAPONS:
                        StartCoroutine(ItemNameCo("<color=#E7A406>" + ItemDatabase.instance.weapons[i].item_Name + " </color> 이 필요해..."));
                        break;
                    case info.SHIELDS:
                        StartCoroutine(ItemNameCo("<color=#E7A406>" + ItemDatabase.instance.shields[i].item_Name + " </color> 이 필요해..."));
                        break;
                    case info.GLOVES:
                        StartCoroutine(ItemNameCo("<color=#E7A406>" + ItemDatabase.instance.gloves[i].item_Name + " </color> 이 필요해..."));
                        break;
                    case info.SHOES:
                        StartCoroutine(ItemNameCo("<color=#E7A406>" + ItemDatabase.instance.shoeses[i].item_Name + " </color> 이 필요해..."));
                        break;
                    case info.RINGS:
                        StartCoroutine(ItemNameCo("<color=#E7A4i6>" + ItemDatabase.instance.rings[i].item_Name + " </color> 이 필요해..."));
                        break;
                    case info.NECKLACES:
                        StartCoroutine(ItemNameCo("<color=#E7A4i6>" + ItemDatabase.instance.necklaces[i].item_Name + " </color> 이 필요해..."));
                        break;
                    case info.OTHERS:
                        StartCoroutine(ItemNameCo("<color=#E7A4i6>" + ItemDatabase.instance.other_quests[i].item_Name + " </color> 이 필요해..."));
                        break;
                    case info.CONSUMABLES:
                        StartCoroutine(ItemNameCo("<color=#E7A4i6>" + ItemDatabase.instance.consumables[i].item_Name + " </color> 이 필요해..."));
                        break;
                }
                break;
        }
    }
    public void ItemNumPlay(int i, info info, type itemClass)
    {
        switch (info)
        {
            case info.OTHERS:
                switch (itemClass)
                {
                    case type.ETC:
                        StartCoroutine(ItemNameCo("<color=#FFFFFF>" + Inventory.instance.slot_Table[i].item.other_Quest_Item_Datas[0].item_Name + " </color>기타아이템을 얻었다!!!!"));
                        break;
                    case type.EXP:
                        StartCoroutine(ItemNameCo("<color=#6E88FF>" + Inventory.instance.slot_Table[i].item.other_Quest_Item_Datas[0].item_Name + " </color>소모아이템을 얻었다!!!!"));
                        break;
                    case type.QUEST:
                        StartCoroutine(ItemNameCo("<color=#D653FF>" + Inventory.instance.slot_Table[i].item.other_Quest_Item_Datas[0].item_Name + " </color>퀘스트아이템을 얻었다!!!!"));
                        break;
                }
                break;
        }
    }
    public void ItemNumPlay(int i, info info, ItemClass itemClass)
    {
        switch (info)
        {
            case info.HELMATS:
                switch (itemClass)
                {
                    case ItemClass.낡아빠진:
                        StartCoroutine(ItemNameCo("<color=#777777>" + Inventory.instance.slot_Table[i].item.helmat_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.흔해빠진:
                        StartCoroutine(ItemNameCo("<color=#DDDDDD>" + Inventory.instance.slot_Table[i].item.helmat_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.특별해진:
                        StartCoroutine(ItemNameCo("<color=#3399FF>" + Inventory.instance.slot_Table[i].item.helmat_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.희귀해진:
                        StartCoroutine(ItemNameCo("<color=#996699>" + Inventory.instance.slot_Table[i].item.helmat_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.전설적인:
                        StartCoroutine(ItemNameCo("<color=#FFCC00>" + Inventory.instance.slot_Table[i].item.helmat_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                }
                break;
            case info.ARMORS:
                switch (itemClass)
                {
                    case ItemClass.낡아빠진:
                        StartCoroutine(ItemNameCo("<color=#777777>" + Inventory.instance.slot_Table[i].item.armor_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.흔해빠진:
                        StartCoroutine(ItemNameCo("<color=#DDDDDD>" + Inventory.instance.slot_Table[i].item.armor_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.특별해진:
                        StartCoroutine(ItemNameCo("<color=#3399FF>" + Inventory.instance.slot_Table[i].item.armor_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.희귀해진:
                        StartCoroutine(ItemNameCo("<color=#996699>" + Inventory.instance.slot_Table[i].item.armor_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.전설적인:
                        StartCoroutine(ItemNameCo("<color=#FFCC00>" + Inventory.instance.slot_Table[i].item.armor_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                }
                break;
            case info.WEAPONS:
                switch (itemClass)
                {
                    case ItemClass.낡아빠진:
                        StartCoroutine(ItemNameCo("<color=#777777>" + Inventory.instance.slot_Table[i].item.weapon_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.흔해빠진:
                        StartCoroutine(ItemNameCo("<color=#DDDDDD>" + Inventory.instance.slot_Table[i].item.weapon_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.특별해진:
                        StartCoroutine(ItemNameCo("<color=#3399FF>" + Inventory.instance.slot_Table[i].item.weapon_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.희귀해진:
                        StartCoroutine(ItemNameCo("<color=#996699>" + Inventory.instance.slot_Table[i].item.weapon_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.전설적인:
                        StartCoroutine(ItemNameCo("<color=#FFCC00>" + Inventory.instance.slot_Table[i].item.weapon_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                }
                break;
            case info.SHIELDS:
                switch (itemClass)
                {
                    case ItemClass.낡아빠진:
                        StartCoroutine(ItemNameCo("<color=#777777>" + Inventory.instance.slot_Table[i].item.shield_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.흔해빠진:
                        StartCoroutine(ItemNameCo("<color=#DDDDDD>" + Inventory.instance.slot_Table[i].item.shield_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.특별해진:
                        StartCoroutine(ItemNameCo("<color=#3399FF>" + Inventory.instance.slot_Table[i].item.shield_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.희귀해진:
                        StartCoroutine(ItemNameCo("<color=#996699>" + Inventory.instance.slot_Table[i].item.shield_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.전설적인:
                        StartCoroutine(ItemNameCo("<color=#FFCC00>" + Inventory.instance.slot_Table[i].item.shield_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                }
                break;
            case info.GLOVES:
                switch (itemClass)
                {
                    case ItemClass.낡아빠진:
                        StartCoroutine(ItemNameCo("<color=#777777>" + Inventory.instance.slot_Table[i].item.gloves_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.흔해빠진:
                        StartCoroutine(ItemNameCo("<color=#DDDDDD>" + Inventory.instance.slot_Table[i].item.gloves_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.특별해진:
                        StartCoroutine(ItemNameCo("<color=#3399FF>" + Inventory.instance.slot_Table[i].item.gloves_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.희귀해진:
                        StartCoroutine(ItemNameCo("<color=#996699>" + Inventory.instance.slot_Table[i].item.gloves_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.전설적인:
                        StartCoroutine(ItemNameCo("<color=#FFCC00>" + Inventory.instance.slot_Table[i].item.gloves_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                }
                break;
            case info.SHOES:
                switch (itemClass)
                {
                    case ItemClass.낡아빠진:
                        StartCoroutine(ItemNameCo("<color=#777777>" + Inventory.instance.slot_Table[i].item.shoes_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.흔해빠진:
                        StartCoroutine(ItemNameCo("<color=#DDDDDD>" + Inventory.instance.slot_Table[i].item.shoes_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.특별해진:
                        StartCoroutine(ItemNameCo("<color=#3399FF>" + Inventory.instance.slot_Table[i].item.shoes_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.희귀해진:
                        StartCoroutine(ItemNameCo("<color=#996699>" + Inventory.instance.slot_Table[i].item.shoes_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.전설적인:
                        StartCoroutine(ItemNameCo("<color=#FFCC00>" + Inventory.instance.slot_Table[i].item.shoes_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                }
                break;
            case info.RINGS:
                switch (itemClass)
                {
                    case ItemClass.낡아빠진:
                        StartCoroutine(ItemNameCo("<color=#777777>" + Inventory.instance.slot_Table[i].item.ring_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.흔해빠진:
                        StartCoroutine(ItemNameCo("<color=#DDDDDD>" + Inventory.instance.slot_Table[i].item.ring_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.특별해진:
                        StartCoroutine(ItemNameCo("<color=#3399FF>" + Inventory.instance.slot_Table[i].item.ring_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.희귀해진:
                        StartCoroutine(ItemNameCo("<color=#996699>" + Inventory.instance.slot_Table[i].item.ring_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                    case ItemClass.전설적인:
                        StartCoroutine(ItemNameCo("<color=#FFCC00>" + Inventory.instance.slot_Table[i].item.ring_Item_Datas[0].item_Name + " </color>을 얻었다!!!!"));
                        break;
                }
                break;
            case info.NECKLACES:
                switch (itemClass)
                {
                    case ItemClass.낡아빠진:
                        StartCoroutine(ItemNameCo("<color=#777777>" + Inventory.instance.slot_Table[i].item.necklace_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.흔해빠진:
                        StartCoroutine(ItemNameCo("<color=#DDDDDD>" + Inventory.instance.slot_Table[i].item.necklace_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.특별해진:
                        StartCoroutine(ItemNameCo("<color=#3399FF>" + Inventory.instance.slot_Table[i].item.necklace_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.희귀해진:
                        StartCoroutine(ItemNameCo("<color=#996699>" + Inventory.instance.slot_Table[i].item.necklace_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.전설적인:
                        StartCoroutine(ItemNameCo("<color=#FFCC00>" + Inventory.instance.slot_Table[i].item.necklace_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                }
                break;
            case info.CONSUMABLES:
                switch (itemClass)
                {
                    case ItemClass.낡아빠진:
                        StartCoroutine(ItemNameCo("<color=#777777>" + Inventory.instance.slot_Table[i].item.consumable_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.흔해빠진:
                        StartCoroutine(ItemNameCo("<color=#DDDDDD>" + Inventory.instance.slot_Table[i].item.consumable_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.특별해진:
                        StartCoroutine(ItemNameCo("<color=#3399FF>" + Inventory.instance.slot_Table[i].item.consumable_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.희귀해진:
                        StartCoroutine(ItemNameCo("<color=#996699>" + Inventory.instance.slot_Table[i].item.consumable_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                    case ItemClass.전설적인:
                        StartCoroutine(ItemNameCo("<color=#FFCC00>" + Inventory.instance.slot_Table[i].item.consumable_Item_Datas[0].item_Name + " </color>를 얻었다!!!!"));
                        break;
                }
                break;
            case info.Default:
                Inventory.instance.invenSlotInfo.SetActive(false);
                break;
        }
    }
    public IEnumerator ItemNameCo(string s)
    {
        text.text = s;
        yield return new WaitForSeconds(2f);
        // 오브젝트를 온시킴.
        for (float i = 1; i >= 0; i -= 0.02f)
        {
            this.transform.position += new Vector3(0, i * 1.5f, 0);
            text.color = new Vector4(text.color.r, text.color.g, text.color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        GameObject.Destroy(gameObject);
    }
}
