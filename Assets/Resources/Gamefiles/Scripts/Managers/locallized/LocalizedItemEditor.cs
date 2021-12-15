using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using Newtonsoft.Json;

#if !UNITY_EDITOR
public class LocalizedItemEditor
{
}
#endif
#if UNITY_EDITOR
public class LocalizedItemEditor : EditorWindow
{
    public LocalizationItemData localizationItemData;
    
    [MenuItem ("Window/Localized Item Table Editor")]
    static void Init()
    {
        EditorWindow.GetWindow (typeof(LocalizedItemEditor)).Show ();
    }

    private Vector2 scrollPos = Vector2.zero;

    private void OnGUI()
    {
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false, GUILayout.Width(GetWindow (typeof(LocalizedItemEditor)).position.width), GUILayout.Height(GetWindow (typeof(LocalizedItemEditor)).position.height));
        if (localizationItemData != null) 
        {
            SerializedObject serializedObject = new SerializedObject (this);
            SerializedProperty serializedProperty = serializedObject.FindProperty ("localizationItemData");
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

            localizationItemData = JsonConvert.DeserializeObject<LocalizationItemData>(dataAsJson);
        }
    }

    private void SaveGameData()
    {
        string filePath = EditorUtility.SaveFilePanel ("Save localization data file", Application.dataPath + "/Resources/Language/", "", "json");

        if (!string.IsNullOrEmpty(filePath))
        {
            string dataAsJson = JsonConvert.SerializeObject(localizationItemData);
            File.WriteAllText (filePath, dataAsJson);
        }
    }
    private void CreateNewData()
    {
        localizationItemData = new LocalizationItemData ();
    }
}
#endif
