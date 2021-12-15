using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;
using System;

public class LocalizationManager : MonoBehaviour
{
    // instace 선언 static으로 메모리에 정적(고정)할당됨.
    public static LocalizationManager instance;
    // 딕셔너리 type값.
    public Dictionary<string, Dictionary<string, List<string>>> localizedText;
    // 딕셔너리 type값의 key와 value값.
    private Dictionary<string, List<string>> typeName;
    private Dictionary<string, string> npcName;
    // 비어있을경우 대체 string
    private string missingTextString = "";
    public List<int> isd = new List<int>();
    void Awake()
    {
        // instance가  null 값과 같다면
        if (instance == null)
        {
            // 객체를 실체화하여 인스턴스화 한다.
            instance = this;
        }
        // instance가 자신과 다르다면 지운다.
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        // Scene이 넘어가도 파괴되지 않게 고정시킴.
        DontDestroyOnLoad(gameObject);
    }
    // 로컬라이징(파일명)
    public void LoadLocalizedText(string fileName)
    {
        // LocalizeText 컴포넌트가 있는 오브젝트를 찾아서 담음
        LocalizedText[] textin = FindObjectsOfType(typeof(LocalizedText)) as LocalizedText[];
        NpcName[] textname = FindObjectsOfType(typeof(NpcName)) as NpcName[];
        // 이하 동문.
        Sign[] sign = FindObjectsOfType(typeof(Sign)) as Sign[];
        // localizedText type 초기화 
        localizedText = new Dictionary<string, Dictionary<string, List<string>>>();
        typeName = new Dictionary<string, List<string>>();
        npcName = new Dictionary<string, string>();
        // **두가지를 초기화 시켜주지 않으면 로컬라이징씨 불러올때 값이 중복되어 오류나 겹치는등이 생길 수 있음.**
        // 크로스플랫폼에서 언제든 불러와 쓸 수 있도록 고정로컬경로인 Resources폴더에 파일을 불러와 TextAsset으로 선언과 동시에 할당.
        TextAsset filePath = Resources.Load<TextAsset>("Language/" + fileName);
        //Debug.Log(filePath); // 정상적으로 불러오나 테스트.
        if (filePath != null) // filePath가 null이 아니라면 로컬라이징 파일 찾기 시작.
        {
            // 불러온 json파일을 텍스트화 해서 string에 할당.
            string dataAsJson = filePath.text;
            // json 문자열을 object화 하여 loadeData에 담음
            LocalizationData loadedData = JsonConvert.DeserializeObject<LocalizationData>(dataAsJson);
            // loadedData.LocalTypes 크기만큼 loop.
            for (int i = 0; i < loadedData.LocalTypeName.Length; i++)
            {
                localizedText.Add(loadedData.LocalTypeName[i].type, typeName);
                // loadedData.LocalTypes.items 크기만큼 loop.
                for (int j = 0; j < loadedData.LocalTypeName[i].items.Length; j++)
                {
                    //Dictionary (key값,Dictionary값)
                    //Dictionary (key값, value값)
                    npcName.Add(loadedData.LocalTypeName[i].items[j].key, loadedData.LocalTypeName[i].items[j].key);
                    typeName.Add(loadedData.LocalTypeName[i].items[j].key, loadedData.LocalTypeName[i].items[j].value);
                    //종합 localizedText.Add(type, Dictionary(key, value))
                    isd.Add(loadedData.LocalTypeName[i].items[j].value.Count-1);
                }
            }
            foreach (LocalizedText text in textin)
            {
                for (int j = 0; j < textin.Length; j++)
                {
                    text.i = isd[j];
                }
                //onEnable()을함으로써 재 할당.
                text.OnEnable();
            }
            foreach (NpcName text in textname)
            {
                text.OnEnable();
            }
            foreach (Sign s in sign)
            {
                s.onEnable();
            }
            //현재 불러온 언어를 저장하기 위한 변수. 그리고 공백일시 체크를 위해.
            GameManager.instance.islang = fileName;
            // 로드가 정상적으로 되었고 몇개나 할당되었나 확인하기 위한 디버그.
           // Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + "entries");
        }
    }
    // 불러와 변경후 반환하기위한 함수
    public string GetLocalizedValue(string type, string key, int i)
    {
        // 결과값 선언
        string result = missingTextString;
        //localizedText의 Type 키값을 받아와 활성화 시킴.
        if (localizedText != null)
        {
            if (localizedText.ContainsKey(type) && typeName.ContainsKey(key))
            {
                // result에 해당하는 키값 할당.
                result = localizedText[type][key][i];
            }
        }

        return result;
    }
    public string GetLocalizedValue2(string key)
    {
        // 결과값 선언
        string result = missingTextString;
        //localizedText의 Type 키값을 받아와 활성화 시킴.
        if (npcName != null)
        {
            if (npcName.ContainsKey(key))
            {
                // result에 해당하는 키값 할당.;
                result = npcName[key];
            }
        }

        return result;
    }

}
