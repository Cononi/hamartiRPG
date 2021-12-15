using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HelmatSlot : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public helmat_Item_Data helmatEquip;
    public Image image;
    public float itemNumber = -1;
    public void OnPointerClick(PointerEventData data)
    {
        Inventory.instance.invenSlotInfo.SetActive(true);
        Equipment.instance.unequipBtt.SetActive(true);
        Equipment.instance.InvenInfoitem(helmatEquip.info);
        Equipment.instance.equipInfo = info.HELMATS;
    }
    // 클릭 안할시.
    public void OnPointerExit(PointerEventData data)
    {

    }
}
