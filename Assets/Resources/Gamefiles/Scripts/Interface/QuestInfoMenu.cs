using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class QuestInfoMenu : MonoBehaviour, IPointerClickHandler
{
    public Text questNpcName; //퀘스트에 해당하는 엔피씨 네임
    public Text questinfoNames; // 퀘스트 제목
    public Text questContents; // 퀘스트의 내용.
    public Text quesTions; // 힌트성 메세지.
    public Image npcdataImage; // 엔피시 데이터 버튼.
    public List<QuestLocalizedContents> questLocalizedName;
    public void OnPointerClick(PointerEventData data)
    {
        ButtonManager.instance.bttS[8].onClick.RemoveAllListeners();
        ButtonManager.instance.bttS[9].onClick.RemoveAllListeners();
        for (int i = 0; i < questLocalizedName.Count; i++)
        {
            if (questLocalizedName[i].npcDataSwitch == true)
            {
                questinfoNames.text = questLocalizedName[i].questTitle;
                questContents.text = questLocalizedName[i].questContents;
                quesTions.text = questLocalizedName[i].quesTionText;
                GameManager.instance.pageNum = i;
                if (questLocalizedName[i].npcDataSwitch == true && questLocalizedName[i].clearS == false)
                {
                    break;
                }
            }
        }
        ButtonManager.instance.bttS[8].onClick.AddListener(buttonsup);
        ButtonManager.instance.bttS[9].onClick.AddListener(buttonsdown);
    }
    public void buttonsup()
    {
        ++GameManager.instance.pageNum;
        if (GameManager.instance.pageNum < questLocalizedName.Count && questLocalizedName[GameManager.instance.pageNum].npcDataSwitch == true)
        {
            if (questLocalizedName[GameManager.instance.pageNum].npcDataSwitch == true)
            {
                questinfoNames.text = questLocalizedName[GameManager.instance.pageNum].questTitle;
                questContents.text = questLocalizedName[GameManager.instance.pageNum].questContents;
                quesTions.text = questLocalizedName[GameManager.instance.pageNum].quesTionText;
            }
        }
        else
        {
            --GameManager.instance.pageNum;
        }
    }
    public void buttonsdown()
    {
        --GameManager.instance.pageNum;
        if (GameManager.instance.pageNum >= 0)
        {
            if (questLocalizedName[GameManager.instance.pageNum].npcDataSwitch == true)
            {
                questinfoNames.text = questLocalizedName[GameManager.instance.pageNum].questTitle;
                questContents.text = questLocalizedName[GameManager.instance.pageNum].questContents;
                quesTions.text = questLocalizedName[GameManager.instance.pageNum].quesTionText;
            }
        }
        else
        {
            ++GameManager.instance.pageNum;
        }
    }
    public void questSetup()
    {
        if (QuestDatabase.instance.questlocalizedDatas.ContainsKey(gameObject.name))
        {
        }
    }
}
