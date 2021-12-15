using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;
using System;

public class NpcName : MonoBehaviour
{
    public string type;
    public string key;
    public int i;
    public Text text;
    public Text text2;

    public void OnEnable()
    {
       // text = transform.GetChild(0).GetComponent<Text>();
        text2 = transform.GetChild(1).GetComponent<Text>();
        if (LocalizationManager.instance != null)
        {
           // text.text = LocalizationManager.instance.GetLocalizedValue2(key);
            text2.text = LocalizationManager.instance.GetLocalizedValue(type, key, i);
        }
    }
}

//수정이 필히 요망함!
