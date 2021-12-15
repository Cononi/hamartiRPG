using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentCheck : MonoBehaviour, IPointerClickHandler
{
    public HelmatSlot helmatSlot;
    public ArmorSlot armorSlot;
    public WeaponSlot weaponSlot;
    public ShieldSlot shieldSlot;
    public shoeseSlot shoeseSlot;
    public GlovesSlot glovesSlot;
    public RingsSlots ringsSlots;
    public RingsSlots ringsSlots2;
    public NecklaceSlot necklaceSlot;
    public LocalizationItemData itemData;
    public int number; // 테이블 고유 넘버.
    public string ringName;
    [SerializeField]
    private EquipeMentSocket[] equipeMentSocket;


    public void weaponLight()
    {
        if (weaponSlot.weaponEquip.item_Numbers == 10001)
        {
            Equipment.instance.weaponObj.SetActive(true);
        }
        else
        {
            Equipment.instance.weaponObj.SetActive(false);
        }
    }
    public void ItemAnis()
    {

    }

    public void OnPointerClick(PointerEventData data)
    {
        if (data.selectedObject.name == "EquipButton")
        {
            switch (Inventory.instance.slot_Table[number].info)
            {
                case info.HELMATS:
                    if (helmatSlot.helmatEquip.info == info.Default)
                    {
                        helmatSlot.itemNumber = (Inventory.instance.slot_Table[number].DropItemNumber + 0.1f);
                        helmatSlot.image.sprite = Inventory.instance.slot_Table[number].transform.GetChild(0).GetComponent<Image>().sprite;
                        Equipment.instance.item.helmat_Item_Datas.Add(itemData.helmat_Item_Datas[0]);
                        helmatSlot.helmatEquip = Equipment.instance.item.helmat_Item_Datas[0];
                        helmatSlot.helmatEquip.info = info.HELMATS;
                        Inventory.instance.slot_Table[number].item.helmat_Item_Datas.Clear();
                        Inventory.instance.slot_Table[number].checkItemEquip = true;
                        Inventory.instance.ItemImageChange(Inventory.instance.slot_Table[number]);
                        equipeMentSocket[0].spriteRenderer.sprite = Resources.Load<Sprite>("ItemImages/Helmats/" + Equipment.instance.item.helmat_Item_Datas[0].item_Numbers);
                        if (helmatSlot.helmatEquip.Effect == true)
                            equipeMentSocket[0].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Helmats/" + Equipment.instance.item.helmat_Item_Datas[0].item_Numbers + "/"));
                        else
                            equipeMentSocket[0].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Helmats/HelmatsAni/"));
                    }
                    break;
                case info.ARMORS:
                    if (armorSlot.ArmorEquip.info == info.Default)
                    {
                        armorSlot.itemNumber = (Inventory.instance.slot_Table[number].DropItemNumber + 0.1f);
                        armorSlot.image.sprite = Inventory.instance.slot_Table[number].transform.GetChild(0).GetComponent<Image>().sprite;
                        Equipment.instance.item.armor_Item_Datas.Add(itemData.armor_Item_Datas[0]);
                        armorSlot.ArmorEquip = Equipment.instance.item.armor_Item_Datas[0];
                        Inventory.instance.slot_Table[number].item.armor_Item_Datas.Clear();
                        Inventory.instance.slot_Table[number].checkItemEquip = true;
                        Inventory.instance.ItemImageChange(Inventory.instance.slot_Table[number]);
                        equipeMentSocket[1].spriteRenderer.sprite = Resources.Load<Sprite>("ItemImages/Armors/" + Equipment.instance.item.armor_Item_Datas[0].item_Numbers);
                        if (armorSlot.ArmorEquip.Effect == true)
                            equipeMentSocket[1].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Armors/" + Equipment.instance.item.armor_Item_Datas[0].item_Numbers + "/"));
                        else
                            equipeMentSocket[1].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Armors/ArmorsAni/"));
                    }
                    break;
                case info.WEAPONS:
                    if (weaponSlot.weaponEquip.info == info.Default)
                    {
                        weaponSlot.itemNumber = (Inventory.instance.slot_Table[number].DropItemNumber + 0.1f);
                        weaponSlot.image.sprite = Inventory.instance.slot_Table[number].transform.GetChild(0).GetComponent<Image>().sprite;
                        Equipment.instance.item.weapon_Item_Datas.Add(itemData.weapon_Item_Datas[0]);
                        weaponSlot.weaponEquip = Equipment.instance.item.weapon_Item_Datas[0];
                        Inventory.instance.slot_Table[number].item.weapon_Item_Datas.Clear();
                        Inventory.instance.slot_Table[number].checkItemEquip = true;
                        Inventory.instance.ItemImageChange(Inventory.instance.slot_Table[number]);
                        equipeMentSocket[2].spriteRenderer.sprite = Resources.Load<Sprite>("ItemImages/Weapons/" + Equipment.instance.item.weapon_Item_Datas[0].item_Numbers + "/" + +Equipment.instance.item.weapon_Item_Datas[0].item_Numbers);
                        if (weaponSlot.weaponEquip.Effect == true)
                            equipeMentSocket[2].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Weapons/" + Equipment.instance.item.weapon_Item_Datas[0].item_Numbers + "/"));
                        else
                            equipeMentSocket[2].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Weapons/WeaponsAni/"));
                        weaponLight();
                    }
                    break;
                case info.SHIELDS:
                    if (shieldSlot.shieldEquip.info == info.Default)
                    {
                        shieldSlot.itemNumber = (Inventory.instance.slot_Table[number].DropItemNumber + 0.1f);
                        shieldSlot.image.sprite = Inventory.instance.slot_Table[number].transform.GetChild(0).GetComponent<Image>().sprite;
                        Equipment.instance.item.shield_Item_Datas.Add(itemData.shield_Item_Datas[0]);
                        shieldSlot.shieldEquip = Equipment.instance.item.shield_Item_Datas[0];
                        Inventory.instance.slot_Table[number].item.shield_Item_Datas.Clear();
                        Inventory.instance.slot_Table[number].checkItemEquip = true;
                        Inventory.instance.ItemImageChange(Inventory.instance.slot_Table[number]);
                    }
                    break;
                case info.SHOES:
                    if (shoeseSlot.shoesEquip.info == info.Default)
                    {
                        shoeseSlot.itemNumber = (Inventory.instance.slot_Table[number].DropItemNumber + 0.1f);
                        shoeseSlot.image.sprite = Inventory.instance.slot_Table[number].transform.GetChild(0).GetComponent<Image>().sprite;
                        Equipment.instance.item.shoes_Item_Datas.Add(itemData.shoes_Item_Datas[0]);
                        shoeseSlot.shoesEquip = Equipment.instance.item.shoes_Item_Datas[0];
                        Inventory.instance.slot_Table[number].item.shoes_Item_Datas.Clear();
                        Inventory.instance.slot_Table[number].checkItemEquip = true;
                        Inventory.instance.ItemImageChange(Inventory.instance.slot_Table[number]);
                    }
                    break;
                case info.GLOVES:
                    if (glovesSlot.glovesEquip.info == info.Default)
                    {
                        glovesSlot.itemNumber = (Inventory.instance.slot_Table[number].DropItemNumber + 0.1f);
                        glovesSlot.image.sprite = Inventory.instance.slot_Table[number].transform.GetChild(0).GetComponent<Image>().sprite;
                        Equipment.instance.item.gloves_Item_Datas.Add(itemData.gloves_Item_Datas[0]);
                        glovesSlot.glovesEquip = Equipment.instance.item.gloves_Item_Datas[0];
                        Inventory.instance.slot_Table[number].item.gloves_Item_Datas.Clear();
                        Inventory.instance.slot_Table[number].checkItemEquip = true;
                        Inventory.instance.ItemImageChange(Inventory.instance.slot_Table[number]);
                    }
                    break;
                case info.RINGS:
                    if (ringsSlots.ringsEquip.info == info.Default)
                    {
                        ringsSlots.itemNumber = (Inventory.instance.slot_Table[number].DropItemNumber + 0.1f);
                        ringsSlots.image.sprite = Inventory.instance.slot_Table[number].transform.GetChild(0).GetComponent<Image>().sprite;
                        Equipment.instance.item.ring_Item_Datas.Add(itemData.ring_Item_Datas[0]);
                        ringsSlots.ringsEquip = Equipment.instance.item.ring_Item_Datas[0];
                        Inventory.instance.slot_Table[number].item.ring_Item_Datas.Clear();
                        Inventory.instance.slot_Table[number].checkItemEquip = true;
                        Inventory.instance.ItemImageChange(Inventory.instance.slot_Table[number]);
                        ringsSlots.ring1S = true;
                    }
                    else if (ringsSlots2.ringsEquip.info == info.Default)
                    {
                        ringsSlots2.itemNumber = (Inventory.instance.slot_Table[number].DropItemNumber + 0.1f);
                        ringsSlots2.image.sprite = Inventory.instance.slot_Table[number].transform.GetChild(0).GetComponent<Image>().sprite;
                        Equipment.instance.item.ring_Item_Datas.Add(itemData.ring_Item_Datas[0]);
                        ringsSlots2.ringsEquip = Equipment.instance.item.ring_Item_Datas[0];
                        Inventory.instance.slot_Table[number].item.ring_Item_Datas.Clear();
                        Inventory.instance.slot_Table[number].checkItemEquip = true;
                        Inventory.instance.ItemImageChange(Inventory.instance.slot_Table[number]);
                        ringsSlots.ring2S = true;
                    }
                    break;
                case info.NECKLACES:
                    if (necklaceSlot.necklaceEquip.info == info.Default)
                    {
                        necklaceSlot.itemNumber = (Inventory.instance.slot_Table[number].DropItemNumber + 0.1f);
                        necklaceSlot.image.sprite = Inventory.instance.slot_Table[number].transform.GetChild(0).GetComponent<Image>().sprite;
                        Equipment.instance.item.necklace_Item_Datas.Add(itemData.necklace_Item_Datas[0]);
                        necklaceSlot.necklaceEquip = Equipment.instance.item.necklace_Item_Datas[0];
                        Inventory.instance.slot_Table[number].item.necklace_Item_Datas.Clear();
                        Inventory.instance.slot_Table[number].checkItemEquip = true;
                        Inventory.instance.ItemImageChange(Inventory.instance.slot_Table[number]);
                    }
                    break;
            }
            Inventory.instance.invenSlotInfo.SetActive(false);
            Inventory.instance.equipBtt.SetActive(false);
            Equipment.instance.unequipBtt.SetActive(false);
        }
        else if (data.selectedObject.name == "UnEquipButton")
        {
            Equipment.instance.Eqbool = true;
            switch (Equipment.instance.equipInfo)
            {
                case info.HELMATS:
                    if (helmatSlot.itemNumber != -1)
                        Inventory.instance.AddItem(info.HELMATS, (int)helmatSlot.itemNumber, 1);
                    helmatSlot.image.sprite = Resources.Load<Sprite>("Gamefiles/Sprites/Hud/Menu/EquipMent/EquipSlots/HelmatSlotsSprite");
                    Equipment.instance.item.helmat_Item_Datas.Clear();
                    helmatSlot.helmatEquip = new helmat_Item_Data();
                    helmatSlot.itemNumber = -1;
                    equipeMentSocket[0].Dequip();
                    break;
                case info.ARMORS:
                    if (armorSlot.itemNumber != -1)
                        Inventory.instance.AddItem(info.ARMORS, (int)armorSlot.itemNumber, 1);
                    armorSlot.image.sprite = Resources.Load<Sprite>("Gamefiles/Sprites/Hud/Menu/EquipMent/EquipSlots/ArmorSlotsSprite2");
                    Equipment.instance.item.armor_Item_Datas.Clear();
                    armorSlot.ArmorEquip = new armor_Item_Data();
                    armorSlot.itemNumber = -1;
                    equipeMentSocket[1].Dequip();
                    break;
                case info.WEAPONS:
                    if (weaponSlot.itemNumber != -1)
                        Inventory.instance.AddItem(info.WEAPONS, (int)weaponSlot.itemNumber, 1);
                    weaponSlot.image.sprite = Resources.Load<Sprite>("Gamefiles/Sprites/Hud/Menu/EquipMent/EquipSlots/WeaponSlotsSprite");
                    Equipment.instance.item.weapon_Item_Datas.Clear();
                    weaponSlot.weaponEquip = new weapon_Item_Data();
                    weaponSlot.itemNumber = -1;
                    equipeMentSocket[2].Dequip();
                    weaponLight();
                    break;
                case info.SHIELDS:
                    if (shieldSlot.itemNumber != -1)
                        Inventory.instance.AddItem(info.SHIELDS, (int)shieldSlot.itemNumber, 1);
                    shieldSlot.image.sprite = Resources.Load<Sprite>("Gamefiles/Sprites/Hud/Menu/EquipMent/EquipSlots/ShildSlotsSprite");
                    Equipment.instance.item.shield_Item_Datas.Clear();
                    shieldSlot.shieldEquip = new shield_Item_Data();
                    shieldSlot.itemNumber = -1;
                    break;
                case info.SHOES:
                    if (shoeseSlot.itemNumber != -1)
                        Inventory.instance.AddItem(info.SHOES, (int)shoeseSlot.itemNumber, 1);
                    shoeseSlot.image.sprite = Resources.Load<Sprite>("Gamefiles/Sprites/Hud/Menu/EquipMent/EquipSlots/ShoeseSlotsSprite");
                    Equipment.instance.item.shoes_Item_Datas.Clear();
                    shoeseSlot.shoesEquip = new shoes_Item_Data();
                    shoeseSlot.itemNumber = -1;
                    break;
                case info.GLOVES:
                    if (glovesSlot.itemNumber != -1)
                        Inventory.instance.AddItem(info.GLOVES, (int)glovesSlot.itemNumber, 1);
                    glovesSlot.image.sprite = Resources.Load<Sprite>("Gamefiles/Sprites/Hud/Menu/EquipMent/EquipSlots/GlovesSlotsSprite");
                    Equipment.instance.item.gloves_Item_Datas.Clear();
                    glovesSlot.glovesEquip = new gloves_Item_Data();
                    glovesSlot.itemNumber = -1;
                    break;
                case info.RINGS:
                    if (ringsSlots.ringsEquip.info == info.RINGS && ringName == "Ring1Slot")
                    {
                        if (ringsSlots.itemNumber != -1)
                            Inventory.instance.AddItem(info.RINGS, (int)ringsSlots.itemNumber, 1);
                        ringsSlots.image.sprite = Resources.Load<Sprite>("Gamefiles/Sprites/Hud/Menu/EquipMent/EquipSlots/RingsSlotsSprite");
                        Equipment.instance.item.ring_Item_Datas.Remove(ringsSlots.ringsEquip);
                        ringsSlots.ringsEquip = new ring_Item_Data();
                        ringsSlots.itemNumber = -1;
                        ringsSlots.ring1S = false;
                    }
                    else if (ringsSlots2.ringsEquip.info == info.RINGS && ringName == "Ring2Slot")
                    {
                        if (ringsSlots2.itemNumber != -1)
                            Inventory.instance.AddItem(info.RINGS, (int)ringsSlots2.itemNumber, 1);
                        ringsSlots2.image.sprite = Resources.Load<Sprite>("Gamefiles/Sprites/Hud/Menu/EquipMent/EquipSlots/RingsSlotsSprite");
                        Equipment.instance.item.ring_Item_Datas.Remove(ringsSlots2.ringsEquip);
                        ringsSlots2.ringsEquip = new ring_Item_Data();
                        ringsSlots2.itemNumber = -1;
                        ringsSlots.ring2S = false;
                    }
                    break;
                case info.NECKLACES:
                    if (necklaceSlot.itemNumber != -1)
                        Inventory.instance.AddItem(info.NECKLACES, (int)necklaceSlot.itemNumber, 1);
                    necklaceSlot.image.sprite = Resources.Load<Sprite>("Gamefiles/Sprites/Hud/Menu/EquipMent/EquipSlots/NecklaceSlotsSprite");
                    Equipment.instance.item.necklace_Item_Datas.Clear();
                    necklaceSlot.necklaceEquip = new necklace_Item_Data();
                    necklaceSlot.itemNumber = -1;
                    break;
            }
        }
        Inventory.instance.invenSlotInfo.SetActive(false);
        Inventory.instance.equipBtt.SetActive(false);
        Equipment.instance.unequipBtt.SetActive(false);
        ItemsClear();
        Equipment.instance.Eqbool = false;
    }

    public void EquipMentLoad(info info)
    {
        switch (info)
        {
            case info.HELMATS:
                if (helmatSlot.helmatEquip.info == info.Default)
                {
                    for (int i = 0; i < ItemDatabase.instance.helmats.Count; i++)
                    {
                        if (Equipment.instance.item.helmat_Item_Datas[0].item_Numbers == ItemDatabase.instance.helmats[i].item_Numbers)
                        {
                            helmatSlot.itemNumber = i + 0.1f;
                            break;
                        }
                    }
                    helmatSlot.image.sprite = Resources.Load<Sprite>("ItemImages/Helmats/" + Equipment.instance.item.helmat_Item_Datas[0].item_Numbers);
                    helmatSlot.helmatEquip = Equipment.instance.item.helmat_Item_Datas[0];
                    equipeMentSocket[0].spriteRenderer.sprite = Resources.Load<Sprite>("ItemImages/Helmats/" + Equipment.instance.item.helmat_Item_Datas[0].item_Numbers);
                    equipeMentSocket[0].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Helmats/HelmatsAni/"));
                    if (helmatSlot.helmatEquip.Effect == true)
                        equipeMentSocket[0].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Helmats/" + Equipment.instance.item.helmat_Item_Datas[0].item_Numbers + "/"));
                    else
                        equipeMentSocket[0].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Helmats/HelmatsAni/"));
                }
                break;
            case info.ARMORS:
                if (armorSlot.ArmorEquip.info == info.Default)
                {
                    for (int i = 0; i < ItemDatabase.instance.armors.Count; i++)
                    {
                        if (Equipment.instance.item.armor_Item_Datas[0].item_Numbers == ItemDatabase.instance.armors[i].item_Numbers)
                        {
                            armorSlot.itemNumber = i + 0.1f;
                            break;
                        }
                    }
                    armorSlot.image.sprite = Resources.Load<Sprite>("ItemImages/Armors/" + Equipment.instance.item.armor_Item_Datas[0].item_Numbers);
                    armorSlot.ArmorEquip = Equipment.instance.item.armor_Item_Datas[0];
                    equipeMentSocket[1].spriteRenderer.sprite = Resources.Load<Sprite>("ItemImages/Armors/" + Equipment.instance.item.armor_Item_Datas[0].item_Numbers);
                    equipeMentSocket[1].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Armors/ArmorsAni/"));
                    if (armorSlot.ArmorEquip.Effect == true)
                        equipeMentSocket[1].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Armors/" + Equipment.instance.item.armor_Item_Datas[0].item_Numbers + "/"));
                    else
                        equipeMentSocket[1].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Armors/ArmorsAni/"));
                }
                break;
            case info.WEAPONS:
                if (weaponSlot.weaponEquip.info == info.Default)
                {
                    for (int i = 0; i < ItemDatabase.instance.weapons.Count; i++)
                    {
                        if (Equipment.instance.item.weapon_Item_Datas[0].item_Numbers == ItemDatabase.instance.weapons[i].item_Numbers)
                        {
                            weaponSlot.itemNumber = i + 0.1f;
                            break;
                        }
                    }
                    weaponSlot.image.sprite = Resources.Load<Sprite>("ItemImages/Weapons/" + Equipment.instance.item.weapon_Item_Datas[0].item_Numbers);
                    weaponSlot.weaponEquip = Equipment.instance.item.weapon_Item_Datas[0];
                    equipeMentSocket[2].spriteRenderer.sprite = Resources.Load<Sprite>("ItemImages/Weapons/" + Equipment.instance.item.weapon_Item_Datas[0].item_Numbers);
                    equipeMentSocket[2].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Weapons/WeaponsAni/"));
                    if (weaponSlot.weaponEquip.Effect == true)
                        equipeMentSocket[2].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Weapons/" + Equipment.instance.item.weapon_Item_Datas[0].item_Numbers + "/"));
                    else
                        equipeMentSocket[2].Equip(Resources.LoadAll<AnimationClip>("ItemImages/Weapons/WeaponsAni/"));
                    weaponLight();
                }
                break;
            case info.SHIELDS:
                if (shieldSlot.shieldEquip.info == info.Default)
                {
                    for (int i = 0; i < ItemDatabase.instance.shields.Count; i++)
                    {
                        if (Equipment.instance.item.shield_Item_Datas[0].item_Numbers == ItemDatabase.instance.shields[i].item_Numbers)
                        {
                            shieldSlot.itemNumber = i + 0.1f;
                            break;
                        }
                    }
                    shieldSlot.image.sprite = Resources.Load<Sprite>("ItemImages/Shields/" + Equipment.instance.item.shield_Item_Datas[0].item_Numbers);
                    shieldSlot.shieldEquip = Equipment.instance.item.shield_Item_Datas[0];

                }
                break;
            case info.SHOES:
                if (shoeseSlot.shoesEquip.info == info.Default)
                {
                    for (int i = 0; i < ItemDatabase.instance.shoeses.Count; i++)
                    {
                        if (Equipment.instance.item.shoes_Item_Datas[0].item_Numbers == ItemDatabase.instance.shoeses[i].item_Numbers)
                        {
                            shoeseSlot.itemNumber = i + 0.1f;
                            break;
                        }
                    }
                    shoeseSlot.image.sprite = Resources.Load<Sprite>("ItemImages/Shoes/" + Equipment.instance.item.shoes_Item_Datas[0].item_Numbers);
                    shoeseSlot.shoesEquip = Equipment.instance.item.shoes_Item_Datas[0];

                }
                break;
            case info.GLOVES:
                if (glovesSlot.glovesEquip.info == info.Default)
                {
                    for (int i = 0; i < ItemDatabase.instance.gloves.Count; i++)
                    {
                        if (Equipment.instance.item.gloves_Item_Datas[0].item_Numbers == ItemDatabase.instance.gloves[i].item_Numbers)
                        {
                            glovesSlot.itemNumber = i + 0.1f;
                            break;
                        }
                    }
                    glovesSlot.image.sprite = Resources.Load<Sprite>("ItemImages/Gloves/" + Equipment.instance.item.gloves_Item_Datas[0].item_Numbers);
                    glovesSlot.glovesEquip = Equipment.instance.item.gloves_Item_Datas[0];

                }
                break;
            case info.RINGS:
                if (ringsSlots.ringsEquip.info == info.Default && ringsSlots.ring1S == true)
                {
                    for (int i = 0; i < ItemDatabase.instance.rings.Count; i++)
                    {
                        if (Equipment.instance.item.ring_Item_Datas[0].item_Numbers == ItemDatabase.instance.rings[i].item_Numbers)
                        {
                            ringsSlots.itemNumber = i + 0.1f;
                            break;
                        }
                    }
                    ringsSlots.image.sprite = Resources.Load<Sprite>("ItemImages/Rings/" + Equipment.instance.item.ring_Item_Datas[0].item_Numbers);
                    ringsSlots.ringsEquip = Equipment.instance.item.ring_Item_Datas[0];

                }
                else if (ringsSlots2.ringsEquip.info == info.Default && ringsSlots.ring2S == true)
                {
                    for (int i = 0; i < ItemDatabase.instance.rings.Count; i++)
                    {
                        if (Equipment.instance.item.ring_Item_Datas[0].item_Numbers == ItemDatabase.instance.rings[i].item_Numbers)
                        {
                            ringsSlots2.itemNumber = i + 0.1f;
                            break;
                        }
                    }
                    ringsSlots2.image.sprite = Resources.Load<Sprite>("ItemImages/Rings/" + Equipment.instance.item.ring_Item_Datas[0].item_Numbers);
                    ringsSlots2.ringsEquip = Equipment.instance.item.ring_Item_Datas[0];

                }
                break;
            case info.NECKLACES:
                if (necklaceSlot.necklaceEquip.info == info.Default)
                {
                    for (int i = 0; i < ItemDatabase.instance.necklaces.Count; i++)
                    {
                        if (Equipment.instance.item.necklace_Item_Datas[0].item_Numbers == ItemDatabase.instance.necklaces[i].item_Numbers)
                        {
                            necklaceSlot.itemNumber = i + 0.1f;
                            break;
                        }
                    }
                    necklaceSlot.image.sprite = Resources.Load<Sprite>("ItemImages/Necklaces/" + Equipment.instance.item.necklace_Item_Datas[0].item_Numbers);
                    necklaceSlot.necklaceEquip = Equipment.instance.item.necklace_Item_Datas[0];

                }
                break;
        }
        ItemsClear();
    }
    public void ItemsClear()
    {
        Equipment.instance.PlayerState();
        itemData.armor_Item_Datas.Clear();
        itemData.helmat_Item_Datas.Clear();
        itemData.gloves_Item_Datas.Clear();
        itemData.necklace_Item_Datas.Clear();
        itemData.weapon_Item_Datas.Clear();
        itemData.ring_Item_Datas.Clear();
        itemData.shield_Item_Datas.Clear();
        itemData.shoes_Item_Datas.Clear();

    }
}
