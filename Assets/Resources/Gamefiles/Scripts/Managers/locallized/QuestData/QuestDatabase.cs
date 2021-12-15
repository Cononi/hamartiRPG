using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;
using System;

public class QuestDatabase : MonoBehaviour
{
    public static QuestDatabase instance;
    public Dictionary<string, List<QuestLocalizedContents>> questlocalizedDatas;
    public NpcQuest[] npcQuests; // 퀘스트 종류
    public List<string> npcName; // 순서도 저장
    public List<NpcQuest> npcQuests2; // 순서도 불러오기
    void Awake()
    {
        instance = this;
        npcQuests = FindObjectsOfType(typeof(NpcQuest)) as NpcQuest[];
    }
    // 로컬라이징(파일명)
    public void LoadLocalizedQuest(string fileName)
    {
        // **두가지를 초기화 시켜주지 않으면 로컬라이징씨 불러올때 값이 중복되어 오류나 겹치는등이 생길 수 있음.**
        // 크로스플랫폼에서 언제든 불러와 쓸 수 있도록 고정로컬경로인 Resources폴더에 파일을 불러와 TextAsset으로 선언과 동시에 할당.
        TextAsset filePath = Resources.Load<TextAsset>("Language/" + fileName);
        questlocalizedDatas = new Dictionary<string, List<QuestLocalizedContents>>();
        //Debug.Log(filePath); // 정상적으로 불러오나 테스트.
        if (filePath != null) // filePath가 null이 아니라면 로컬라이징 파일 찾기 시작.
        {
            // 불러온 json파일을 텍스트화 해서 string에 할당.
            string dataAsJson = filePath.text;
            // json 문자열을 object화 하여 loadeData에 담음
            QuestLocalizedData loadedData = JsonConvert.DeserializeObject<QuestLocalizedData>(dataAsJson);
            //현재 불러온 언어를 저장하기 위한 변수. 그리고 공백일시 체크를 위해.
            for (int i = 0; i < loadedData.questLocalizedNames.Length; i++)
            {
                questlocalizedDatas.Add(loadedData.questLocalizedNames[i].name, loadedData.questLocalizedNames[i].questlocalizedContents);
            }
            // 로드가 정상적으로 되었고 몇개나 할당되었나 확인하기 위한 디버그.

            /*             foreach (NpcQuest questsNpc in npcQuest)
                        {
                            questsNpc.questSetup();
                        } */
        }
    }

    public void AddQuest()
    {
        for (int j = 0; j < npcName.Count; j++)
        {
            for (int i = 0; i < npcQuests.Length; i++)
            {
                if (npcName[j] == npcQuests[i].name)
                {
                    npcQuests2.Add(npcQuests[i]);
                    npcQuests2[j].questSetup();
                }
            }
        }

    }
}