using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using System;


[Serializable]
public class QuestLocalizedData // 데이터 총괄.
{
    public QuestLocalizedName[] questLocalizedNames;
}
[Serializable]
public class QuestLocalizedName // 해당 엔피시가 가진 힌트 정보들.
{
    [Header("엔피시 네임")]
    public string name; // 해당 엔피시 이름.
    [Header("엔피시가 가진 정보")]
    public List<QuestLocalizedContents> questlocalizedContents; //  콘텐츠 정보
}
[Serializable]
public class QuestLocalizedContents
{
    [Header("활성상태")]
    public bool npcDataSwitch; // 해당 정보가 오픈인지 아닌지에 대한 유무.
    public bool clearS; // 클리어했는지 유무
    [Header("타이틀")]
    public string questTitle; // 해당 엔피시의 주요내용 타이틀 정보
    [Header("엔피시 좌표")]
    public Vector2 questNpcPosition; // 해당 엔피시의 좌표
    [TextArea]
    [Header("내용")]
    public string questContents; // 해당 콘텐츠 내용
    [Header("힌트")]
    public string quesTionText; // 해당 힌트 내용
    [Header("필요 아이템")]
    public info infoType; // 해당 아이템 종류
    public int itemNumber = -1; // 해당 아이템이 필요한지에 대해.
    public int clearItemNumber = -1; //해당 아이템이 몇개나 필요한지.
    [Header("클리어 보상 아이템")]
    public info ClearType; // 해당 아이템 종류
    public int ClearItem = -1; // 해당 아이템이 필요한지에 대해.
    [Header("해당 퀘스트에 대한 대화길이")]
    public int TalkLangth;
    public QuestLocalizedContents(bool _NPCDATASWITCH, string _QUESTTITLE, Vector2 _QUESTNPCPOSITION, string _QUESTONTENTS, string _QUESTIONTEXT, info _INFOTYPE, int _ITEMNUMBER, info _CLEARTYPE, int _CLEARITEM)
    {

        npcDataSwitch = _NPCDATASWITCH;
        questTitle = _QUESTTITLE;
        questNpcPosition = _QUESTNPCPOSITION;
        questContents = _QUESTONTENTS;
        quesTionText = _QUESTIONTEXT;
        infoType = _INFOTYPE;
        itemNumber = _ITEMNUMBER;
        ClearType = _CLEARTYPE;
        ClearItem = _CLEARITEM;
    }
}



