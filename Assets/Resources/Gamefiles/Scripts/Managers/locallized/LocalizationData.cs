using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
//직렬화 가능한 클래스임을 명시함.
//객체를 '연속적인 데이터'로 변환하는 것. 반대과정은 역직렬화
//[NonSerialized] 직렬화를 하지 않을때.
//오브젝트 직렬화 클래스.


// 로컬라이징의 타입별로 담기위한 클래스.
[Serializable]
public class LocalizationData
{
    [Header("타입 개수 입력")]
    public LocalizationDatas[] LocalTypeName;
}

[Serializable]
// 내용물의 집합체 클래스.
public class LocalizationDatas
{
    [Header("타입의 내용")]
    public string type; // 해당 종류
                        // LocalizationItem을 담아둘 배열
    public LocalizationItem[] items;
}

// 해당 타입의 내용물을 담고있는 클래스.
[Serializable]
public class LocalizationItem
{
    [Header("해당 값들")]
    public string key;   // 해당 이름
    [TextArea]
    public List<string> value; // 내용

    public LocalizationItem(string KEY, List<string> VALUE)
    {
        this.key = KEY;
        this.value = VALUE;
    }
}