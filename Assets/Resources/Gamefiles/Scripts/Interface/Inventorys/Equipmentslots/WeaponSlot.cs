using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public weapon_Item_Data weaponEquip;
    public Image image;
    public float itemNumber = -1;
    public void OnPointerClick(PointerEventData data)
    {
        Inventory.instance.invenSlotInfo.SetActive(true);
        Equipment.instance.unequipBtt.SetActive(true);
        Equipment.instance.InvenInfoitem(weaponEquip.info);
        Equipment.instance.equipInfo = info.WEAPONS;
    }
    // 클릭 안할시.
    public void OnPointerExit(PointerEventData data)
    {

    }
}
