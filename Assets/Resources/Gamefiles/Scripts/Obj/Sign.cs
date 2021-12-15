using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


[System.Serializable]
class SingInfo
{
    //버블 부분.
    public GameObject dialogBox;
    public Text questMainText; // 퀘스트 메인 텍스트창 공지창.
    public Image elementalText; // 표시할 텍스트 이미지파일
    public Camera camerA;   // 메인카메라를 기준으로하는 월드좌표를 스크린 좌표로 바꾸기위한 오브젝트 지정.
    public Transform target;    // 고정 타겟이 될 기준.
    public Transform Player; // 플레이어.
    [Header(" - null = 퀘스트x 일반대화 or 연계성퀘스트 null != 퀘스트.")]
    public NpcQuest questSet; // 퀘스트셋에 대한 내용값.
}

public class Sign : MonoBehaviour
{
    public enum StateLayers
    {
        idle = 0,
        Qna = 1,
        State = 2,
        Talk = 3,
        Thank = 4,
    }
    Vector3 textVec;
    Text dialogText; // 텍스트
    [HideInInspector]
    public bool dialogActive; // 텍스트박스 제어 변수
    [SerializeField]
    [TextArea] // 개행가능한 텍스트를 만들기 위한것(텍스트박스.) (Inspector창에 TextArea만들기.)
    List<string> diaLog; // 대화 내용을 담기위한 장치.
    Coroutine _crtShowText2; // 코루틴을 위한 코루틴.
    string diaLogJsonDate; // 불러온 json을 텍스트화해 담을 string
    [Header(" - 해당타입과 키값(로컬라이징)")]
    public string type; // 해당 타입.
    public string key; // Npc키값.
    bool qeustOn; // 퀘스트가 실행인가?
    public bool rand; // 랜덤대화.
    [SerializeField]
    SingInfo singInfo; // 종합정보.
    [Header(" - 몇번 리스트의 대화를 호출할것인지?")]
    public int talkSet; // 퀘스트진행시 대화 번호값.
    [Header(" - 클리어시 몇번 리스트의 대화를 호출할것인지?")]
    public int CleartalkSet; // 퀘스트 진행후 클리어시 나올 대화.
    [Header(" - 연계 퀘스트에 대한 이벤트")]
    public string questnpcOpen; // 비우면 연계퀘스트 x 있으면 o
    public bool questnpcbool; // 연계퀘스트 엔피시인가? true면 o 아니면 x
    public int questNumber; // 어떤 퀘스트를 on시키면 
    [Header(" - 퀘스트에 관련된 엔피시 소환")]
    public List<GameObject> questObjMonster; // 0이면 실행 x 0이상이면 실행
    public bool questMonsterbool; // 몬스터관련 실행불린값
    public int MonsterquestNumber; // 어떤 퀘스트를 on시키면 
    public Animator questAni; // 엔피시가 가진 애니메이션 Clear,Happy가 있음.
    public SpriteRenderer sp; // 엔피시와의 높낮이에 관련된 값. 
    bool questAnibool;
    [Header(" - 엔피시 스테이터스 애니")]
    public Animator StateAnis; // 엔피시의 퀘스트 진행상태 애니..
    public bool NoneQuest; // 퀘스트가 없는 엔피시일경우. true 없는 npc 아니면 있는 엔피시
    [Header(" - 엔피시 실행. questnpcbool 켜져야 됩니다.")]
    public List<GameObject> npcs; //엔피시에 대한 상호작용
    Vector3 signquestText;
    private void Start()
    {
        GameObject bubble = Instantiate(singInfo.dialogBox, singInfo.dialogBox.transform.position, singInfo.dialogBox.transform.rotation) as GameObject;
        bubble.transform.SetParent(transform);
        singInfo.dialogBox = bubble;
        singInfo.elementalText = singInfo.dialogBox.transform.GetChild(0).GetComponent<Image>();
        dialogText = singInfo.elementalText.transform.GetChild(0).GetComponent<Text>();
        bubble.SetActive(false);
        sp = GetComponent<SpriteRenderer>();
        if (NoneQuest == true)
        {
            ActivateLayer(StateLayers.Talk);
        }
        else
        {
            ActivateLayer(StateLayers.State);
        }
        signquestText = singInfo.questMainText.transform.position;
    }
    public void onEnable()
    {
        diaLogJsonDate = LocalizationManager.instance.GetLocalizedValue(type, key, talkSet);
        diaLogJsonDate = diaLogJsonDate.Replace(",\n", ",");
        diaLogJsonDate = diaLogJsonDate.Replace("\\n", "\n");
        diaLog = diaLogJsonDate.Split(',').ToList();
    }

