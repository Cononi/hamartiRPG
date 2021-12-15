using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using Newtonsoft.Json;

#if !UNITY_EDITOR
public class LocalizedTextEditor
{
}
#endif
#if UNITY_EDITOR
public class LocalizedTextEditor : EditorWindow
{
    public LocalizationData localizationData;
    
    [MenuItem ("Window/Localized Text Editor")]
    static void Init()
    {
        EditorWindow.GetWindow (typeof(LocalizedTextEditor)).Show ();
    }

    private Vector2 scrollPos = Vector2.zero;

    private void OnGUI()
    {
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false, GUILayout.Width(GetWindow (typeof(LocalizedTextEditor)).position.width), GUILayout.Height(GetWindow (typeof(LocalizedTextEditor)).position.height));
        if (localizationData != null) 
        {
            SerializedObject serializedObject = new SerializedObject (this);
            SerializedProperty serializedProperty = serializedObject.FindProperty ("localizationData");
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

            localizationData = JsonConvert.DeserializeObject<LocalizationData>(dataAsJson);
        }
    }

    private void SaveGameData()
    {
        string filePath = EditorUtility.SaveFilePanel ("Save localization data file", Application.dataPath + "/Resources/Language/", "", "json");

        if (!string.IsNullOrEmpty(filePath))
        {
            string dataAsJson = JsonConvert.SerializeObject(localizationData);
            File.WriteAllText (filePath, dataAsJson);
        }
    }
    private void CreateNewData()
    {
        localizationData = new LocalizationData ();
    }
}
#endif
