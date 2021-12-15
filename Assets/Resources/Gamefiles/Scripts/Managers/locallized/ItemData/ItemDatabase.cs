using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;
using System;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public List<weapon_Item_Data> weapons;
    public List<shield_Item_Data> shields;
    public List<helmat_Item_Data> helmats;
    public List<armor_Item_Data> armors;
    public List<gloves_Item_Data> gloves;
    public List<shoes_Item_Data> shoeses;
    public List<necklace_Item_Data> necklaces;
    public List<ring_Item_Data> rings;
    public List<Consumable_Item_Data> consumables;
    public List<Other_Quest_Item_Data> other_quests;
    void Awake()
    {
        instance = this;
    }
    // 로컬라이징(파일명)
    public void LoadLocalizedItem(string fileName)
    {
        weapons = new List<weapon_Item_Data>();
        shields = new List<shield_Item_Data>();
        helmats = new List<helmat_Item_Data>();
        armors = new List<armor_Item_Data>();
        gloves = new List<gloves_Item_Data>();
        shoeses = new List<shoes_Item_Data>();
        necklaces = new List<necklace_Item_Data>();
        rings = new List<ring_Item_Data>();
        consumables = new List<Consumable_Item_Data>();
        other_quests = new List<Other_Quest_Item_Data>();
        // **두가지를 초기화 시켜주지 않으면 로컬라이징씨 불러올때 값이 중복되어 오류나 겹치는등이 생길 수 있음.**
        // 크로스플랫폼에서 언제든 불러와 쓸 수 있도록 고정로컬경로인 Resources폴더에 파일을 불러와 TextAsset으로 선언과 동시에 할당.
        TextAsset filePath = Resources.Load<TextAsset>("Language/" + fileName);
        // Debug.Log(filePath); // 정상적으로 불러오나 테스트.
        if (filePath != null) // filePath가 null이 아니라면 로컬라이징 파일 찾기 시작.
        {
            // 불러온 json파일을 텍스트화 해서 string에 할당.
            string dataAsJson = filePath.text;
            // json 문자열을 object화 하여 loadeData에 담음
            LocalizationItemData loadedData = JsonConvert.DeserializeObject<LocalizationItemData>(dataAsJson);
            // loadedData.LocalTypes 크기만큼 loop.
            for (int i = 0; i < loadedData.weapon_Item_Datas.Count; i++)
            {
                weapons.Add(new weapon_Item_Data(loadedData.weapon_Item_Datas[i].Effect,
                    loadedData.weapon_Item_Datas[i].info,
                            loadedData.weapon_Item_Datas[i].isEquip,
                            loadedData.weapon_Item_Datas[i].itemClass,
                            loadedData.weapon_Item_Datas[i].item_Numbers,
                            loadedData.weapon_Item_Datas[i].item_Name,
                            loadedData.weapon_Item_Datas[i].holy_Power,
                            loadedData.weapon_Item_Datas[i].neutrality_Power,
                            loadedData.weapon_Item_Datas[i].heresy_Power,
                            loadedData.weapon_Item_Datas[i].damage,
                            loadedData.weapon_Item_Datas[i].attack_Speed,
                            loadedData.weapon_Item_Datas[i].attack_Range,
                            loadedData.weapon_Item_Datas[i].item_Count,
                            loadedData.weapon_Item_Datas[i].item_Price,
                            loadedData.weapon_Item_Datas[i].item_Ex));
            }
            for (int i = 0; i < loadedData.shield_Item_Datas.Count; i++)
            {
                shields.Add(new shield_Item_Data(loadedData.shield_Item_Datas[i].Effect,
                    loadedData.shield_Item_Datas[i].info,
                            loadedData.shield_Item_Datas[i].isEquip,
                            loadedData.shield_Item_Datas[i].itemClass,
                            loadedData.shield_Item_Datas[i].item_Numbers,
                            loadedData.shield_Item_Datas[i].item_Name,
                            loadedData.shield_Item_Datas[i].holy_Power,
                            loadedData.shield_Item_Datas[i].neutrality_Power,
                            loadedData.shield_Item_Datas[i].heresy_Power,
                            loadedData.shield_Item_Datas[i].stance,
                            loadedData.shield_Item_Datas[i].push_Stance,
                            loadedData.shield_Item_Datas[i].stiffen_Stance,
                            loadedData.shield_Item_Datas[i].item_Count,
                            loadedData.shield_Item_Datas[i].item_Price,
                            loadedData.shield_Item_Datas[i].item_Ex));
            }
            for (int i = 0; i < loadedData.helmat_Item_Datas.Count; i++)
            {
                helmats.Add(new helmat_Item_Data(loadedData.helmat_Item_Datas[i].Effect,
                    loadedData.helmat_Item_Datas[i].info,
                            loadedData.helmat_Item_Datas[i].isEquip,
                            loadedData.helmat_Item_Datas[i].itemClass,
                            loadedData.helmat_Item_Datas[i].item_Numbers,
                            loadedData.helmat_Item_Datas[i].item_Name,
                            loadedData.helmat_Item_Datas[i].holy_Power,
                            loadedData.helmat_Item_Datas[i].neutrality_Power,
                            loadedData.helmat_Item_Datas[i].heresy_Power,
                            loadedData.helmat_Item_Datas[i].stance,
                            loadedData.helmat_Item_Datas[i].stiffen_Stance,
                            loadedData.helmat_Item_Datas[i].item_Count,
                            loadedData.helmat_Item_Datas[i].item_Price,
                            loadedData.helmat_Item_Datas[i].item_Ex));
            }

            for (int i = 0; i < loadedData.armor_Item_Datas.Count; i++)
            {
                armors.Add(new armor_Item_Data(loadedData.armor_Item_Datas[i].Effect,
                    loadedData.armor_Item_Datas[i].info,
                            loadedData.armor_Item_Datas[i].isEquip,
                            loadedData.armor_Item_Datas[i].itemClass,
                            loadedData.armor_Item_Datas[i].item_Numbers,
                            loadedData.armor_Item_Datas[i].item_Name,
                            loadedData.armor_Item_Datas[i].holy_Power,
                            loadedData.armor_Item_Datas[i].neutrality_Power,
                            loadedData.armor_Item_Datas[i].heresy_Power,
                            loadedData.armor_Item_Datas[i].Player_numOFHeart,
                            loadedData.armor_Item_Datas[i].stance,
                            loadedData.armor_Item_Datas[i].stiffen_Stance,
                            loadedData.armor_Item_Datas[i].phoenix_Stance,
                            loadedData.armor_Item_Datas[i].item_Count,
                            loadedData.armor_Item_Datas[i].item_Price,
                            loadedData.armor_Item_Datas[i].item_Ex));
            }
            for (int i = 0; i < loadedData.gloves_Item_Datas.Count; i++)
            {
                gloves.Add(new gloves_Item_Data(loadedData.gloves_Item_Datas[i].Effect,
                    loadedData.gloves_Item_Datas[i].info,
                            loadedData.gloves_Item_Datas[i].isEquip,
                            loadedData.gloves_Item_Datas[i].itemClass,
                            loadedData.gloves_Item_Datas[i].item_Numbers,
                            loadedData.gloves_Item_Datas[i].item_Name,
                            loadedData.gloves_Item_Datas[i].holy_Power,
                            loadedData.gloves_Item_Datas[i].neutrality_Power,
                            loadedData.gloves_Item_Datas[i].heresy_Power,
                            loadedData.gloves_Item_Datas[i].damage,
                            loadedData.gloves_Item_Datas[i].attack_Speed,
                            loadedData.gloves_Item_Datas[i].item_Count,
                            loadedData.gloves_Item_Datas[i].item_Price,
                            loadedData.gloves_Item_Datas[i].item_Ex));
            }
            for (int i = 0; i < loadedData.shoes_Item_Datas.Count; i++)
            {
                shoeses.Add(new shoes_Item_Data(loadedData.shoes_Item_Datas[i].Effect,
                    loadedData.shoes_Item_Datas[i].info,
                            loadedData.shoes_Item_Datas[i].isEquip,
                            loadedData.shoes_Item_Datas[i].itemClass,
                            loadedData.shoes_Item_Datas[i].item_Numbers,
                            loadedData.shoes_Item_Datas[i].item_Name,
                            loadedData.shoes_Item_Datas[i].holy_Power,
                            loadedData.shoes_Item_Datas[i].neutrality_Power,
                            loadedData.shoes_Item_Datas[i].heresy_Power,
                            loadedData.shoes_Item_Datas[i].eq_Speed,
                            loadedData.shoes_Item_Datas[i].move_Slow,
                            loadedData.shoes_Item_Datas[i].item_Count,
                            loadedData.shoes_Item_Datas[i].item_Price,
                            loadedData.shoes_Item_Datas[i].item_Ex));
            }
            for (int i = 0; i < loadedData.necklace_Item_Datas.Count; i++)
            {
                necklaces.Add(new necklace_Item_Data(loadedData.necklace_Item_Datas[i].info,
                                loadedData.necklace_Item_Datas[i].isEquip,
                                loadedData.necklace_Item_Datas[i].itemClass,
                                loadedData.necklace_Item_Datas[i].item_Numbers,
                                loadedData.necklace_Item_Datas[i].item_Name,
                                loadedData.necklace_Item_Datas[i].holy_Power,
                                loadedData.necklace_Item_Datas[i].neutrality_Power,
                                loadedData.necklace_Item_Datas[i].heresy_Power,
                                loadedData.necklace_Item_Datas[i].damage,
                                loadedData.necklace_Item_Datas[i].attack_Vampire,
                                loadedData.necklace_Item_Datas[i].heart_Recovery_Time,
                                loadedData.necklace_Item_Datas[i].heart_Stance,
                                loadedData.necklace_Item_Datas[i].item_Count,
                                loadedData.necklace_Item_Datas[i].item_Price,
                                loadedData.necklace_Item_Datas[i].item_Ex));
            }
            for (int i = 0; i < loadedData.ring_Item_Datas.Count; i++)
            {
                rings.Add(new ring_Item_Data(loadedData.ring_Item_Datas[i].info,
                            loadedData.ring_Item_Datas[i].isEquip,
                            loadedData.ring_Item_Datas[i].itemClass,
                            loadedData.ring_Item_Datas[i].item_Numbers,
                            loadedData.ring_Item_Datas[i].item_Name,
                            loadedData.ring_Item_Datas[i].holy_Power,
                            loadedData.ring_Item_Datas[i].neutrality_Power,
                            loadedData.ring_Item_Datas[i].heresy_Power,
                            loadedData.ring_Item_Datas[i].damage,
                            loadedData.ring_Item_Datas[i].attack_Vampire,
                            loadedData.ring_Item_Datas[i].heart_Recovery_Time,
                            loadedData.ring_Item_Datas[i].heart_Stance,
                            loadedData.ring_Item_Datas[i].item_Count,
                            loadedData.ring_Item_Datas[i].item_Price,
                            loadedData.ring_Item_Datas[i].item_Ex));
            }
            for (int i = 0; i < loadedData.consumable_Item_Datas.Count; i++)
            {
                consumables.Add(new Consumable_Item_Data(loadedData.consumable_Item_Datas[i].info,
                                loadedData.consumable_Item_Datas[i].isConsumable,
                                loadedData.consumable_Item_Datas[i].itemClass,
                                loadedData.consumable_Item_Datas[i].item_Numbers,
                                loadedData.consumable_Item_Datas[i].item_Name,
                                loadedData.consumable_Item_Datas[i].holy_Power,
                                loadedData.consumable_Item_Datas[i].neutrality_Power,
                                loadedData.consumable_Item_Datas[i].holy_Power,
                                loadedData.consumable_Item_Datas[i].damage,
                                loadedData.consumable_Item_Datas[i].attack_Speed,
                                loadedData.consumable_Item_Datas[i].attack_Vampire,
                                loadedData.consumable_Item_Datas[i].heart_Stance,
                                loadedData.consumable_Item_Datas[i].heart_Recovery_Time,
                                loadedData.consumable_Item_Datas[i].stance,
                                loadedData.consumable_Item_Datas[i].push_Stance,
                                loadedData.consumable_Item_Datas[i].phoenix_Stance,
                                loadedData.consumable_Item_Datas[i].stiffen_Stance,
                                loadedData.consumable_Item_Datas[i].move_Slow,
                                loadedData.consumable_Item_Datas[i].eq_Speed,
                                loadedData.consumable_Item_Datas[i].hpmax_Potion,
                                loadedData.consumable_Item_Datas[i].item_Count,
                                loadedData.consumable_Item_Datas[i].item_Price,
                                loadedData.consumable_Item_Datas[i].item_Ex));
            }
            for (int i = 0; i < loadedData.other_Quest_Item_Datas.Count; i++)
            {
                other_quests.Add(new Other_Quest_Item_Data(loadedData.other_Quest_Item_Datas[i].info,
                                loadedData.other_Quest_Item_Datas[i].isConsumable,
                                loadedData.other_Quest_Item_Datas[i].itemClass,
                                loadedData.other_Quest_Item_Datas[i].isEquip,
                                loadedData.other_Quest_Item_Datas[i].item_Numbers,
                                loadedData.other_Quest_Item_Datas[i].item_Name,
                                loadedData.other_Quest_Item_Datas[i].item_style,
                                loadedData.other_Quest_Item_Datas[i].item_Count,
                                loadedData.other_Quest_Item_Datas[i].item_Price,
                                loadedData.other_Quest_Item_Datas[i].item_Ex));
            }
            //현재 불러온 언어를 저장하기 위한 변수. 그리고 공백일시 체크를 위해.
            GameManager.instance.itemlang = fileName;
            // 로드가 정상적으로 되었고 몇개나 할당되었나 확인하기 위한 디버그.
        }
    }
    /*     void weapon_Item(info _info, bool _isEquip, int _item_Numbers, string _item_Name, int _holy_Power, int _neutrality_Power, int _heresy_Power, int _damage, float _attack_Speed, Vector2 _attack_Range, int _item_Price, string _item_Ex, Sprite _image)
        {
            //weapons.Add(new weapon_Item_Data(_info, _isEquip, _item_Numbers, _item_Name, _holy_Power, _neutrality_Power, _heresy_Power, _damage, _attack_Speed, _attack_Range, _item_Price, _item_Ex)));
        } */
}
