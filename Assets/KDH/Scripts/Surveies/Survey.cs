using KDH.Scripts.Rooms;
using KDH.Scripts.Systems;
using System.Collections.Generic;
using UnityEngine;

namespace KDH.Scripts.Surveies
{
    public class Survey : MonoBehaviour
    {
        [field: SerializeField] public SurveyUI SurveyUI { get; private set; }
        [field: SerializeField] public Room[] Rooms { get; private set; }
        [field: SerializeField] public Transform ExceptionSurveySpawnTrm { get; private set; }
        [SerializeField] private GameManager _gameManager;

        public bool HasCompletedSurvey { get; private set; }
        [field: SerializeField] public int WarningCount { get; private set; } = 0;
        public bool IsDead { get; private set; }

        private readonly List<NormalAnswer> _normalAnswers = new();
        private readonly List<NormalReward> _normalReward = new();
        public IReadOnlyList<NormalReward> NormalReward => _normalReward;

        private int _currentSurveyIndex;
        private bool _myAnswer;

        private void Start()
        {
            SurveyUI.YesBtn.onClick.AddListener(InitSurveyQuiz);
            SurveyUI.IdkBtn.onClick.AddListener(InitSurveyQuiz);
            SurveyUI.NoBtn.onClick.AddListener(InitSurveyQuiz);

            InitSurveyQuiz();
        }

        private void OnDestroy()
        {
            SurveyUI.YesBtn.onClick.RemoveAllListeners();
            SurveyUI.IdkBtn.onClick.RemoveAllListeners();
            SurveyUI.NoBtn.onClick.RemoveAllListeners();
        }

        public void ResultSurvey(List<SurveyQuizSO> surveys)
        {
            CalcurateMonney(surveys);
            GetWarning();
            GetDamage();
        }

        private void CalcurateMonney(List<SurveyQuizSO> surveys)
        {
            foreach (var survey in surveys) // 돈 주기 부분
            {
                for (int i = 0; i < survey.normalAnswerReward.Length; i++)
                {
                    if (survey.normalAnswerReward[i].answer == _normalAnswers[i])
                    {
                        _gameManager.Resources.GetCredit(survey.normalAnswerReward[i].credit);
                        break;
                    }
                }
            }
        }

        public void ResetWarning()
        {
            if (_gameManager.CurrentDay != 0 && _gameManager.CurrentDay % 3 == 0)
            {
#if UNITY_EDITOR
                Debug.Log("경고 초기화");
# endif
                WarningCount = 0;
            }
        }

        private void GetWarning()
        {
            int warningCount = 0;

            foreach (var answer in _normalAnswers)
            {
                if (answer == NormalAnswer.Idk)
                {
                    warningCount++;
                }
            }

            if (warningCount >= 4)
            {
#if UNITY_EDITOR
                Debug.Log("경고 먹음, 모르겠음을 선택한 횟수: " + warningCount);
# endif
                WarningCount++;
            }

            if (WarningCount != 0 && WarningCount % 2 == 0)
            {
                _gameManager.Resources.SubstractLife(1);
#if UNITY_EDITOR
                Debug.Log("경고가 2번 쌓여서 데미지 줌");
# endif
            }
        }

        private void GetDamage()
        {
            // 데미지 부분
            bool surveyAnswer = _gameManager.WeirdEventManager.HasWeirdEvent;
            bool playerAnswer = _myAnswer;

            if (playerAnswer == true && surveyAnswer == false)
            {
# if UNITY_EDITOR
                Debug.Log("있다고 했는데 없음");
# endif
                _gameManager.Resources.SubstractLife(_gameManager.DailySurveyList[_gameManager.CurrentDay].damage);
            }
            else if (playerAnswer == false && surveyAnswer == true)
            {
# if UNITY_EDITOR
                Debug.Log("없다고 헀는데 있음");
# endif
                IsDead = true;
                GameManager.Instance.UIManager.HealthText.ChangeHealthText(0);
            }

            if (_gameManager.Resources.Life <= 0)
            {
# if UNITY_EDITOR
                Debug.Log("기회를 모두 소진하여 사망");
# endif
                IsDead = true;
            }
        }


        public void GetNormalSuveyResult(NormalSurveyTypeHandler type)
        {
            _normalAnswers.Add(type.NormalAnswer);

            foreach (var result in GameManager.Instance.CurrentSurvey.normalAnswerReward)
            {
                if (result.answer == type.NormalAnswer)
                    _normalReward.Add(result);
            }
        }

        // UnityEvent에서 호출
        public void GetWeridSurveyResult(bool value)
        {
            SurveyQuizSO currentSurvey = _gameManager.CurrentSurvey;
            if (currentSurvey == null || !currentSurvey.weirdQuiz)
                return;

            _myAnswer = value;
        }

        private void ResetSurveyResult()
        {
            _normalAnswers.Clear();
        }

        public void ResetNormalRewardResult()
        {
            _normalReward.Clear();
        }

        public void ResetTodaySurvey()
        {
            HasCompletedSurvey = false;
            _currentSurveyIndex = 0;

            if (_gameManager.CurrentDay >= _gameManager.DailySurveyList.Length)
            {
                Debug.Log("더 이상 설문조사가 없습니다.");
                return;
            }

            _gameManager.TodaySurveies = _gameManager.DailySurveyList[_gameManager.CurrentDay];
            ResetSurveyResult();
        }

        public void InitSurveyQuiz()
        {
            if (_currentSurveyIndex >= _gameManager.TodaySurveies.list.Count ||
                _gameManager.CurrentDay >= _gameManager.DailySurveyList.Length)
            {
                HasCompletedSurvey = true;
                SurveyUI.QuizText.SetText("모든 설문을 조사함");
                SurveyUI.YesBtn.gameObject.SetActive(false);
                SurveyUI.IdkBtn.gameObject.SetActive(false);
                SurveyUI.NoBtn.gameObject.SetActive(false);
                return;
            }

            if (!SurveyUI.YesBtn.gameObject.activeSelf)
                SurveyUI.YesBtn.gameObject.SetActive(true);
            if (!SurveyUI.NoBtn.gameObject.activeSelf)
                SurveyUI.NoBtn.gameObject.SetActive(true);

            _gameManager.CurrentSurvey = _gameManager.TodaySurveies.list[_currentSurveyIndex];
            SurveyQuizSO surveyData = _gameManager.CurrentSurvey;

            SurveyUI.QuizText.SetText(surveyData.mainQuizText);

            if (!surveyData.weirdQuiz)
                SurveyUI.SetChooseBtn(surveyData.normalAnswerReward);
            else
                SurveyUI.SetChooseBtn(surveyData.weirdAnswerReward);

            if (surveyData.hasMission)
                Instantiate(surveyData.surveyMission, ExceptionSurveySpawnTrm);

            _currentSurveyIndex++;
        }
    }
}
