using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShieldSlot : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public shield_Item_Data shieldEquip;
    public Image image;
    public float itemNumber = -1;
    public void OnPointerClick(PointerEventData data)
    {
        Inventory.instance.invenSlotInfo.SetActive(true);
        Equipment.instance.unequipBtt.SetActive(true);
        Equipment.instance.InvenInfoitem(shieldEquip.info);
        Equipment.instance.equipInfo = info.SHIELDS;
    }
    // 클릭 안할시.
    public void OnPointerExit(PointerEventData data)
    {

    }
}
