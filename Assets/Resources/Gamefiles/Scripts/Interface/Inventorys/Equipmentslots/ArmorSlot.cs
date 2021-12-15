using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArmorSlot : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public armor_Item_Data ArmorEquip;
    // 클릭시.
    public Image image;
    public float itemNumber = -1;
    public void OnPointerClick(PointerEventData data)
    {
        Inventory.instance.invenSlotInfo.SetActive(true);
        Equipment.instance.unequipBtt.SetActive(true);
        Equipment.instance.InvenInfoitem(ArmorEquip.info);
        Equipment.instance.equipInfo = info.ARMORS;
    }
    // 클릭 안할시.
    public void OnPointerExit(PointerEventData data)
    {

    }
}
