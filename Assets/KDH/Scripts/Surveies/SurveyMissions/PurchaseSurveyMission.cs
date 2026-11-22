using KDH.Scripts.Items;
using KDH.Scripts.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace KDH.Scripts.Surveies
{
    public class PurchaseSurveyMission : MonoBehaviour
    {
        private ItemSOHandler _itemHandler;
        private SurveyQS_T_8 _mission;
        private Button _purchaseBtn;
        private bool _isCleared;

        private void Awake()
        {
            _itemHandler = GetComponentInChildren<ItemSOHandler>();
            _purchaseBtn = GetComponent<Button>();

            _purchaseBtn.onClick.AddListener(CheckBuy);
        }

        private void CheckBuy()
        {
            if (_isCleared)
            {
                return;
            }

            if (_mission == null)
            {
                _mission = GameManager.Instance.Survey.ExceptionSurveySpawnTrm.GetComponentInChildren<SurveyQS_T_8>();
            }

            if (GameManager.Instance.Resources.Credit >= _itemHandler.ItemData.cost && _mission.SpecialCondition())
            {
                _isCleared = true;
                _purchaseBtn.onClick.RemoveListener(CheckBuy);


            }
        }
    }
}
