using KDH.Scripts.Mails;
using KDH.Scripts.Stores;
using KDH.Scripts.Surveies;
using KDH.Scripts.WeirdEvents;
using System;
using UnityEngine;

namespace KDH.Scripts.Systems
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Settings")]
        public SurveyQuizSO CurrentSurvey { get; set; }
        [field: SerializeField] public int CurrentDay { get; private set; }

        [Header("Data")]
        [field: SerializeField] public DailySurveyListSO[] DailySurveyList { get; private set; }
        public DailySurveyListSO TodaySurveies { get; set; }
        [Header("Modules")]
        [field: SerializeField] public WeirdEventManager WeirdEventManager { get; private set; }
        [field: SerializeField] public ResourceManager Resources { get; private set; }
        [field: SerializeField] public UIManager UIManager { get; private set; }
        [field: SerializeField] public Survey Survey { get; private set; }
        [field: SerializeField] public StoreUI StoreUI { get; private set; }
        [field: SerializeField] public Store Store { get; private set; }
        [field: SerializeField] public Mail MailObj { get; private set; }

        public event Action OnDayChanged; // <= 자는 동안 발생한 것들 여기서 발행

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            Survey.ResetTodaySurvey();
        }

        private void Start()
        {
            MailObj.MailBoxController.MailMainText.SetText("아이템이 더 이상 없는 거 같다..");
        }

        public void ContinueNextDay() // onClick 이벤트로 연결, Ai한테 이상현상 호출에 대해 물오봄
        {
            if (!Survey.HasCompletedSurvey)
            {
                UIManager.MessageUI.SetUI("자기 전 모든 설문조사에 응시해야 합니다.");
                return;
            }

            Survey.ResetWarning();
            Survey.ResultSurvey(TodaySurveies.list);
            CurrentDay++;

            #if UNITY_EDITOR
            Debug.Log($"현재 {CurrentDay}일차");
            #endif

            foreach (var d in Resources.DeliveryItemDict)
            {
                Resources.AddMailItem(d.Key, d.Value);
            }

            MailObj.InitItem(Resources.DeliveryItemDict);
            Resources.ClearDeliveryDict();
            Survey.ResetTodaySurvey();
            Survey.InitSurveyQuiz();
            Store.ResetItems();

            if (Survey.IsDead)
            {
                UIManager.NextDayFadeInOutUI.Fade(1f, 1f, 1.25f, $"사망", () =>
                {
                    ResetAndInvokeWeirdEvent();
                    OnDayChanged?.Invoke();
                }, Color.red);

                return;
            }


            UIManager.NextDayFadeInOutUI.Fade(1f, 1f, 1.25f, $"{CurrentDay}일차", () =>
            {
                ResetAndInvokeWeirdEvent();
                OnDayChanged?.Invoke();
            }, Color.white);
        }

        private void ResetAndInvokeWeirdEvent()
        {
            foreach (var result in Survey.NormalReward)
            {
                if (result.InvokeEvent)
                {
                    if (!result.InvokeEvent)
                    {
                        continue;
                    }

                    if (CurrentDay < 0 || CurrentDay >= DailySurveyList.Length)
                    {
                        break;
                    }

                    WeirdEventManager.HasWeirdEvent = true;
                    WeirdEventManager.ReplaceAndStartEvent(DailySurveyList[CurrentDay].weridEvent);
                
                    break;
                }
                else
                {
                    WeirdEventManager.HasWeirdEvent = false;
                    WeirdEventManager.EndEvents();
                }
            }

            Survey.ResetNormalRewardResult();
        }
    }
}
