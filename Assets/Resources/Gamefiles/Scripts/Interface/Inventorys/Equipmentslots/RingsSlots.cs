using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RingsSlots : MonoBehaviour, IPointerClickHandler
{
    public ring_Item_Data ringsEquip;
    public Image image;
    public float itemNumber = -1;
    public GameObject s;
    public EquipmentCheck equipmentCheck;
    public bool ring1S;
    public bool ring2S;
    public void OnPointerClick(PointerEventData data)
    {
        data.selectedObject = s;
        if (image.sprite.name != "RingsSlotsSprite")
        {
            if (data.selectedObject.name == "Ring1Slot")
                equipmentCheck.ringName = "Ring1Slot";
            else if (data.selectedObject.name == "Ring2Slot")
                equipmentCheck.ringName = "Ring2Slot";
        }
        else equipmentCheck.ringName = "";

        Inventory.instance.invenSlotInfo.SetActive(true);
        Equipment.instance.unequipBtt.SetActive(true);
        Equipment.instance.InvenInfoitem(ringsEquip.info);
        Equipment.instance.equipInfo = info.RINGS;

    }
}
