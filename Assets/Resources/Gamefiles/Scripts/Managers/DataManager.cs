using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;

//인벤토리 집합체.
class inventoryData
{
    public info type;
    public int ItemNumber;
    public int ItemCount;
    public inventoryData(info _type, int _ItemNumber, int _ItemCount)
    {
        type = _type;
        ItemNumber = _ItemNumber;
        ItemCount = _ItemCount;
    }
}
[Serializable]
class playerInfo
{
    public float Player_Heart; // 플레이어 체력
    public float Player_numOFHeart; // 플레어이 맥스체력.
    public float speed; // 이동속도
    public float damage; // 데미지
    public float attack_Speed; // 공격 속도
    public Vector2 attack_Range; // 공격 범위
    public float holy_Power; // 신성한 힘
    public float neutrality_Power; // 중립적인 힘
    public float heresy_Power; // 타락한 힘
    public float attack_Vampire; // 체력 생성 확률
    public float heart_Stance; // 체력 소모 반감 (스킬 사용시)
    public float heart_Recovery_Time; // 체력 재생 시간 단축
    public float stance; // 회피율
    public float push_Stance; // 슈퍼 아머 (밀격 면역)
    public float phoenix_Stance; // 죽음 면역
    public float stiffen_Stance; // 스턴 면역
    public float move_Slow; // 이동속도 감소 면역

    public string PlayerThisWorld;
    public float X;    // 플레이어 좌표.X
    public float Y;   // 플레이어 좌표.Y
    public float Z;    // 플레이어 좌표.Z
    public Vector2 mincameraChange; // 카메라 고정 위치.
    public Vector2 maxcameraChange; // 카메라 고정 값 위치.
    public string langGuage;
    public string itemlangGuage;

    public List<LocalizationItemData> playerInventorys;
    // 인벤토리 관련.
    public inventoryData[] dada = new inventoryData[54];
    public LocalizationItemData equips;
    public int[] equipsNumber = new int[9];
    //퀘스트 관련
    public Dictionary<string, List<QuestLocalizedContents>> questlocalizedDatas;
    public List<string> Npcname;
    // 퀘스트 아이템 관련
    public List<string> questItemDrops;
    public List<string> questClearNpc;
    // 오디오 관련메뉴
    public string startAudioName = "World";
    public float masterVolumeBGM;
    public float masterVolumeSFX;
    
    public playerInfo()
    {

    }
    public playerInfo(int player_heart, int player_numofheart, float x, float y, float z, Vector2 mincamerachange, Vector2 maxcamerachange, string language)
    {
        this.Player_Heart = player_heart;
        this.Player_numOFHeart = player_numofheart;
        this.X = x;
        this.Y = y;
        this.Z = z;
        this.mincameraChange = mincamerachange;
        this.maxcameraChange = maxcamerachange;
        this.langGuage = language;
    }
    // 생성자에 대해 알아봐야함. 좀 더 심도 싶게 더 좋은 생성자를 위해.

    public bool ring1;
    public bool ring2;

    // 플레이어 타임
    public int inGameTime;
    public float[] lightInfo = new float[7];

