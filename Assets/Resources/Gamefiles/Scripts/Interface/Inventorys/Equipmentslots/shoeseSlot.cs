using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class shoeseSlot : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public shoes_Item_Data shoesEquip;
    public Image image;
    public float itemNumber = -1;
    public void OnPointerClick(PointerEventData data)
    {
        Inventory.instance.invenSlotInfo.SetActive(true);
        Equipment.instance.unequipBtt.SetActive(true);
        Equipment.instance.InvenInfoitem(shoesEquip.info);
        Equipment.instance.equipInfo = info.SHOES;
    }
    // 클릭 안할시.
    public void OnPointerExit(PointerEventData data)
    {

    }
}
