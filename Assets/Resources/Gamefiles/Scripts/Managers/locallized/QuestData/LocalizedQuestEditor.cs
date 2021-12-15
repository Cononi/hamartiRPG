using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using Newtonsoft.Json;

#if !UNITY_EDITOR
public class LocalizedQuestEditor
{
}
#endif
#if UNITY_EDITOR
public class LocalizedQuestEditor : EditorWindow
{
    public QuestLocalizedData questLocalizedData;
    
[MenuItem ("Window/Localized Quest Table Editor")]
    static void Init()
    {
        EditorWindow.GetWindow (typeof(LocalizedQuestEditor)).Show ();
    }

    private Vector2 scrollPos = Vector2.zero;

    private void OnGUI()
    {
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false, GUILayout.Width(GetWindow (typeof(LocalizedQuestEditor)).position.width), GUILayout.Height(GetWindow (typeof(LocalizedQuestEditor)).position.height));
        if (questLocalizedData != null) 
        {
            SerializedObject serializedObject = new SerializedObject (this);
            SerializedProperty serializedProperty = serializedObject.FindProperty ("questLocalizedData");
            EditorGUILayout.PropertyField (serializedProperty, true);
            serializedObject.ApplyModifiedProperties ();

            if (GUILayout.Button ("Save data")) 
            {
                SaveGameData ();
            }
        }

        if (GUILayout.Button ("Load data")) 
        {
            LoadGameData ();
        }

        if (GUILayout.Button ("Create new data")) 
        {
            CreateNewData ();
        }
        EditorGUILayout.EndScrollView();
    }

    private void LoadGameData()
    {
        string filePath = EditorUtility.OpenFilePanel ("Select localization data file", Application.dataPath + "/Resources/Language/", "json");

        if (!string.IsNullOrEmpty (filePath)) 
        {
            string dataAsJson = File.ReadAllText (filePath);

            questLocalizedData = JsonConvert.DeserializeObject<QuestLocalizedData>(dataAsJson);
        }
    }

    private void SaveGameData()
    {
        string filePath = EditorUtility.SaveFilePanel ("Save localization data file", Application.dataPath + "/Resources/Language/", "", "json");

        if (!string.IsNullOrEmpty(filePath))
        {
            string dataAsJson = JsonConvert.SerializeObject(questLocalizedData);
            File.WriteAllText (filePath, dataAsJson);
        }
    }
    private void CreateNewData()
    {
        questLocalizedData = new QuestLocalizedData ();
    }
}
#endif
