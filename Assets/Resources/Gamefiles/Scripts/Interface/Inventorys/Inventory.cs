using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Camera textCamera;
    public Transform slot;
    public List<slots> slot_Table = new List<slots>();
    public GameObject DropItem;
    public Transform player;
    public Transform draggingItem;
    public slots enteredSlot;
    public Button button;
    public Sprite[] buttonimage;
    public GameObject invenSlotInfo;
    public Text infoText;
    public Text infonameText;
    public Text infoitemExp;
    public Text infonameSub;
    public GameObject equipBtt;
    //오더아이템 드랍할때 갯수에 관해
    public GameObject DropOtherItem;
    public slots dropOtherSlot;
    public InputField inputField;
    //
    public EquipmentCheck isEquip;
    /*     [Header("0 = up, 1 = down , 2 = left, 3 = right")]
        public List<GameObject> helmatObj;
        public List<GameObject> armorObj;
        [Header("0 = up, 1 = down , 2 = left, 3 = right")]
        public List<SpriteRenderer> helmatSp;
        public List<SpriteRenderer> ArmorSp; */
    int EmptySlot;
    public int otherDorpsitemGet;

    public Transform itemNotice;
    public Transform canvasNotice;

    private void Awake()
    {
        instance = this;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Transform newSlot = Instantiate(slot);
                newSlot.name = "slot" + (i + 1) + "." + (j + 1);
                newSlot.SetParent(transform);
                RectTransform slotRect = newSlot.GetComponent<RectTransform>();
                slotRect.localPosition = new Vector2((-475) + (115 * j), (400) - (115 * i));
                newSlot.GetComponent<slots>().number = i * 9 + j;
                slot_Table.Add(newSlot.GetComponent<slots>());
                newSlot.localScale = new Vector2(1, 1);
            }
        }
        Transform newmSlot = Instantiate(slot);
        newmSlot.name = "ItemDelete";
        newmSlot.SetParent(transform);
        RectTransform slotmRect = newmSlot.GetComponent<RectTransform>();
        slotmRect.localPosition = new Vector2((-475) + (115 * 9), (400) - (115 * 5));
        newmSlot.GetComponent<slots>().number = 54;
        newmSlot.GetComponent<Image>().sprite = Resources.Load<Sprite>("DropItemslotIcon");
        newmSlot.localScale = new Vector2(1, 1);
        invenSlotInfo.gameObject.SetActive(false);
        DropOtherItem.SetActive(false);

    }
    public void OtherDrops(slots drop)
    {
        DropOtherItem.SetActive(true);
        dropOtherSlot = drop;
    }
    public void OtherDrops2()
    {
        if (inputField.text != "")
            otherDorpsitemGet = int.Parse(inputField.text);
    }
    public void OtherDrops3()
    {
        if (otherDorpsitemGet != 0)
        {
            dropOtherSlot.checkItemDrop = true;
            ItemImageChange(dropOtherSlot);
        }
    }
    /*     WEAPONS, // 무기목록
        SHIELDS, // 보조목록
        HELMATS, // 헬맷목록
        ARMORS, // 갑옷목록
        GLOVES, // 장갑목록
        SHOES, // 신발목록
        RINGS, // 반지목록
        NECKLACES, // 목걸이목록
        CONSUMABLES, // 소비아이템목록
        OTHERS // 오더목록 */
    public void s()
    {
        AddItem(info.WEAPONS, 0, 1);
        AddItem(info.WEAPONS, 1, 1);
        AddItem(info.SHIELDS, 0, 1);
        AddItem(info.SHIELDS, 1, 1);
        AddItem(info.SHIELDS, 2, 1);
        AddItem(info.HELMATS, 0, 1);
        AddItem(info.HELMATS, 1, 1);
        AddItem(info.ARMORS, 0, 1);
        AddItem(info.ARMORS, 1, 1);
        AddItem(info.GLOVES, 0, 1);
        AddItem(info.SHOES, 0, 1);
        AddItem(info.RINGS, 0, 1);
        AddItem(info.NECKLACES, 0, 1);
        AddItem(info.CONSUMABLES, 0, 1);
        AddItem(info.OTHERS, 0, 40);
        AddItem(info.OTHERS, 1, 40);
        AddItem(info.OTHERS, 2, 40);
    }
    //아이템 갯수 파악.
    public void ItemSlotsCheck(int itemfullchack, bool check)
    {
        for (int i = 0; i < slot_Table.Count; i++)
            if (slot_Table[i].checkItem == true)
            {
                if (check == false)
                {
                    itemfullchack += 1;
                    if (itemfullchack == 20) button.image.sprite = buttonimage[1];
                    else if (itemfullchack == 30) button.image.sprite = buttonimage[2];
                    else if (itemfullchack == 45) button.image.sprite = buttonimage[3];
                    else if (itemfullchack < 20) button.image.sprite = buttonimage[0];
                }
                else
                {
                    itemfullchack += 1;
                    if (itemfullchack == 20) button.image.sprite = buttonimage[4];
                    else if (itemfullchack == 30) button.image.sprite = buttonimage[5];
                    else if (itemfullchack == 45) button.image.sprite = buttonimage[6];
                    else if (itemfullchack < 20) button.image.sprite = buttonimage[7];
                }
            }
    }
    public void AddItem(info type, float number, int ItemCount)
    {
        Transform notice = Instantiate(itemNotice);
        if (Equipment.instance.Eqbool != true)
        {
            notice.SetParent(canvasNotice);
            Vector3 screenPos = textCamera.WorldToScreenPoint(player.transform.position);
            notice.position = new Vector3(screenPos.x, screenPos.y + 150f, 0);
            notice.name = "moon";
        }
        else
        {
            notice.name = "None";
            GameObject.Destroy(GameObject.Find("None"));
        }
        int sameItemSlotCount = -1;
        int sameItemSlotCount2 = -1;
        //ItemSlotsCheck(0, false);
        for (int i = 0; i < slot_Table.Count; i++)
        {
            if (slot_Table[i].checkItem == false)
            {
                switch (type)
                {
                    case info.WEAPONS:
                        slot_Table[i].item.weapon_Item_Datas.Add(ItemDatabase.instance.weapons[(int)number]);
                        slot_Table[i].item.weapon_Item_Datas[0].item_Count = ItemCount;
                        if (Equipment.instance.Eqbool != true)
                            notice.GetComponent<ItemNoticeBox>().ItemNumPlay(i, type, slot_Table[i].item.weapon_Item_Datas[0].itemClass);
                        break;
                    case info.SHIELDS:
                        slot_Table[i].item.shield_Item_Datas.Add(ItemDatabase.instance.shields[(int)number]);
                        slot_Table[i].item.shield_Item_Datas[0].item_Count = ItemCount;
                        if (Equipment.instance.Eqbool != true)
                            notice.GetComponent<ItemNoticeBox>().ItemNumPlay(i, type, slot_Table[i].item.shield_Item_Datas[0].itemClass);
                        break;
                    case info.HELMATS:
                        slot_Table[i].item.helmat_Item_Datas.Add(ItemDatabase.instance.helmats[(int)number]);
                        slot_Table[i].item.helmat_Item_Datas[0].item_Count = ItemCount;
                        if (Equipment.instance.Eqbool != true)
                            notice.GetComponent<ItemNoticeBox>().ItemNumPlay(i, type, slot_Table[i].item.helmat_Item_Datas[0].itemClass);
                        break;
                    case info.ARMORS:
                        slot_Table[i].item.armor_Item_Datas.Add(ItemDatabase.instance.armors[(int)number]);
                        slot_Table[i].item.armor_Item_Datas[0].item_Count = ItemCount;
                        if (Equipment.instance.Eqbool != true)
                            notice.GetComponent<ItemNoticeBox>().ItemNumPlay(i, type, slot_Table[i].item.armor_Item_Datas[0].itemClass);
                        break;
                    case info.GLOVES:
                        slot_Table[i].item.gloves_Item_Datas.Add(ItemDatabase.instance.gloves[(int)number]);
                        slot_Table[i].item.gloves_Item_Datas[0].item_Count = ItemCount;
                        if (Equipment.instance.Eqbool != true)
                            notice.GetComponent<ItemNoticeBox>().ItemNumPlay(i, type, slot_Table[i].item.gloves_Item_Datas[0].itemClass);
                        break;
                    case info.SHOES:
                        slot_Table[i].item.shoes_Item_Datas.Add(ItemDatabase.instance.shoeses[(int)number]);
                        slot_Table[i].item.shoes_Item_Datas[0].item_Count = ItemCount;
                        if (Equipment.instance.Eqbool != true)
                            notice.GetComponent<ItemNoticeBox>().ItemNumPlay(i, type, slot_Table[i].item.shoes_Item_Datas[0].itemClass);
                        break;
                    case info.RINGS:
                        slot_Table[i].item.ring_Item_Datas.Add(ItemDatabase.instance.rings[(int)number]);
                        slot_Table[i].item.ring_Item_Datas[0].item_Count = ItemCount;
                        if (Equipment.instance.Eqbool != true)
                            notice.GetComponent<ItemNoticeBox>().ItemNumPlay(i, type, slot_Table[i].item.ring_Item_Datas[0].itemClass);
                        break;
                    case info.NECKLACES:
                        slot_Table[i].item.necklace_Item_Datas.Add(ItemDatabase.instance.necklaces[(int)number]);
                        slot_Table[i].item.necklace_Item_Datas[0].item_Count = ItemCount;
                        if (Equipment.instance.Eqbool != true)
                            notice.GetComponent<ItemNoticeBox>().ItemNumPlay(i, type, slot_Table[i].item.necklace_Item_Datas[0].itemClass);
                        break;
                    case info.CONSUMABLES:
                        slot_Table[i].item.consumable_Item_Datas.Add(ItemDatabase.instance.consumables[(int)number]);
                        slot_Table[i].item.consumable_Item_Datas[0].item_Count = ItemCount;
                        notice.GetComponent<ItemNoticeBox>().ItemNumPlay(i, type, slot_Table[i].item.consumable_Item_Datas[0].itemClass);
                        break;
                    case info.OTHERS:
                        slot_Table[i].item.other_Quest_Item_Datas.Add(ItemDatabase.instance.other_quests[(int)number]);
                        slot_Table[i].item.other_Quest_Item_Datas[0].item_Count += ItemCount;
                        notice.GetComponent<ItemNoticeBox>().ItemNumPlay(i, type, slot_Table[i].item.other_Quest_Item_Datas[0].item_style);
                        //임시이론.
                        for (int j = 0; j < slot_Table.Count; j++)
                        {
                            if (slot_Table[j].info == info.OTHERS && slot_Table[i].item.other_Quest_Item_Datas[0] == slot_Table[j].item.other_Quest_Item_Datas[0]
                            && j != i && slot_Table[j].ItemCount < 99)
                            {
                                if (slot_Table[j].ItemCount + ItemCount > 99)
                                {
                                    sameItemSlotCount = -2;
                                    sameItemSlotCount2 = j;
                                    break;
                                }
                                sameItemSlotCount = j;
                                slot_Table[i].item.other_Quest_Item_Datas.RemoveAt(0);
                                break;
                            }
                        }
                        break;
                }
                // 여기도 마찬가지 필요하다면 꼭 수정 필요함.
                if (sameItemSlotCount == -1)
                {
                    slot_Table[i].ItemCountText.text = ItemCount.ToString();
                    slot_Table[i].info = type;
                    slot_Table[i].DropItemNumber = number + 0.000001f;
                    slot_Table[i].checkItem = true;
                    slot_Table[i].ItemCount = ItemCount;
                    ItemImageChange(slot_Table[i]);
                }
                else if (sameItemSlotCount == -2)
                {
                    int othercount = slot_Table[sameItemSlotCount2].ItemCount + ItemCount;
                    slot_Table[sameItemSlotCount2].ItemCount = 99;
                    slot_Table[sameItemSlotCount2].ItemCountText.text = 99.ToString();
                    slot_Table[i].ItemCountText.text = (othercount - 99).ToString();
                    slot_Table[i].info = type;
                    slot_Table[i].DropItemNumber = number + 0.000001f;
                    slot_Table[i].checkItem = true;
                    slot_Table[i].ItemCount = othercount - 99;
                    ItemImageChange(slot_Table[i]);
                }
                else if (slot_Table[sameItemSlotCount].ItemCount < 99)
                {
                    slot_Table[sameItemSlotCount].info = type;
                    slot_Table[sameItemSlotCount].DropItemNumber = number + 0.000001f;
                    slot_Table[sameItemSlotCount].checkItem = true;
                    slot_Table[sameItemSlotCount].ItemCount += ItemCount;
                    slot_Table[sameItemSlotCount].ItemCountText.text = slot_Table[sameItemSlotCount].ItemCount.ToString();
                    ItemImageChange(slot_Table[sameItemSlotCount]);
                    ///Debug.Log(slot_Table[sameItemSlotCount].ItemCount);
                }
                break;
            }
        }
        EmptySlot = slot_Table.Count;
    }
    public void ItemImageChange(slots _slot)
    {
        // 아이템 개수표시
        if (_slot.info == info.OTHERS)
        {
            _slot.ItemCountText.gameObject.SetActive(true);
        }
        else
        {
            _slot.ItemCountText.gameObject.SetActive(false);
        }
        //아이템 버릴때
        if (_slot.checkItemDrop == true && _slot.info != info.Default && _slot.ItemCount >= otherDorpsitemGet)
        {
            GameObject InvenDrop;
            InvenDrop = Instantiate(Inventory.instance.DropItem);
            ItemSlotsCheck(-1, true);
            _slot.checkItemDrop = false;
            _slot.checkItem = false;
            //버릴때.
            if (_slot.info != info.OTHERS || (_slot.info == info.OTHERS && _slot.ItemCount == otherDorpsitemGet))
            {
                InvenDrop.GetComponent<DropItem>().itemType = _slot.info;
                InvenDrop.GetComponent<DropItem>().itemNumber = (_slot.DropItemNumber);
                InvenDrop.GetComponent<DropItem>().ItemCount = _slot.ItemCount;
                InvenDrop.GetComponent<DropItem>().dropCount = true;
            }
            else if (_slot.ItemCount > otherDorpsitemGet)
            {
                InvenDrop.GetComponent<DropItem>().itemType = _slot.info;
                InvenDrop.GetComponent<DropItem>().itemNumber = (_slot.DropItemNumber);
                InvenDrop.GetComponent<DropItem>().ItemCount = otherDorpsitemGet;
                InvenDrop.GetComponent<DropItem>().dropCount = true;
                _slot.checkItem = true;
            }
            Vector2 rand = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            InvenDrop.transform.position = new Vector2(player.transform.position.x + rand.x, player.transform.position.y + rand.y);
            //버릴때.
            switch (_slot.info)
            {
                case info.WEAPONS:
                    InvenDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ItemImages/Weapons/" + ItemDatabase.instance.weapons[(int)_slot.DropItemNumber].item_Numbers);
                    InvenDrop.gameObject.name = ItemDatabase.instance.weapons[(int)_slot.DropItemNumber].item_Name;
                    ItemDatabase.instance.weapons[(int)_slot.DropItemNumber].item_Count -= 1;
                    break;
                case info.SHIELDS:
                    InvenDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ItemImages/Shields/" + ItemDatabase.instance.shields[(int)_slot.DropItemNumber].item_Numbers);
                    InvenDrop.gameObject.name = ItemDatabase.instance.shields[(int)_slot.DropItemNumber].item_Name;
                    ItemDatabase.instance.shields[(int)_slot.DropItemNumber].item_Count -= 1;
                    break;
                case info.HELMATS:
                    InvenDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ItemImages/Helmats/" + ItemDatabase.instance.helmats[(int)_slot.DropItemNumber].item_Numbers);
                    InvenDrop.gameObject.name = ItemDatabase.instance.helmats[(int)_slot.DropItemNumber].item_Name;
                    ItemDatabase.instance.helmats[(int)_slot.DropItemNumber].item_Count -= 1;
                    break;
                case info.ARMORS:
                    InvenDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ItemImages/Armors/" + ItemDatabase.instance.armors[(int)_slot.DropItemNumber].item_Numbers);
                    InvenDrop.gameObject.name = ItemDatabase.instance.armors[(int)_slot.DropItemNumber].item_Name;
                    ItemDatabase.instance.armors[(int)_slot.DropItemNumber].item_Count -= 1;
                    break;
                case info.GLOVES:
                    InvenDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ItemImages/Gloves/" + ItemDatabase.instance.gloves[(int)_slot.DropItemNumber].item_Numbers);
                    InvenDrop.gameObject.name = ItemDatabase.instance.gloves[(int)_slot.DropItemNumber].item_Name;
                    ItemDatabase.instance.gloves[(int)_slot.DropItemNumber].item_Count -= 1;
                    break;
                case info.SHOES:
                    InvenDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ItemImages/Shoes/" + ItemDatabase.instance.shoeses[(int)_slot.DropItemNumber].item_Numbers);
                    InvenDrop.gameObject.name = ItemDatabase.instance.shoeses[(int)_slot.DropItemNumber].item_Name;
                    ItemDatabase.instance.shoeses[(int)_slot.DropItemNumber].item_Count -= 1;
                    break;
                case info.RINGS:
                    InvenDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ItemImages/Rings/" + ItemDatabase.instance.rings[(int)_slot.DropItemNumber].item_Numbers);
                    InvenDrop.gameObject.name = ItemDatabase.instance.rings[(int)_slot.DropItemNumber].item_Name;
                    ItemDatabase.instance.rings[(int)_slot.DropItemNumber].item_Count -= 1;
                    break;
                case info.NECKLACES:
                    InvenDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ItemImages/Necklaces/" + ItemDatabase.instance.necklaces[(int)_slot.DropItemNumber].item_Numbers);
                    InvenDrop.gameObject.name = ItemDatabase.instance.necklaces[(int)_slot.DropItemNumber].item_Name;
                    ItemDatabase.instance.necklaces[(int)_slot.DropItemNumber].item_Count -= 1;
                    break;
                case info.CONSUMABLES:
                    InvenDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ItemImages/Consumables/" + ItemDatabase.instance.consumables[(int)_slot.DropItemNumber].item_Numbers);
                    InvenDrop.gameObject.name = ItemDatabase.instance.consumables[(int)_slot.DropItemNumber].item_Name;
                    ItemDatabase.instance.consumables[(int)_slot.DropItemNumber].item_Count -= 1;
                    break;
                case info.OTHERS:
                    InvenDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ItemImages/Others/" + ItemDatabase.instance.other_quests[(int)_slot.DropItemNumber].item_Numbers);
                    InvenDrop.gameObject.name = ItemDatabase.instance.other_quests[(int)_slot.DropItemNumber].item_Name;
                    if (_slot.ItemCount >= otherDorpsitemGet)
                    {
                        _slot.ItemCount -= otherDorpsitemGet;
                        _slot.ItemCountText.text = dropOtherSlot.ItemCount.ToString();
                        ItemDatabase.instance.other_quests[(int)_slot.DropItemNumber].item_Count -= otherDorpsitemGet;
                    }
                    else if (_slot.ItemCount == otherDorpsitemGet)
                    {
                        ItemDatabase.instance.other_quests[(int)_slot.DropItemNumber].item_Count -= _slot.ItemCount;
                    }
                    break;
            }
            if (_slot.info != info.OTHERS || (_slot.info == info.OTHERS && _slot.ItemCount == 0))
            {
                _slot.transform.GetChild(0).GetComponent<Image>().sprite = null;
                _slot.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);
                _slot.info = info.Default;
                _slot.DropItemNumber = 0;
                _slot.ItemCount = 0;
                _slot.ItemCountText.text = null;
                _slot.ItemCountText.gameObject.SetActive(false);
            }
            otherDorpsitemGet = 0;
            inputField.text = null;
            dropOtherSlot = null;
            DropOtherItem.SetActive(false);
        }
        // 퀘스트시.
        else if (_slot.questItem == true)
        {
            ItemSlotsCheck(-1, true);
            _slot.questItem = false;
            _slot.checkItemDrop = false;
            _slot.checkItem = true;
            _slot.checkItemEquip = false;
            _slot.transform.GetChild(0).GetComponent<Image>().sprite = null;
            _slot.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);
            _slot.info = info.Default;
            _slot.DropItemNumber = 0;
            _slot.ItemCount = 0;
            _slot.ItemCountText.text = null;
            _slot.ItemCountText.gameObject.SetActive(false);
        }
        // 아이템 장착했을때.
        else if (_slot.checkItemEquip == true && _slot.info != info.Default)
        {
            ItemSlotsCheck(-1, true);
            _slot.checkItemDrop = false;
            _slot.checkItem = false;
            _slot.checkItemEquip = false;
            _slot.transform.GetChild(0).GetComponent<Image>().sprite = null;
            _slot.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);
            _slot.info = info.Default;
            _slot.DropItemNumber = 0;
            _slot.ItemCount = 0;
            _slot.ItemCountText.text = null;
            _slot.ItemCountText.gameObject.SetActive(false);
        }
        // 아이템 습득했을때.
        else
        {
            switch (_slot.info)
            {
                case info.WEAPONS:
                    _slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemImages/Weapons/" + _slot.GetComponent<slots>().item.weapon_Item_Datas[0].item_Numbers);
                    break;
                case info.SHIELDS:
                    _slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemImages/Shields/" + _slot.GetComponent<slots>().item.shield_Item_Datas[0].item_Numbers);
                    break;
                case info.HELMATS:
                    _slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemImages/Helmats/" + _slot.GetComponent<slots>().item.helmat_Item_Datas[0].item_Numbers);
                    break;
                case info.ARMORS:
                    _slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemImages/Armors/" + _slot.GetComponent<slots>().item.armor_Item_Datas[0].item_Numbers);
                    break;
                case info.GLOVES:
                    _slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemImages/Gloves/" + _slot.GetComponent<slots>().item.gloves_Item_Datas[0].item_Numbers);
                    break;
                case info.SHOES:
                    _slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemImages/Shoes/" + _slot.GetComponent<slots>().item.shoes_Item_Datas[0].item_Numbers);
                    break;
                case info.RINGS:
                    _slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemImages/Rings/" + _slot.GetComponent<slots>().item.ring_Item_Datas[0].item_Numbers);
                    break;
                case info.NECKLACES:
                    _slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemImages/Necklaces/" + _slot.GetComponent<slots>().item.necklace_Item_Datas[0].item_Numbers);
                    break;
                case info.CONSUMABLES:
                    _slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemImages/Consumables/" + _slot.GetComponent<slots>().item.consumable_Item_Datas[0].item_Numbers);
                    break;
                case info.OTHERS:
                    _slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemImages/Others/" + _slot.GetComponent<slots>().item.other_Quest_Item_Datas[0].item_Numbers);
                    break;
            }
            if (_slot.info != info.Default)
                _slot.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            invenSlotInfo.SetActive(false);
        }
    }

}
