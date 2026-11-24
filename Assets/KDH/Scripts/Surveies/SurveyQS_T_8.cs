using KDH.Scripts.Surveies;
using KDH.Scripts.Systems;
using UnityEngine;

public class SurveyQS_T_8 : AbstractSurveyMission
{
    [SerializeField, Min(50)] private int startCredit;

    private bool _hasBought = false;

    private void Start()
    {
        GameManager.Instance.Resources.GetCredit(startCredit);
        GameManager.Instance.Resources.OnItemBuy += SetBool;
    }

    public override bool SpecialCondition() // 구매하는 설문 예외 구현하기, PurchaseSurveyMission 확인하기
    {
        if (!_hasBought)
        {
            GameManager.Instance.Resources.OnItemBuy -= SetBool;
        }

        return true;
    }

    private void SetBool()
    {
        _hasBought = true;
    }
}
