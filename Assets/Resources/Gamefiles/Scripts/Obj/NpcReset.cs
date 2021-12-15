using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcReset : MonoBehaviour
{
    [SerializeField]
    List<GameObject> NpcSet;
    [SerializeField]
    List<Sign> NpcSignSet;
    [SerializeField]
    List<GameObject> NoneSignSet;
    [SerializeField]
    LightNight place;
    public List<Light> placeMaplights;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (NpcSet != null)
            {
                for (int i = 0; i < NpcSet.Count; i++)
                    NpcSet[i].SetActive(true);

                for (int i = 0; i < NoneSignSet.Count; i++)
                {
                    NoneSignSet[i].SetActive(true);
                }
                npcState();
            }
            if (place != null)
            {
                place.npcReset = this;
                if (place.time >= 19 || place.time == 0)
                    for (int i = 0; i < placeMaplights.Count; i++)
                    {
                        placeMaplights[i].gameObject.SetActive(true);
                    }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (NpcSet != null)
            {
                for (int i = 0; i < NpcSet.Count; i++)
                    NpcSet[i].SetActive(false);
                for (int i = 0; i < NoneSignSet.Count; i++)
                {
                    NoneSignSet[i].SetActive(false);
                }
            }
            if (place != null)
            {
                place.npcReset = null;
                if (place.time >= 19 || place.time == 0)
                    for (int i = 0; i < placeMaplights.Count; i++)
                    {
                        placeMaplights[i].gameObject.SetActive(false);
                    }
            }
        }

    }


    private void npcState()
    {
        for (int i = 0; i < NpcSet.Count; i++)
        {
            if (NpcSignSet[i].NoneQuest == false)
            {
                for (int j = 0; j < QuestDatabase.instance.questlocalizedDatas[NpcSet[i].name].Count; j++)
                {
                    if (QuestDatabase.instance.questlocalizedDatas[NpcSet[i].name][j].npcDataSwitch == true && QuestDatabase.instance.questlocalizedDatas[NpcSet[i].name][j].clearS == false)
                    {
                        NpcSignSet[i].ActivateLayer(Sign.StateLayers.Qna);
                        break;
                    }
                    else if (QuestDatabase.instance.questlocalizedDatas[NpcSet[i].name][j].npcDataSwitch == false && QuestDatabase.instance.questlocalizedDatas[NpcSet[i].name][j].clearS == false)
                    {
                        NpcSignSet[i].ActivateLayer(Sign.StateLayers.State);
                        break;
                    }
                    else
                    {
                        NpcSignSet[i].ActivateLayer(Sign.StateLayers.State);
                    }
                }
            }
            else
            {
                NpcSignSet[i].ActivateLayer(Sign.StateLayers.Talk);
            }
            if (NpcSignSet[i].NoneQuest == false)
                if (QuestDatabase.instance.questlocalizedDatas[NpcSet[i].name][QuestDatabase.instance.questlocalizedDatas[NpcSet[i].name].Count - 1].npcDataSwitch == true && QuestDatabase.instance.questlocalizedDatas[NpcSet[i].name][QuestDatabase.instance.questlocalizedDatas[NpcSet[i].name].Count - 1].clearS == true)
                    NpcSignSet[i].ActivateLayer(Sign.StateLayers.Thank);
        }
    }
}
