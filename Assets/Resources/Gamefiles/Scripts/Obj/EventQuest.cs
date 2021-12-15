using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQuest : MonoBehaviour
{
    [Header(" - 연계 퀘스트에 대한 이벤트")]
    public static EventQuest instance;
    public string questnpcOpen; // 비우면 연계퀘스트 x 있으면 o
    public bool questnpcbool; // 연계퀘스트 엔피시인가? true면 o 아니면 x
    public int questNumber; // 어떤 퀘스트를 on시키면
    
    [Header(" - 퀘스트에 관련된 엔피시 소환")]
    public List<GameObject> questObjMonster; // 0이면 실행 x 0이상이면 실행
    public bool questMonsterbool; // 몬스터관련 실행불린값
    public int MonsterquestNumber; // 어떤 퀘스트를 on시키면  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
