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

    public interface IReward
    {
        int AnswerIndex { get; }
    }

    [Serializable]
    public struct NormalReward : IReward
    {
        public int credit;
        public NormalAnswer answer;

        public int AnswerIndex => credit;
    }

    [Serializable]
    public struct WeirdReward : IReward
    {
        public int damage;
        public WeirdAnswer answer;

        public int AnswerIndex => damage;
    }

    #endregion

    [CreateAssetMenu(fileName = "SurveyQuizData", menuName = "SO/KDH/SurveyQuizData", order = 0)]
    public class SurveyQuizSO : ScriptableObject
    {
        [Header("Setting")][TextArea]
        public string mainQuizText;
        
        [Header("Werid survey")]
        public bool weirdQuiz;
        public GameObject[] weirdEventSO;
        public GameObject surveyMission;
        public NormalAnswer normalAnswer;
        public WeirdAnswer weirdAnswer;
        public NormalReward[] normalAnswerReward;
        public WeirdReward[] weirdAnswerReward;
        public bool hasMission;
    }
}
