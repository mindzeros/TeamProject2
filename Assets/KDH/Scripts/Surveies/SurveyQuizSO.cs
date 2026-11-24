using System;
using UnityEngine;

namespace KDH.Scripts.Surveies
{
    #region  DataFrom

    public enum NormalAnswer
    {
        Yes,
        Idk,
        No
    }

    public enum WeirdAnswer
    {
        Yes,
        No
    }

    [Serializable]
    public struct NormalReward
    {
        public int credit;
        public NormalAnswer answer;
        public bool InvokeEvent;
    }

    [Serializable]
    public struct WeirdReward
    {
        public WeirdAnswer answer;
    }

    #endregion

    [CreateAssetMenu(fileName = "SurveyQuizData", menuName = "SO/KDH/SurveyQuizData", order = 0)]
    public class SurveyQuizSO : ScriptableObject
    {
        [Header("Setting")][TextArea]
        public string mainQuizText;
        
        [Header("Werid survey")]
        public bool weirdQuiz;
        public WeirdAnswer weirdAnswer;
        public WeirdReward[] weirdAnswerReward;

        public NormalAnswer normalAnswer;
        public NormalReward[] normalAnswerReward;
        public GameObject surveyMission;
        public bool hasMission;
    }
}
