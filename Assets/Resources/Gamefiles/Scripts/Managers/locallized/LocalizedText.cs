using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;
using System;

public class LocalizedText : MonoBehaviour
{
    public string type;
    public string key;
    public int i;
    public Text text;

    public void OnEnable()
    {
        text = GetComponent<Text>();
        if(LocalizationManager.instance != null)
        text.text = LocalizationManager.instance.GetLocalizedValue(type,key,i);
    }
}

//수정이 필히 요망함!
