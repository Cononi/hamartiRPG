using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcQuest : MonoBehaviour
{
    public GameObject test1;
    public Transform test2;
    public Text[] texts;
    public Sign sign;
    public void QuestClear()
    {
        for (int i = 0; i < QuestDatabase.instance.questlocalizedDatas[gameObject.name].Count; i++)
        {
            if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].npcDataSwitch == true && QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].infoType != info.Default)
            {
                for (int j = 0; j < Inventory.instance.slot_Table.Count; j++)
                {
                    if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].clearS == false)
                        if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].infoType == Inventory.instance.slot_Table[j].info
                        && QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].itemNumber == (int)Inventory.instance.slot_Table[j].DropItemNumber
                        && QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].clearItemNumber <= (int)Inventory.instance.slot_Table[j].ItemCount)
                        {
                            StartCoroutine(sign.PlaceNameCo(QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].questTitle + " 완료했다!!!!!\n"));
                            //StartCoroutine(sign.PlaceNameCo(QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].questTitle + " 소원을 들어줬다!!"));

                            // 인벤토리 클리어
                            if (Inventory.instance.slot_Table[j].info != info.OTHERS)
                            {
                                Inventory.instance.slot_Table[j].questItem = true;
                                Inventory.instance.slot_Table[j].item.weapon_Item_Datas.Clear();
                                Inventory.instance.slot_Table[j].item.shield_Item_Datas.Clear();
                                Inventory.instance.slot_Table[j].item.helmat_Item_Datas.Clear();
                                Inventory.instance.slot_Table[j].item.armor_Item_Datas.Clear();
                                Inventory.instance.slot_Table[j].item.gloves_Item_Datas.Clear();
                                Inventory.instance.slot_Table[j].item.shoes_Item_Datas.Clear();
                                Inventory.instance.slot_Table[j].item.ring_Item_Datas.Clear();
                                Inventory.instance.slot_Table[j].item.necklace_Item_Datas.Clear();
                                Inventory.instance.slot_Table[j].item.consumable_Item_Datas.Clear();
                                Inventory.instance.slot_Table[j].item.other_Quest_Item_Datas.Clear();
                                Inventory.instance.ItemImageChange(Inventory.instance.slot_Table[j]);
                            }
                            else
                            {
                                if (Inventory.instance.slot_Table[j].ItemCount <= 0)
                                {
                                    Inventory.instance.slot_Table[j].questItem = true;
                                    Inventory.instance.slot_Table[j].item.weapon_Item_Datas.Clear();
                                    Inventory.instance.slot_Table[j].item.shield_Item_Datas.Clear();
                                    Inventory.instance.slot_Table[j].item.helmat_Item_Datas.Clear();
                                    Inventory.instance.slot_Table[j].item.armor_Item_Datas.Clear();
                                    Inventory.instance.slot_Table[j].item.gloves_Item_Datas.Clear();
                                    Inventory.instance.slot_Table[j].item.shoes_Item_Datas.Clear();
                                    Inventory.instance.slot_Table[j].item.ring_Item_Datas.Clear();
                                    Inventory.instance.slot_Table[j].item.necklace_Item_Datas.Clear();
                                    Inventory.instance.slot_Table[j].item.consumable_Item_Datas.Clear();
                                    Inventory.instance.slot_Table[j].item.other_Quest_Item_Datas.Clear();
                                    Inventory.instance.ItemImageChange(Inventory.instance.slot_Table[j]);
                                }
                                else
                                {
                                    Inventory.instance.slot_Table[j].ItemCount -= QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].clearItemNumber;
                                    Inventory.instance.slot_Table[j].ItemCountText.text = Inventory.instance.slot_Table[j].ItemCount.ToString();
                                    ItemDatabase.instance.other_quests[(int)Inventory.instance.slot_Table[j].DropItemNumber].item_Count -= QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].clearItemNumber;
                                    Inventory.instance.ItemImageChange(Inventory.instance.slot_Table[j]);
                                }
                            }
                            // 보상 아이템
                            Inventory.instance.AddItem(QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].ClearType, QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].ClearItem, 1);
                            QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].clearS = true;
                            sign.questAni.SetBool("Clear", QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].clearS);
                            sign.ActivateLayer(Sign.StateLayers.State);
                            if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][QuestDatabase.instance.questlocalizedDatas[gameObject.name].Count - 2].clearS == true)
                            {
                                DataManager.instance.QuestClearNpc(gameObject.name);
                                sign.ActivateLayer(Sign.StateLayers.Thank);
                                StartCoroutine(sign.PlaceNameCo(sign.key + " 는(은) 행복하다.!!!!\n"));
                                sign.questAni.SetBool("Clear", false);
                                sign.questAni.SetBool("Happy", QuestDatabase.instance.questlocalizedDatas[gameObject.name][QuestDatabase.instance.questlocalizedDatas[gameObject.name].Count - 1].clearS);
                                QuestDatabase.instance.questlocalizedDatas[gameObject.name][QuestDatabase.instance.questlocalizedDatas[gameObject.name].Count - 1].clearS = true;
                                QuestDatabase.instance.questlocalizedDatas[gameObject.name][QuestDatabase.instance.questlocalizedDatas[gameObject.name].Count - 1].npcDataSwitch = true;
                            }
                            break;
                        }

                }
            }
        }
    }
    // 저장된 퀘스트 목록 불러오기용.
    public void questSetup()
    {
        GameObject test = Instantiate(test1);
        test.transform.SetParent(test2);
        test.gameObject.name = gameObject.name;
        test.gameObject.transform.localScale = new Vector3(1, 1, 1);
        test.GetComponent<QuestInfoMenu>().npcdataImage = test.transform.GetChild(0).GetComponent<Image>();
        test.GetComponent<QuestInfoMenu>().questNpcName = test.transform.GetChild(1).GetComponent<Text>();
        test.GetComponent<QuestInfoMenu>().questinfoNames = texts[0];
        test.GetComponent<QuestInfoMenu>().questContents = texts[1];
        test.GetComponent<QuestInfoMenu>().quesTions = texts[2];
        test.GetComponent<QuestInfoMenu>().questLocalizedName = QuestDatabase.instance.questlocalizedDatas[gameObject.name];
        test.GetComponent<QuestInfoMenu>().questNpcName.text = LocalizationManager.instance.GetLocalizedValue2(sign.key);
        test.GetComponent<QuestInfoMenu>().npcdataImage.sprite = Resources.Load<Sprite>("NpcFace/" + gameObject.name);
    }
}