    public int mainTime;
    public int subTime;
}
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [SerializeField]
    playerInfo playerdata = new playerInfo();
    [SerializeField]
    Players players;
    [SerializeField]
    CameraMovement cam;
    // 데이터 처리를위해 캐릭터로 접근해야 할듯 싶다.
    // 그리고 private 형식으로 데이터매니저에 해야할듯 싶다.
    [SerializeField]
    GameObject[] MapObjWorld;
    [SerializeField]
    EquipmentCheck equipmentCheck;
    float _healthMax = 5 - 0.0331f; //맥스 체력
    float _health = 5 - 0.0331f;    //현재 체력
    float _speed = 4 + 0.0331f;   //이동 속도
    float _damage = 1 + 0.0331f;  //데미지
    float _attack_Speed = 1f + 0.0331f; // 공격속도
    attackType _attack_Range = attackType.무방비; // 공격 방식
    float _holy_Power = 0f + 0.0331f; // 신성
    float _neutrality_Power = 0f + 0.0331f; // 중립
    float _heresy_Power = 0f + 0.0331f; // 타락
    float _attack_Vampire = 0f + 0.0331f; // 체력 생성 확률
    float _heart_Stance = 0f + 0.0331f; // 체력 소모 반감 (스킬 사용시)
    float _heart_Recovery_Time = 20f + 0.0331f; // 체력 재생 시간 단축
    float _stance = 0f + 0.0331f; // 회피율
    float _push_Stance = 0f + 0.0331f; // 슈퍼아머 밀격 면역
    float _phoenix_Stance = 0f + 0.0331f; // 죽음 면역
    float _stiffen_Stance = 0f + 0.0331f; // 스턴 면역
    float _move_Slow = 0f + 0.0331f; // 이동속도 감소 면역
                                     // 데이터종류.
                                     // 맵엔피시 종류
    public bool worldmapNpc;
    public RoomMove roomMove;
    public LightNight lightNight;

    // 맥스 체력
    public float healthMax
    {
        get
        {
            if (_healthMax > 20 && players.transform) // 맥스 체력한계점 그외에 세트효과에 기반도 해야함.
            {
                _healthMax = 20;
            }
            return _healthMax + equipmentCheck.armorSlot.ArmorEquip.Player_numOFHeart;
        }
    }
    // 현재 체력
    public float health
    {
        get { return Mathf.Min(_health, healthMax); }
        set { _health = Mathf.Clamp(value, 0, healthMax); }
    }
    // 데미지
    public float damage
    {
        get
        {
            return _damage + equipmentCheck.weaponSlot.weaponEquip.damage +
            equipmentCheck.glovesSlot.glovesEquip.damage +
            equipmentCheck.ringsSlots.ringsEquip.damage +
            equipmentCheck.ringsSlots2.ringsEquip.damage +
            equipmentCheck.necklaceSlot.necklaceEquip.damage;
        }
    }
    // 스피드
    public float speed
    {
        get
        {
            return _speed + equipmentCheck.shoeseSlot.shoesEquip.eq_Speed;
        }
    }
    // 공격 속도
    public float attack_Speed
    {
        get
        {
            if (Equipment.instance.item.weapon_Item_Datas.Count != 0)
            {
                return (_attack_Speed + equipmentCheck.weaponSlot.weaponEquip.attack_Speed) - 0.7f;
            }
            else if (Equipment.instance.item.gloves_Item_Datas.Count != 0)
            {
                return (_attack_Speed - equipmentCheck.glovesSlot.glovesEquip.attack_Speed) + 0.6f;
            }
            else
            {
                return _attack_Speed + equipmentCheck.weaponSlot.weaponEquip.attack_Speed - equipmentCheck.glovesSlot.glovesEquip.attack_Speed;
            }
        }
    }
    // 공격 범위
    public attackType attack_Range
    {
        get
        {
            if (Equipment.instance.item.weapon_Item_Datas.Count != 0)
                return equipmentCheck.weaponSlot.weaponEquip.attack_Range;
            else
                return _attack_Range;
        }
    }
    // 신성한 힘
    public float holy_Power
    {
        get
        {
            return _holy_Power +
            equipmentCheck.armorSlot.ArmorEquip.holy_Power +
            equipmentCheck.helmatSlot.helmatEquip.holy_Power +
            equipmentCheck.weaponSlot.weaponEquip.holy_Power +
            equipmentCheck.shieldSlot.shieldEquip.holy_Power +
            equipmentCheck.glovesSlot.glovesEquip.holy_Power +
            equipmentCheck.shoeseSlot.shoesEquip.holy_Power +
            equipmentCheck.ringsSlots.ringsEquip.holy_Power +
            equipmentCheck.ringsSlots2.ringsEquip.holy_Power +
            equipmentCheck.necklaceSlot.necklaceEquip.holy_Power;
        }
    }
    // 중립성 힘
    public float neutrality_Power
    {
        get
        {
            return _neutrality_Power +
            equipmentCheck.armorSlot.ArmorEquip.neutrality_Power +
            equipmentCheck.helmatSlot.helmatEquip.neutrality_Power +
            equipmentCheck.weaponSlot.weaponEquip.neutrality_Power +
            equipmentCheck.shieldSlot.shieldEquip.neutrality_Power +
            equipmentCheck.glovesSlot.glovesEquip.neutrality_Power +
            equipmentCheck.shoeseSlot.shoesEquip.neutrality_Power +
            equipmentCheck.ringsSlots.ringsEquip.neutrality_Power +
            equipmentCheck.ringsSlots2.ringsEquip.neutrality_Power +
            equipmentCheck.necklaceSlot.necklaceEquip.neutrality_Power;
        }
    }
    // 타락한 힘
    public float heresy_Power
    {
        get
        {
            return _heresy_Power +
            equipmentCheck.armorSlot.ArmorEquip.heresy_Power +
            equipmentCheck.helmatSlot.helmatEquip.heresy_Power +
            equipmentCheck.weaponSlot.weaponEquip.heresy_Power +
            equipmentCheck.shieldSlot.shieldEquip.heresy_Power +
            equipmentCheck.glovesSlot.glovesEquip.heresy_Power +
            equipmentCheck.shoeseSlot.shoesEquip.heresy_Power +
            equipmentCheck.ringsSlots.ringsEquip.heresy_Power +
            equipmentCheck.ringsSlots2.ringsEquip.heresy_Power +
            equipmentCheck.necklaceSlot.necklaceEquip.heresy_Power;
        }
    }
    // 체력 생성 확률
    public float attack_Vampire
    {
        get
        {
            return _attack_Vampire +
            equipmentCheck.ringsSlots.ringsEquip.attack_Vampire +
            equipmentCheck.ringsSlots2.ringsEquip.attack_Vampire +
            equipmentCheck.necklaceSlot.necklaceEquip.attack_Vampire;
        }
    }
    // 체력 소모 반감 확률
    public float heart_Stance
    {
        get
        {
            return _heart_Stance +
            equipmentCheck.ringsSlots.ringsEquip.heart_Stance +
            equipmentCheck.ringsSlots2.ringsEquip.heart_Stance +
            equipmentCheck.necklaceSlot.necklaceEquip.heart_Stance;
        }
    }
    // 체력 재생 시간 단축
    public float heart_Recovery_Time
    {
        get
        {
            return _heart_Recovery_Time -
            equipmentCheck.ringsSlots.ringsEquip.heart_Recovery_Time -
            equipmentCheck.ringsSlots2.ringsEquip.heart_Recovery_Time -
            equipmentCheck.necklaceSlot.necklaceEquip.heart_Recovery_Time;
        }
    }
    // 회피율
    public float stance
    {
        get
        {
            return _stance +
            equipmentCheck.helmatSlot.helmatEquip.stance +
            equipmentCheck.armorSlot.ArmorEquip.stance +
            equipmentCheck.shieldSlot.shieldEquip.stance;
        }
    }
    // 슈퍼아머
    public float push_Stance
    {
        get
        {
            return _push_Stance + equipmentCheck.shieldSlot.shieldEquip.push_Stance;
        }
    }
    // 죽음 면역
    public float phoenix_Stance
    {
        get
        {
            return _phoenix_Stance + equipmentCheck.armorSlot.ArmorEquip.phoenix_Stance;
        }
    }
    // 스턴 먼역
    public float stiffen_Stance
    {
        get
        {
            return _stiffen_Stance +
            equipmentCheck.helmatSlot.helmatEquip.stiffen_Stance +
            equipmentCheck.armorSlot.ArmorEquip.stiffen_Stance +
            equipmentCheck.shieldSlot.shieldEquip.stiffen_Stance;
        }
    }
    //이동 속도 감소 면역
    public float move_Slow
    {
        get
        {
            return _move_Slow + equipmentCheck.shoeseSlot.shoesEquip.move_Slow;
        }
    }

    // 퀘스트 아이템 제거
    public void dropQuestItem(string name)
    {
        playerdata.questItemDrops.Add(name);
    }
    // 퀘스트 완료 엔피시 저장
    public void QuestClearNpc(string name)
    {
        playerdata.questClearNpc.Add(name);
    }
    // 플레이어 위치
    public void ThisMap(string name)
    {
        playerdata.PlayerThisWorld = name;
    }
    ///////////////////////
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        QuestDatabase.instance.LoadLocalizedQuest("quest");
    }
    private void ThisWorldMap(string name)
    {
        switch(name)
        {
            case "HaresMap":
                MapObjWorld[0].SetActive(true);
                break;
            case "HaresHouseIn":
                MapObjWorld[1].SetActive(true);
                break;
            case "WorldMap":
                MapObjWorld[2].SetActive(true);
                break;
        }
    }
    public void _save()
    {
        //세이브 데이터구간 */
        playerdata.Player_numOFHeart = healthMax;
        playerdata.Player_Heart = health;
        playerdata.damage = damage;
        playerdata.speed = speed;
        playerdata.X = players.transform.position.x;
        playerdata.Y = players.transform.position.y;
        playerdata.Z = players.transform.position.z;
        playerdata.mincameraChange = cam.minPosition;
        playerdata.maxcameraChange = cam.maxPosition;
        playerdata.masterVolumeBGM = SoundManagers.instance.masterVolumeBGM.value;
        playerdata.masterVolumeSFX = SoundManagers.instance.masterVolumeSFX.value;
        playerdata.startAudioName = SoundManagers.instance.startsoundName;
        playerdata.langGuage = GameManager.instance.islang;
        playerdata.itemlangGuage = GameManager.instance.itemlang;
        playerdata.equips = Equipment.instance.item;
        playerdata.ring1 = equipmentCheck.ringsSlots.ring1S;
        playerdata.ring2 = equipmentCheck.ringsSlots.ring2S;
        playerdata.playerInventorys.Clear();
        // 퀘스트
        playerdata.questlocalizedDatas = QuestDatabase.instance.questlocalizedDatas;
        playerdata.Npcname = QuestDatabase.instance.npcName;

        // 인벤토리
        for (int i = 0; i < Inventory.instance.slot_Table.Count; i++)
        {
            playerdata.dada[i] = new inventoryData(Inventory.instance.slot_Table[i].info, (int)Inventory.instance.slot_Table[i].DropItemNumber, Inventory.instance.slot_Table[i].ItemCount);
        }
        // 현재 맵 시간
        playerdata.inGameTime = lightNight.time;
        playerdata.lightInfo[0] = lightNight.lights.intensity;
        playerdata.lightInfo[1] = lightNight.R;
        playerdata.lightInfo[2] = lightNight.G;
        playerdata.lightInfo[3] = lightNight.B;
        playerdata.lightInfo[4] = lightNight.itemLight.range;
        playerdata.lightInfo[5] = lightNight.itemLight.intensity;
        playerdata.mainTime = lightNight.min;
        playerdata.subTime = lightNight.subtime;
        // 플레이어 맵위치
        //데이터구간 */

        //데이터를 json 문자열로 만든다.
        string jdata = JsonConvert.SerializeObject(playerdata);

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        string format = System.Convert.ToBase64String(bytes);
        File.WriteAllText(Application.persistentDataPath + "/unityjhong.json", format);
    }

    public void _load()
    {
        GameManager.instance.itemLoadMesage = true;
        //json 데이터파일을 읽어드려 string으로 변환한다.
        string jdata = File.ReadAllText(Application.persistentDataPath + "/unityjhong.json");
        byte[] bytes = System.Convert.FromBase64String(jdata);
        string reformat = System.Text.Encoding.UTF8.GetString(bytes);
        playerdata = JsonConvert.DeserializeObject<playerInfo>(reformat);
        //로드 데이터구간 */
        if (GameManager.instance.islang == "")
        {
            // 공백이면 불러온 데이터에 저장된 언어 실행.
            LocalizationManager.instance.LoadLocalizedText(playerdata.langGuage);
        }
        else
        {
            // 공백이 아닐경우 지정된 언어 실행.
            LocalizationManager.instance.LoadLocalizedText(GameManager.instance.islang);
        }
        // 공백체크.
        if (GameManager.instance.itemlang == "")
        {
            // 공백이면 불러온 데이터에 저장된 언어 실행.
            ItemDatabase.instance.LoadLocalizedItem(playerdata.itemlangGuage);
        }
        else
        {
            // 공백이 아닐경우 지정된 언어 실행.
            ItemDatabase.instance.LoadLocalizedItem(GameManager.instance.itemlang);
        }
        // 공백체크.
        //데이터구간 */

        for (int i = 0; i < playerdata.dada.Length; i++)
        {
            Inventory.instance.AddItem(playerdata.dada[i].type, playerdata.dada[i].ItemNumber, playerdata.dada[i].ItemCount);
        }
        for (int i = 0; i < Inventory.instance.slot_Table.Count; i++)
        {
            if (Inventory.instance.slot_Table[i].info == info.Default)
                Inventory.instance.slot_Table[i].checkItem = false;
        }
        equipmentCheck.ringsSlots.ring1S = playerdata.ring1;
        equipmentCheck.ringsSlots.ring2S = playerdata.ring2;

        Equipment.instance.item = playerdata.equips;
        if (Equipment.instance.item.helmat_Item_Datas.Count != 0)
            equipmentCheck.EquipMentLoad(info.HELMATS);
        if (Equipment.instance.item.armor_Item_Datas.Count != 0)
            equipmentCheck.EquipMentLoad(info.ARMORS);
        if (Equipment.instance.item.gloves_Item_Datas.Count != 0)
            equipmentCheck.EquipMentLoad(info.GLOVES);
        if (Equipment.instance.item.necklace_Item_Datas.Count != 0)
            equipmentCheck.EquipMentLoad(info.NECKLACES);
        if (Equipment.instance.item.ring_Item_Datas.Count != 0)
        {
            equipmentCheck.EquipMentLoad(info.RINGS);
            if (Equipment.instance.item.ring_Item_Datas.Count == 2)
            {
                equipmentCheck.EquipMentLoad(info.RINGS);
            }
        }
        if (Equipment.instance.item.weapon_Item_Datas.Count != 0)
            equipmentCheck.EquipMentLoad(info.WEAPONS);
        if (Equipment.instance.item.shoes_Item_Datas.Count != 0)
            equipmentCheck.EquipMentLoad(info.SHOES);
        if (Equipment.instance.item.shield_Item_Datas.Count != 0)
            equipmentCheck.EquipMentLoad(info.SHIELDS);
        health = playerdata.Player_Heart;
        players.transform.position = new Vector3(playerdata.X, playerdata.Y, playerdata.Z);
        ThisWorldMap(playerdata.PlayerThisWorld);
        cam.maxPosition = playerdata.maxcameraChange;
        cam.minPosition = playerdata.mincameraChange;
        SoundManagers.instance.masterVolumeBGM.value = playerdata.masterVolumeSFX;
        SoundManagers.instance.masterVolumeSFX.value = playerdata.masterVolumeBGM;
        SoundManagers.instance.MapBGM(playerdata.startAudioName);
        //퀘스트 관련.
        QuestDatabase.instance.npcName = playerdata.Npcname;
        QuestDatabase.instance.questlocalizedDatas = playerdata.questlocalizedDatas;
        QuestDatabase.instance.AddQuest();
        // 퀘스트 완료된점.

        //퀘스트 아이템 제거
        for (int i = 0; i < playerdata.questItemDrops.Count; i++)
        {
            Destroy(GameObject.Find(playerdata.questItemDrops[i]));
        }
        //Npc 상태 불러오기.
        for (int i = 0; i < playerdata.Npcname.Count; i++)
        {
            for (int j = 0; j < QuestDatabase.instance.questlocalizedDatas[playerdata.Npcname[i]].Count; j++)
            {
                if (QuestDatabase.instance.questlocalizedDatas[playerdata.Npcname[i]][j].npcDataSwitch == true && QuestDatabase.instance.questlocalizedDatas[playerdata.Npcname[i]][j].clearS == false)
                {
                    GameObject.Find(playerdata.Npcname[i]).GetComponent<Sign>().ActivateLayer(Sign.StateLayers.Qna);
                    break;
                }
                else if (QuestDatabase.instance.questlocalizedDatas[playerdata.Npcname[i]][j].npcDataSwitch == false && QuestDatabase.instance.questlocalizedDatas[playerdata.Npcname[i]][j].clearS == false)
                {
                    GameObject.Find(playerdata.Npcname[i]).GetComponent<Sign>().ActivateLayer(Sign.StateLayers.State);
                    break;
                }
                else
                {
                    GameObject.Find(playerdata.Npcname[i]).GetComponent<Sign>().ActivateLayer(Sign.StateLayers.State);
                }
            }
        }
        for (int i = 0; i < playerdata.questClearNpc.Count; i++)
        {
            GameObject.Find(playerdata.questClearNpc[i]).GetComponent<Sign>().ActivateLayer(Sign.StateLayers.Thank);
        }

        // 현재 맵 시간
        lightNight.time = playerdata.inGameTime;
        lightNight.lights.intensity = playerdata.lightInfo[0];
        lightNight.R = playerdata.lightInfo[1];
        lightNight.G = playerdata.lightInfo[2];
        lightNight.B = playerdata.lightInfo[3];
        lightNight.itemLight.range = playerdata.lightInfo[4];
        lightNight.itemLight.intensity = playerdata.lightInfo[5];
        lightNight.min = playerdata.mainTime;
        lightNight.subtime = playerdata.subTime;
    }

    public void npcState()
    {
        for (int i = 0; i < playerdata.Npcname.Count; i++)
        {
            for (int j = 0; j < QuestDatabase.instance.questlocalizedDatas[playerdata.Npcname[i]].Count; j++)
            {
                if (QuestDatabase.instance.questlocalizedDatas[playerdata.Npcname[i]][j].npcDataSwitch == true && QuestDatabase.instance.questlocalizedDatas[playerdata.Npcname[i]][j].clearS == false)
                {
                    GameObject.Find(playerdata.Npcname[i]).GetComponent<Sign>().ActivateLayer(Sign.StateLayers.Qna);
                    break;
                }
                else if (QuestDatabase.instance.questlocalizedDatas[playerdata.Npcname[i]][j].npcDataSwitch == false && QuestDatabase.instance.questlocalizedDatas[playerdata.Npcname[i]][j].clearS == false)
                {
                    GameObject.Find(playerdata.Npcname[i]).GetComponent<Sign>().ActivateLayer(Sign.StateLayers.State);
                    break;
                }
                else
                {
                    GameObject.Find(playerdata.Npcname[i]).GetComponent<Sign>().ActivateLayer(Sign.StateLayers.State);
                }
            }
        }
        for (int i = 0; i < playerdata.questClearNpc.Count; i++)
        {
            GameObject.Find(playerdata.questClearNpc[i]).GetComponent<Sign>().ActivateLayer(Sign.StateLayers.Thank);
        }
    }
    void OnApplicationQuit()
    {
        DataManager.instance._save();
    }
}