    public void ActivateLayer(StateLayers layerName)
    {
        // 모든 레이어의 무게값을 0 으로 만들어 줍니다.
        for (int i = 0; i < StateAnis.layerCount; i++)
        {
            StateAnis.SetLayerWeight(i, 0);
        }
        StateAnis.SetLayerWeight((int)layerName, 1);
    }
    IEnumerator ShowText_2(List<string> _fullText)
    {
        int curWord = 0;
        int sRands = 0;
        bool isProcess = true;
        bool isSkip = false;
        ButtonManager.instance.bus = false;
        dialogActive = true;
        GameManager.instance.OneSign = true;
        if (questAni != null)
            if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][QuestDatabase.instance.questlocalizedDatas[gameObject.name].Count - 1].clearS == true)
            {
                ActivateLayer(StateLayers.Thank);
                questAni.SetBool("Happy", true);
                questAnibool = true;
            }
        while (_fullText.Count > 0)
        {
            // screenPos에 타겟 오브젝트의 월드 좌표를 스크린 좌표로 변환후 저장한다.
            Vector3 screenPos = singInfo.camerA.WorldToScreenPoint(singInfo.target.position);
            // elemantalText란 이미지를 해당 오브젝트의 설정된 좌표로 새로 부여하여 고정시킨다.
            singInfo.elementalText.transform.position = new Vector3(screenPos.x, screenPos.y + singInfo.elementalText.rectTransform.rect.height, singInfo.elementalText.transform.position.z);
            if ((singInfo.target.position - singInfo.Player.position).magnitude < 2)
            {
                singInfo.dialogBox.SetActive(true);
                if (isProcess)
                {
                    for (curWord = 0; curWord < _fullText[sRands].Length; curWord++)
                    {
                        if (ButtonManager.instance.bus)
                        {
                            isSkip = true;
                            yield return new WaitForSeconds(0.1f);
                        }
                        if (isSkip)
                        {
                            dialogText.text = _fullText[sRands];
                            break;
                        }
                        else
                        {
                            if ((singInfo.target.position - singInfo.Player.position).magnitude < 2)
                            {
                                dialogText.text = _fullText[sRands].Substring(0, curWord + 1);
                                yield return new WaitForSeconds(0.02f);
                            }
                            else
                            {
                                break;

                            }
                        }
                    }// for (int i = 0; i < _fullText[cur].Length; i++)
                    isProcess = false;
                }// if(isProcess)
                if (ButtonManager.instance.bus)
                {
                    ButtonManager.instance.bus = false;
                    if (isSkip)
                    {
                        isSkip = false;
                    }
                    else
                    {
                        isProcess = true;
                        if (rand)
                        {
                            _fullText.Remove(_fullText[sRands]);
                            sRands = 0;
                            sRands = Random.Range(0, _fullText.Count);
                        }
                        else
                        {
                            _fullText.Remove(_fullText[sRands]);
                            sRands = 0;
                            if (_fullText.Count == 0)
                            {
                                qeustOn = true;
                            }
                        }
                        yield return new WaitForSeconds(0.1f);

                    }
                }// if (Input.GetKeyUp(KeyCode.Space))
                yield return null;
            }
            else
            {
                break;
            }
            //onEnable();
        }// while (curLine < _fullText.Count)
         //초기 퀘스트를 받을때.
        if (singInfo.questSet != null)
            if (qeustOn)
                if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][0].npcDataSwitch == true)
                {
                    for (int i = 0; i < QuestDatabase.instance.questlocalizedDatas[gameObject.name].Count; i++)
                    {
                        if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].npcDataSwitch == true && QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].clearS == false)
                        {
                            if (questObjMonster.Count != 0 && QuestDatabase.instance.questlocalizedDatas[gameObject.name][MonsterquestNumber].npcDataSwitch == true)
                            {
                                if (questMonsterbool == false)
                                    questMonsterbool = true;
                                for (int j = 0; j < questObjMonster.Count; j++)
                                {
                                    questObjMonster[j].SetActive(true);
                                }
                                ActivateLayer(StateLayers.State);
                                StartCoroutine(PlaceNameCo(QuestDatabase.instance.questlocalizedDatas[gameObject.name][MonsterquestNumber].questTitle + " 을(를) 모두 처치해라!!!\n"));
                                break;
                            }
                            else if (questObjMonster.Count == 0 && questMonsterbool == true)
                            {
                                questMonsterbool = false;
                                StartCoroutine(PlaceNameCo(QuestDatabase.instance.questlocalizedDatas[gameObject.name][MonsterquestNumber].questTitle + " 을(를) 도와줬다!!!\n"));
                                singInfo.questSet.QuestClear();
                                break;
                            }
                            else if (questMonsterbool == false)
                            {
                                singInfo.questSet.QuestClear();
                                break;
                            }
                        }
                        else if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].npcDataSwitch == false && QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].clearS == false)
                        {
                            QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].npcDataSwitch = true;
                            StartCoroutine(PlaceNameCo(QuestDatabase.instance.questlocalizedDatas[gameObject.name][i].questTitle + " 퀘스트 입수!!!\n"));
                            ActivateLayer(StateLayers.Qna);
                            break;
                        }
                    }
                }
                else if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][0].npcDataSwitch == false)
                {
                    QuestDatabase.instance.questlocalizedDatas[gameObject.name][0].npcDataSwitch = true;
                    QuestDatabase.instance.npcName.Add(gameObject.name);
                    singInfo.questSet.questSetup();
                    StartCoroutine(PlaceNameCo(QuestDatabase.instance.questlocalizedDatas[gameObject.name][0].questTitle + " 퀘스트 입수!!!\n"));
                    ActivateLayer(StateLayers.Qna);
                }
        /*   //중간 퀘스트 받을때.
          if (singInfo.questSet != null)
          {
              if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][questNumber].npcDataSwitch == true && QuestDatabase.instance.questlocalizedDatas[gameObject.name][questNumber].clearS == false)
              {
                  if (questObjMonster.Count != 0)
                  {
                      questMonsterbool = true;
                      for (int i = 0; i < questObjMonster.Count; i++)
                      {
                          questObjMonster[i].SetActive(true);
                          ActivateLayer(StateLayers.State);
                      }
                  }
                  else
                  {
                      ActivateLayer(StateLayers.Qna);
                      singInfo.questSet.QuestClear();
                      questMonsterbool = false;
                  }
              }
              else
              {
                  ActivateLayer(StateLayers.Qna);
                  singInfo.questSet.QuestClear();
              }
          } */
        // 이벤트 미션.
        if (questnpcbool == true)
            if (QuestDatabase.instance.questlocalizedDatas[questnpcOpen][questNumber].clearS == true)
            {
                {
                    ActivateLayer(StateLayers.State);
                    DataManager.instance.dropQuestItem(gameObject.name);
                    GameObject.Destroy(gameObject);
                }
            }
        qeustOn = false;
        dialogActive = false;
        GameManager.instance.OneSign = false;
        singInfo.dialogBox.SetActive(false);
        ButtonManager.instance.bttS[7].gameObject.SetActive(false);
        ButtonManager.instance.bttS[6].gameObject.SetActive(true);
        //
        for (int i = 0; i < npcs.Count; i++)
        {
            npcs[i].GetComponent<Npcs>().npcStart();
        }
        //
        if (questAni != null && questAnibool == true)
            if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][QuestDatabase.instance.questlocalizedDatas[gameObject.name].Count - 1].clearS == true)
            {
                questAni.SetBool("Clear", false);
                questAni.SetBool("Happy", false);
                ActivateLayer(StateLayers.Thank);
                questAnibool = false;
            }
        if (_crtShowText2 != null)
        {
            StopCoroutine(_crtShowText2);
            _crtShowText2 = null;
        }
    }
    public IEnumerator PlaceNameCo(string s)
    {
        singInfo.questMainText.transform.position = signquestText;
        singInfo.questMainText.text = s;
        // 오브젝트를 온시킴.
        singInfo.questMainText.gameObject.SetActive(true);
        // 오브젝트의 이름을 띄우기위해 플레이스 이름입력
        for (float i = 0; i <= 1; i += 0.02f)
        {
            singInfo.questMainText.transform.position -= new Vector3(0.3f, 0, 0);
            singInfo.questMainText.color = new Vector4(singInfo.questMainText.color.r, singInfo.questMainText.color.g, singInfo.questMainText.color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(4f);
        for (float i = 1; i >= 0; i -= 0.05f)
        {
            singInfo.questMainText.transform.position += new Vector3(0.3f, 0, 0);
            singInfo.questMainText.color = new Vector4(singInfo.questMainText.color.r, singInfo.questMainText.color.g, singInfo.questMainText.color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        singInfo.questMainText.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D sign)
    {
        if (dialogActive == false)
        {
            if (sign.gameObject.CompareTag("Player"))
            {
                if (transform.position.y < singInfo.Player.position.y)
                {
                    sp.sortingOrder = 100;
                }
                else
                {
                    sp.sortingOrder = -1;
                }
                if (questnpcOpen != "")
                {
                    if (QuestDatabase.instance.questlocalizedDatas[questnpcOpen][questNumber].clearS == true && questnpcbool == true && questMonsterbool == false)
                    {
                        talkSet = CleartalkSet;
                        //StartCoroutine(ShowText(diaLog));
                        ButtonManager.instance.bttS[7].gameObject.SetActive(true);
                        ButtonManager.instance.bttS[6].gameObject.SetActive(false);
                        onEnable();
                        _crtShowText2 = StartCoroutine(ShowText_2(diaLog));
                    }
                    else if (questnpcbool == true)
                    {
                        if (npcs != null)
                        {
                            for (int i = 0; i < npcs.Count; i++)
                            {
                                npcs[i].GetComponent<Animator>().SetBool("Move", true);
                            }
                        }
                        //StartCoroutine(ShowText(diaLog));
                        ButtonManager.instance.bttS[7].gameObject.SetActive(true);
                        ButtonManager.instance.bttS[6].gameObject.SetActive(false);
                        onEnable();
                        _crtShowText2 = StartCoroutine(ShowText_2(diaLog));
                    }
                }
            }
            if (questnpcbool == false)
                if (sign.CompareTag("Talk_Range"))
                {
                    if (questnpcOpen == "")
                    {
                        if (singInfo.questSet != null)
                        {
                            for (int i = 0; i < LocalizationManager.instance.localizedText[type][key].Count; i++)
                            {
                                for (int j = 0; j < QuestDatabase.instance.questlocalizedDatas[gameObject.name].Count; j++)
                                {
                                    if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].npcDataSwitch == true && QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].clearS == false && QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].TalkLangth - 2 == i)
                                    {
                                        talkSet = i;
                                        break;

                                    }
                                    else if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].npcDataSwitch == true && QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].clearS == false && QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].TalkLangth - 1 == i)
                                    {
                                        talkSet = i - 1;

                                        for (int k = 0; k < Inventory.instance.slot_Table.Count; k++)
                                        {
                                            if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].npcDataSwitch == true && QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].clearS == false)
                                            {
                                                if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].infoType == Inventory.instance.slot_Table[k].info
                                                && QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].itemNumber == (int)Inventory.instance.slot_Table[k].DropItemNumber
                                                && QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].clearItemNumber <= (int)Inventory.instance.slot_Table[k].ItemCount)
                                                {
                                                    talkSet = i;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    else if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][QuestDatabase.instance.questlocalizedDatas[gameObject.name].Count - 1].npcDataSwitch == true && QuestDatabase.instance.questlocalizedDatas[gameObject.name][QuestDatabase.instance.questlocalizedDatas[gameObject.name].Count - 1].clearS == true)
                                    {
                                        talkSet = i;

                                    }
                                    else if (QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].npcDataSwitch == true && QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].clearS == true && QuestDatabase.instance.questlocalizedDatas[gameObject.name][j + 1].npcDataSwitch == false && QuestDatabase.instance.questlocalizedDatas[gameObject.name][j].TalkLangth == i)
                                    {
                                        talkSet = i;
                                        break;
                                    }
                                }
                            }
                        }
                        onEnable();
                        if (GameManager.instance.OneSign != true)
                        {
                            //StartCoroutine(ShowText(diaLog));
                            ButtonManager.instance.bttS[7].gameObject.SetActive(true);
                            ButtonManager.instance.bttS[6].gameObject.SetActive(false);
                            _crtShowText2 = StartCoroutine(ShowText_2(diaLog));
                        }
                    }
                    else if (QuestDatabase.instance.questlocalizedDatas[questnpcOpen][questNumber].clearS == true)
                    {
                        talkSet = 1;
                        //StartCoroutine(ShowText(diaLog));
                        ButtonManager.instance.bttS[7].gameObject.SetActive(true);
                        ButtonManager.instance.bttS[6].gameObject.SetActive(false);
                        onEnable();
                        _crtShowText2 = StartCoroutine(ShowText_2(diaLog));
                    }
                    else
                    {
                        //StartCoroutine(ShowText(diaLog));
                        ButtonManager.instance.bttS[7].gameObject.SetActive(true);
                        ButtonManager.instance.bttS[6].gameObject.SetActive(false);
                        onEnable();
                        _crtShowText2 = StartCoroutine(ShowText_2(diaLog));
                    }
                }
        }

    }
    private void OnDisable()
    {
        if (singInfo.questMainText != null)
            singInfo.questMainText.gameObject.SetActive(false);
        StopAllCoroutines();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (questnpcbool == true)
            {
                for (int i = 0; i < npcs.Count; i++)
                    npcs[i].GetComponent<Animator>().SetBool("Move", false);
            }
        }
    }

}
