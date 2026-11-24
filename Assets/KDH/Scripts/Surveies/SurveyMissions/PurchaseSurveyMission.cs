using KDH.Scripts.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace KDH.Scripts.Surveies
{
    public class PurchaseSurveyMission : MonoBehaviour
    {
        private SurveyQS_T_8 _mission;
        private Button _purchaseBtn;


        private void Awake()
        {
            _purchaseBtn = GetComponentInChildren<Button>();

            _purchaseBtn.onClick.AddListener(CheckBuy);
        }

        private void CheckBuy()
        {
            _mission ??= GameManager.Instance.Survey.ExceptionSurveySpawnTrm.GetComponentInChildren<SurveyQS_T_8>();
            
            if (_mission == null || _mission.IsCleared)
            {
                return;
            }
            
            if (_mission.TryClear())
            {
                _purchaseBtn.onClick.RemoveListener(CheckBuy);
                GameManager.Instance.Survey.InitSurveyQuiz();
                return;
            }
        }
    }
}
