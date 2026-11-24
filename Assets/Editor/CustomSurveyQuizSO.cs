using KDH.Scripts.Surveies;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SurveyQuizSO))]
public class CustomSurveyQuizSO : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update(); // 커스텀 시작

        var mainQuizText = serializedObject.FindProperty("mainQuizText"); // MainText
        var weirdQuizProperty = serializedObject.FindProperty("weirdQuiz"); // IsWeird
        var hasMission = serializedObject.FindProperty("hasMission"); // HasMission

        EditorGUILayout.PropertyField(mainQuizText);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("weirdEventSO"), new GUIContent("Events"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("hasMission"), new GUIContent("Has Survey Missions"));
        if (hasMission.boolValue)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("surveyMission"), new GUIContent("Instance"));
        }

        EditorGUILayout.PropertyField(weirdQuizProperty); // 인스펙터에 그리기

        if (weirdQuizProperty.boolValue) // 가져왔던 데이터, bool
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("weirdAnswerReward"), new GUIContent("Weird Survey Settings")); // 인스펙터에 그리기
        }
        else
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("normalAnswerReward"), new GUIContent("Normal Survey Settings")); // 인스펙터에 그리기
        }

        serializedObject.ApplyModifiedProperties(); // 커스텀 끝
    }
}